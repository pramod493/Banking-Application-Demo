namespace BankingApp_PK.Models; 

public interface ITransaction {
    int Id {get; set;}
    int Source {get; set;}
    int Destination {get; set;}
    DateTime TransferTime {get; set;}
    decimal TransferAmount {get; set;}
    decimal SourceBalance { get; set; }
    decimal DestinationBalance { get; set; } }