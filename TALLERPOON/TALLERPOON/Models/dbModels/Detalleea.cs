using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TALLERPOON.Models.dbModels;

[Table("detalleea", Schema = "farmacia")]
[Index("IdAlm", Name = "IX_detalleea_id_alm")]
[Index("IdEmpl", Name = "IX_detalleea_id_empl")]
public partial class Detalleea
{
    [Key]
    [Column("id_detalleEA")]
    public int IdDetalleEa { get; set; }

    [Column("id_empl")]
    public int IdEmpl { get; set; }

    [Column("id_alm")]
    public int IdAlm { get; set; }

    [Column("fecha_detalleEA", TypeName = "date")]
    public DateTime FechaDetalleEa { get; set; }

    [ForeignKey("IdAlm")]
    [InverseProperty("Detalleeas")]
    public virtual Almacen IdAlmNavigation { get; set; } = null!;

    [ForeignKey("IdEmpl")]
    [InverseProperty("Detalleeas")]
    public virtual Empleado IdEmplNavigation { get; set; } = null!;
}
