using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingApp_PK.Models;
public class Transaction : ITransaction {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {get; set;}
    [Required]
    [DisplayName("From Account")]
    public int Source {get; set;}
    [Required]
    [DisplayName("To Account")]
    public int Destination {get; set;}
    [Required]
    [DisplayName("Transaction Time")]
    public DateTime TransferTime {get; set;}
    [Required]
    [DisplayName("Amount Debited")]
    [DataType(DataType.Currency)]
    [Range(1, 10000)]
    public decimal TransferAmount {get; set;}
    [Required]
    [DataType(DataType.Currency)]
    [DisplayName("From Account Balance")]
    public decimal SourceBalance { get; set; }
    
    [Required]
    [DisplayName("To Account Balance")]
    [DataType(DataType.Currency)]
    public decimal DestinationBalance { get; set; }
}