using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.Models;

[Table("TipoContatoFamiliar")]
[Index("NumeroContatoFamiliar", Name = "UQ__TipoCont__D4377EE7945FEBA9", IsUnique = true)]
public partial class TipoContatoFamiliar
{
    [Key]
    public Guid IdContatoFamiliar { get; set; }

    [StringLength(100)]
    public string NomeFamiliar { get; set; } = null!;

    [StringLength(90)]
    public string NumeroContatoFamiliar { get; set; } = null!;
}
