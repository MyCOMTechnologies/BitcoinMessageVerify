// <copyright company="Chris McGorty" author="Chris McGorty">
//     Copyright (c) 2024 All Rights Reserved
// </copyright>

namespace BitcoinMessageVerify.Services.Memspace;


public class Utxo
{
    // The transaction ID where this UTXO was created.
    public string? Txid { get; set; }

    // The output index in the transaction.
    public int? Vout { get; set; }

    // The value is expressed in satoshis in the UTXO (1 BTC = 100,000,000 satoshis).
    public long? Value { get; set; }

    // Contains additional information about the confirmation status
    public UtxoStatus? Status { get; set; }
}

public class UtxoStatus
{
    // Boolean indicating if the transaction is confirmed
    public bool? Confirmed { get; set; }

    // The height of the block where the transaction was included (only present if confirmed)
    public int? BlockHeight { get; set; }

    // The hash of the block where the transaction was included (only present if confirmed).
    public string? BlockHash { get; set; }

    // The timestamp of the block (Unix epoch time, only present if confirmed).
    public long? BlockTime { get; set; }
}