namespace BankAPI.Data.DTOs;

public class BankTransactionDto
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int TransactionType { get; set; }
    public decimal Amount { get; set; }
    public int? ExternalAccount { get; set; }
    public decimal Balance {get; set;}
    public string Email { get; set; } = null!;
    public string Pwd { get; set; } = null!;
}