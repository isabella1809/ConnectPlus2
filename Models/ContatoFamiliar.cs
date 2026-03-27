using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.Models;

[Table("ContatoFamiliar")]
[Index("NumeroContatoFamiliar", Name = "UQ__ContatoF__D4377EE72C35C387", IsUnique = true)]
public partial class ContatoFamiliar
{
    [Key]
    public Guid IdContatoFamiliar { get; set; }

    [StringLength(100)]
    public string NomeFamiliar { get; set; } = null!;

    [StringLength(90)]
    public string NumeroContatoFamiliar { get; set; } = null!;
}
