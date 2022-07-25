using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
namespace BankingApp_PK.Models; 

public class TransferViewModel {
    public List<string> Errors { get; set; } = new List<string>();
    public IEnumerable<IAccount> Accounts { get; set; }
    public int FromId { get; set; }
    public int ToId { get; set; }
    public decimal Amount { get; set; }

}