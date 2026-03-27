using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.Models;

[Table("ContatoProfissional")]
[Index("NumeroContatoProfissional", Name = "UQ__ContatoP__95BC8243AABCD534", IsUnique = true)]
public partial class ContatoProfissional
{
    [Key]
    public Guid IdContatoProfissional { get; set; }

    [StringLength(100)]
    public string NomeProfissional { get; set; } = null!;

    [StringLength(90)]
    public string NumeroContatoProfissional { get; set; } = null!;
}
