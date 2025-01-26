namespace BitcoinMessageVerify.Resources.Strings
{
    public partial class AppResources
    {
        private static global::System.Resources.ResourceManager resourceMan;
        private static global::System.Globalization.CultureInfo resourceCulture;

        public static global::System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BitcoinMessageVerify.Resources.Strings.AppResources", typeof(AppResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        public static global::System.Globalization.CultureInfo Culture
        {
            get { return resourceCulture; }
            set { resourceCulture = value; }
        }

        public static string Wif
        {
            get { return ResourceManager.GetString("Wif", resourceCulture); }
        }
        public static string Mnemonic
        {
            get { return ResourceManager.GetString("Mnemonic", resourceCulture); }
        }
        public static string BitcoinAddress
        {
            get { return ResourceManager.GetString("BitcoinAddress", resourceCulture); }
        }
        public static string SignMessage
        {
            get { return ResourceManager.GetString("SignMessage", resourceCulture); }
        }
        public static string SignedMessage
        {
            get { return ResourceManager.GetString("SignedMessage", resourceCulture); }
        }
        public static string Message
        {
            get { return ResourceManager.GetString("Message", resourceCulture); }
        }

        public static string MessageIsRequired
        {
            get { return ResourceManager.GetString("MessageIsRequired", resourceCulture); }
        }
        public static string BitcoinAddressIsRequired
        {
            get { return ResourceManager.GetString("BitcoinAddressIsRequired", resourceCulture); }
        }
        public static string MnemonicIsRequired
        {
            get { return ResourceManager.GetString("MnemonicIsRequired", resourceCulture); }
        }
        public static string WifIsRequired
        {
            get { return ResourceManager.GetString("WifIsRequired", resourceCulture); }
        }
        public static string BitcoinAddressIsInvalid
        {
            get { return ResourceManager.GetString("BitcoinAddressIsInvalid", resourceCulture); }
        }
        public static string WifIsInvalid
        {
            get { return ResourceManager.GetString("WifIsInvalid", resourceCulture); }
        }
        public static string MnemonicIsInvalid
        {
            get { return ResourceManager.GetString("MnemonicIsInvalid", resourceCulture); }
        }
        public static string MnemonicWordCount
        {
            get { return ResourceManager.GetString("MnemonicWordCount", resourceCulture); }
        }
        public static string SignedMessageCopied
        {
            get { return ResourceManager.GetString("SignedMessageCopied", resourceCulture); }
        }
        public static string OK
        {
            get { return ResourceManager.GetString("OK", resourceCulture); }
        }
        public static string MnemonicExplanation
        {
            get { return ResourceManager.GetString("MnemonicExplanation", resourceCulture); }
        }
        public static string WifExplanation
        {
            get { return ResourceManager.GetString("WifExplanation", resourceCulture); }
        }
        public static string LedgerExplanation
        {
            get { return ResourceManager.GetString("LedgerExplanation", resourceCulture); }
        }
        public static string ProofOfOwnership
        {
            get { return ResourceManager.GetString("ProofOfOwnership", resourceCulture); }
        }
        public static string VerifyMessage
        {
            get { return ResourceManager.GetString("VerifyMessage", resourceCulture); }
        }
        public static string ValidationFailed
        {
            get { return ResourceManager.GetString("ValidationFailed", resourceCulture); }
        }
    }
}
