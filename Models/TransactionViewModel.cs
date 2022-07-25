using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BankingApp_PK.Models; 

public class TransactionViewModel {
    public int Id {get; set;}
    
    [DisplayName("From Account")]
    public string Source {get; set;}
    
    [DisplayName("To Account")]
    public string Destination {get; set;}
    
    [DisplayName("Transaction Time")]
    public DateTime TransferTime {get; set;}
    
    [DisplayName("Amount Debited")]
    [DataType(DataType.Currency)]
    
    public decimal TransferAmount {get; set;}
    [DataType(DataType.Currency)]
    [DisplayName("From Account Balance")]
    public decimal SourceBalance { get; set; }
    
    [DisplayName("To Account Balance")]
    [DataType(DataType.Currency)]
    public decimal DestinationBalance { get; set; }
}