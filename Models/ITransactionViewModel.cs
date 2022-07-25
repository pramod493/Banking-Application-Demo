namespace BankingApp_PK.Models;

public interface ITransactionViewMode {
    int Id { get; set; }
    string Source { get; set; }
    string Destination { get; set; }
    DateTime TransferTime { get; set; }
    decimal TransferAmount { get; set; }
    decimal SourceBalance { get; set; }
    decimal DestinationBalance { get; set; }
}