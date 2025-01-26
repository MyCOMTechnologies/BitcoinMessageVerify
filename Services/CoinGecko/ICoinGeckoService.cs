// <copyright company="Chris McGorty" author="Chris McGorty">
//     Copyright (c) 2024 All Rights Reserved
// </copyright>


namespace BitcoinMessageVerify.Services.CoinGecko;

public interface ICoinGeckoService
{
    Task<decimal?> GetCurrentPriceAsync(string currency = "usd");
}
