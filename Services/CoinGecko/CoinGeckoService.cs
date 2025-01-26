// <copyright company="Chris McGorty" author="Chris McGorty">
//     Copyright (c) 2024 All Rights Reserved
// </copyright>
using System.Text.Json;

namespace BitcoinMessageVerify.Services.CoinGecko;

public class CoinGeckoService(HttpClient httpClient) : ICoinGeckoService
{
    private readonly HttpClient _httpClient = httpClient;

    private static bool HasInternetConnection()
    {
        var current = Connectivity.NetworkAccess;
        if (current == NetworkAccess.None)
            return false;
        else
            return true;
    }

    public async Task<decimal?> GetCurrentPriceAsync(string currency = "usd")
    {
        try
        {
            if (HasInternetConnection())
            {
                var response = await _httpClient.GetAsync("https://api.coingecko.com/api/v3/simple/price?ids=bitcoin&vs_currencies=usd");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var priceData = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, decimal>>>(content);

                var price = priceData?["bitcoin"]["usd"]; 
                
                return price;
            }
            else
                return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error {message}", ex.Message);
            return null;
        }
    }
}
