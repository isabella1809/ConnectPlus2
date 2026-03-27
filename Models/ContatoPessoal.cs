using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.Models;

[Table("ContatoPessoal")]
[Index("NumerodocontatoPessoal", Name = "UQ__ContatoP__93B774B869C2DB30", IsUnique = true)]
public partial class ContatoPessoal
{
    [Key]
    public Guid IdContatoPessoal { get; set; }

    [StringLength(100)]
    public string NomePessoal { get; set; } = null!;

    [StringLength(90)]
    public string NumerodocontatoPessoal { get; set; } = null!;
}
