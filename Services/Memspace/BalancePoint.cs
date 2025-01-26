// <copyright company="Chris McGorty" author="Chris McGorty">
//     Copyright (c) 2024 All Rights Reserved
// </copyright>

namespace BitcoinMessageVerify.Services.Memspace;

public class BalancePoint
{
    public int TransId { get;set; }
    public DateTime Date { get; set; }
    public decimal Amount {get; set; }
    public decimal Balance { get; set; }
}
