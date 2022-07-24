using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BankingApp_PK.Models;

public class Account {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {get; set;}
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Account name cannot be empty")]
    public string Name {get; set;}

    // SQLite doesn't really respect data types but will be useful for databases with stricter type checking
    [Required, Column(TypeName = "decimal(20,2)")]  
    public decimal Balance {get; set;}
    
    public bool Active {get; set;}
}