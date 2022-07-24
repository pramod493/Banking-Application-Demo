using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Transaction {
    [Key]
    [DatabaseGenerated()]
    public int Id {get; set;}
    public int SourceId {get; set;}
    public int DestinationId {get; set;}
    public double SourceBalance {get; set;}
    public double DestinationBalance {get; set;}
    public DateTime TransferTime {get; set;}
    public decimal TransferAmount {get; set;}
}