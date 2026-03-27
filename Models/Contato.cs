using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.Models;

[Table("Contato")]
[Index("Numero", Name = "UQ__Contato__7E532BC600C370EB", IsUnique = true)]
public partial class Contato
{
    [Key]
    public Guid IdContato { get; set; }

    [StringLength(100)]
    public string Nome { get; set; } = null!;

    [StringLength(90)]
    public string Numero { get; set; } = null!;

    [InverseProperty("IdTipoContatoNavigation")]
    public virtual TipoContato? TipoContato { get; set; }
    public string Imagem { get; internal set; }
    public object FormaContato { get; internal set; }
    public object IdTipoContatoNavigation { get; internal set; }
    public object IdTipoContato { get; internal set; }
}
