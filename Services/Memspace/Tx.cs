// <copyright company="Chris McGorty" author="Chris McGorty">
//     Copyright (c) 2024 All Rights Reserved
// </copyright>
using System.Text.Json.Serialization;

namespace BitcoinMessageVerify.Services.Memspace;

public class Tx
{
    [JsonPropertyName("txid")]
    public string? Txid { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }

    [JsonPropertyName("locktime")]
    public int? Locktime { get; set; }

    [JsonPropertyName("vin")]
    public List<TxInput>? Vin { get; set; }

    [JsonPropertyName("vout")]
    public List<TxOutput>? Vout { get; set; }

    [JsonPropertyName("size")]
    public int? Size { get; set; }

    [JsonPropertyName("weight")]
    public int? Weight { get; set; }

    [JsonPropertyName("sigops")]
    public int? SigOps { get; set; }

    [JsonPropertyName("fee")]
    public long? Fee { get; set; }

    [JsonPropertyName("status")]
    public TxStatus? Status { get; set; }
}

public class TxInput
{
    [JsonPropertyName("txid")]
    public string? Txid { get; set; }

    [JsonPropertyName("vout")]
    public int? Vout { get; set; }

    [JsonPropertyName("prevout")]
    public TxPrevout? Prevout { get; set; }
}

public class TxPrevout
{
    [JsonPropertyName("scriptpubkey")]
    public string? Scriptpubkey { get; set; }

    [JsonPropertyName("scriptpubkey_asm")]
    public string? ScriptpubkeyAsm { get; set; }

    [JsonPropertyName("scriptpubkey_type")]
    public string? ScriptpubkeyType { get; set; }

    [JsonPropertyName("scriptpubkey_address")]
    public string? ScriptpubkeyAddress { get; set; }

    [JsonPropertyName("value")]
    public long? Value { get; set; }
}

public class TxOutput
{
    [JsonPropertyName("scriptputkey")]
    public string? Scriptpubkey { get; set; }

    [JsonPropertyName("scriptpubkey_asm")]
    public string? ScriptpubkeyAsm { get; set; }

    [JsonPropertyName("scriptpubkey_type")]
    public string? ScriptpubkeyType { get; set; }

    [JsonPropertyName("scriptpubkey_address")]
    public string? ScriptpubkeyAddress { get; set; }

    [JsonPropertyName("value")]
    public long? Value { get; set; }
}

public class TxStatus
{
    [JsonPropertyName("confirmed")]
    public bool? Confirmed { get; set; }

    [JsonPropertyName("block_height")]
    public int? BlockHeight { get; set; }

    [JsonPropertyName("block_hash")]
    public string? BlockHash { get; set; }

    [JsonPropertyName("block_time")]
    public long? BlockTime { get; set; }
}