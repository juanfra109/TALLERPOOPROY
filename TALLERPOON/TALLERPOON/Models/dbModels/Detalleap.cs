using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TALLERPOON.Models.dbModels;

[Table("detalleap", Schema = "farmacia")]
[Index("IdAlm", Name = "IX_detalleap_Id_alm")]
public partial class Detalleap
{
    [Key]
    [Column("Id_detalleap")]
    public int IdDetalleap { get; set; }

    [Column("id_prod")]
    public int IdProd { get; set; }

    [Column("Id_alm")]
    public int IdAlm { get; set; }

    [ForeignKey("IdAlm")]
    [InverseProperty("Detalleaps")]
    public virtual Almacen IdAlmNavigation { get; set; } = null!;

    [ForeignKey("IdDetalleap")]
    [InverseProperty("Detalleap")]
    public virtual Producto IdDetalleapNavigation { get; set; } = null!;
}
