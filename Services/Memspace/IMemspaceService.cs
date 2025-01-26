// <copyright company="Chris McGorty" author="Chris McGorty">
//     Copyright (c) 2024 All Rights Reserved
// </copyright>

namespace BitcoinMessageVerify.Services.Memspace;

public interface IMemspaceService
{
    Task<string> GetDataAsync(string url);
    Task<List<Utxo>?> GetUtxosAsync(string address);
    Task<List<Tx>?> GetAddressTransactionsAsync(string address);
    List<BalancePoint> CalculateBalance(List<Tx>? txs, string address);
}
