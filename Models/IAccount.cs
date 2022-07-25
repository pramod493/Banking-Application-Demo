namespace BankingApp_PK.Models; 

public interface IAccount {
    int Id { get; set; }
    string Name { get; set; }
    decimal Balance { get; set; }
    bool Active { get; set; }
}