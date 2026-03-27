using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.Models;

[Table("TipoContato")]
public partial class TipoContato
{
    [Key]
    public Guid IdTipoContato { get; set; }

    [StringLength(100)]
    public string Nome { get; set; } = null!;

    [Column("SMS")]
    [StringLength(10)]
    public string Sms { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    public int? IdContato { get; set; }

    [ForeignKey("IdTipoContato")]
    [InverseProperty("TipoContato")]
    public virtual Contato IdTipoContatoNavigation { get; set; } = null!;
    public object Numero { get; internal set; }
}
