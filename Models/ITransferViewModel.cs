namespace BankingApp_PK.Models; 

public interface ITransferViewModel {
    IEnumerable<IAccount> Accounts { get; set; }
    Transaction Transaction { get; set; }
}