// <copyright company="Chris McGorty" author="Chris McGorty">
//     Copyright (c) 2024 All Rights Reserved
// </copyright>

using System.Text.Json;
using Telerik.Windows.Documents.Spreadsheet.Expressions.Functions;

namespace BitcoinMessageVerify.Services.Memspace;

public class MemspaceService(HttpClient httpClient) : IMemspaceService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<string> GetDataAsync(string url)
    {
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<List<Utxo>?> GetUtxosAsync(string address)
    {
        var response = await _httpClient.GetAsync($"https://mempool.space/api/address/{address}/utxo");
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<Utxo>>(jsonResponse);
    }

    public async Task<List<Tx>?> GetAddressTransactionsAsync(string address)
    {
        var response = await _httpClient.GetAsync($"https://mempool.space/api/address/{address}/txs");
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<Tx>>(jsonResponse);
    }

    public List<BalancePoint> CalculateBalance(List<Tx>? txs, string address)
    {
        var balancePoints = new List<BalancePoint>();
        int transId = 1;
        decimal currentBalance = 0;
        decimal received;
        decimal sent;
        decimal amount;

        if (txs is not null)
        {
            var sortedTransactions = txs.OrderBy(t => t.Status?.BlockTime);

            foreach (var tx in sortedTransactions)
            {
                // Sum outputs for the address
                received = tx.Vout.Where(v => v.ScriptpubkeyAddress == address && v.Value.HasValue).Sum(v => v.Value.Value);

                // Subtract inputs from the address
                sent = tx.Vin.Where(v => v.Prevout.ScriptpubkeyAddress == address && v.Prevout.Value.HasValue).Sum(v => v.Prevout.Value.Value);

                amount = received - sent;

                // Calculate current balance
                currentBalance += amount;

                // Add to balance points
                balancePoints.Add(new BalancePoint
                {
                    TransId = transId++,
                    Date = DateTimeOffset.FromUnixTimeSeconds(tx.Status.BlockTime.GetValueOrDefault()).UtcDateTime,
                    Amount = amount / 100000000m,
                    Balance = currentBalance / 1000000000m
                });
            }
        }

        return balancePoints;
    }

}