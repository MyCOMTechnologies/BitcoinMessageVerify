// <copyright company="Chris McGorty" author="Chris McGorty">
//     Copyright (c) 2024 All Rights Reserved
// </copyright>
using NBitcoin;


namespace BitcoinMessageVerify.Services.Bitcoin
{
    public enum BitcoinAddressType
    {
        Legacy_P2PHK = 44,
        PayToScriptHash_P2SH = 49,
        Bech32_Native_SegWit = 84,
        Taproot_P2TR = 86
    }

    internal class BitcoinServices
    {
        public static string SignMessage(string address, string message, string input)
        {
            string? signature = null;
            var bitcoinAddress = BitcoinAddress.Create(address, NBitcoin.Network.Main);
            Key? privateKey = null;

            // Convert coma delimited to space delimited, no trailing spaces
            input = input.Replace(',', ' ').Trim();
            if (IsMnemonic(input))
            {
                // Handle input as 12 or 24-word mnemonic phrase
                var mnemonic = new Mnemonic(input);

                // Extended Private Keys begin with xprv or xpub, otherwise it is a single key to a single address, extended is for HD
                var masterKey = mnemonic.DeriveExtKey();

                // Need to know what type of key we have in order to get the private key
                var addressType = GetBitcoinAddressType(address);

                // Try to find within the first 100 addresses
                for (int i = 0; i < 100; i++)
                {
                    var path = $"m/{(int)addressType}'/0'/0'/0/{i}";
                    var derivationPath = new KeyPath(path);
                    var derivationPrivateKey = masterKey.Derive(derivationPath).PrivateKey;
                    var derivationPublicKey = derivationPrivateKey.PubKey;
                    var derivationPublicAddress = derivationPublicKey.GetAddress(ScriptPubKeyType.Segwit, NBitcoin.Network.Main);
                    if (derivationPublicAddress == bitcoinAddress)
                    {
                        privateKey = derivationPrivateKey;
                        break;
                    }
                }
            }
            else
            {
                // Handle input as a private key in WIF format
                var bitcoinSecret = new BitcoinSecret(input, NBitcoin.Network.Main);
                privateKey = bitcoinSecret.PrivateKey;
            }

            if (privateKey == null)
                throw new ArgumentException("Unable to find the private key");

            var signed = privateKey.SignBIP322(bitcoinAddress, message, NBitcoin.BIP322.SignatureType.Simple);

            signature = signed.ToBase64();

            return signature;
        }

        public static bool VerifyMessage(string address, string message, string signature)
        {
            var bitcoinAddress = BitcoinAddress.Create(address, NBitcoin.Network.Main);

            var verified = bitcoinAddress.VerifyBIP322(message, signature);

            return verified;
        }

        private static bool IsMnemonic(string input)
        {
            // Check if the input is a valid mnemonic phrase (12 or 24 words)
            try
            {
                var mnemonic = new Mnemonic(input);
                return mnemonic.IsValidChecksum;
            }
            catch
            {
                return false;
            }
        }

        private static BitcoinAddressType GetBitcoinAddressType(string address)
        {
            if (string.IsNullOrEmpty(address))
                throw new ArgumentException("Missing Bitcoin Address");

            if (address[0] == '1')
                return BitcoinAddressType.Legacy_P2PHK;
            if (address[0] == '3')
                return BitcoinAddressType.PayToScriptHash_P2SH;
            if (address[0] == 'b' && address[1] == 'c' && address[2] == '1' && address[3] == 'p')
                return BitcoinAddressType.Taproot_P2TR;
            if (address[0] == 'b' && address[1] == 'c' && address[2] == '1')
                return BitcoinAddressType.Bech32_Native_SegWit;

            throw new ArgumentException("Invalid Bitcoin Address");
        }

        public static bool IsValidBitcoinAddress(string address, NBitcoin.Network? network = null)
        {
            try
            {
                network ??= NBitcoin.Network.Main;
                BitcoinAddress.Create(address, network);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool IsValidWif(string wif, NBitcoin.Network? network = null)
        {
            try
            {
                network ??= NBitcoin.Network.Main;
                var key = Key.Parse(wif, network);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool IsValidMnemonicWordCount(string mnemonic)
        {
            var words = mnemonic.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (words.Length == 12 || words.Length == 15 || words.Length == 18 || words.Length == 21 || words.Length == 24 )
                return true;
            else
                return false;
        }

        public static bool IsValidMnemonic(string mnemonic)
        {
            try
            {
                var mnemo = new Mnemonic(mnemonic);
                return mnemo.IsValidChecksum;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
