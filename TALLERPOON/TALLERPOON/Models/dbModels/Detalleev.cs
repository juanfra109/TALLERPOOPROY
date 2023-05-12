using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TALLERPOON.Models.dbModels;

[Table("detalleev", Schema = "farmacia")]
[Index("IdEmpl", Name = "IX_detalleev_Id_empl")]
[Index("IdProv", Name = "IX_detalleev_Id_prov")]
public partial class Detalleev
{
    [Key]
    [Column("Id_detalleEP")]
    public int IdDetalleEp { get; set; }

    [Column("Id_empl")]
    public int IdEmpl { get; set; }

    [Column("Id_prov")]
    public int IdProv { get; set; }

    [Column("fech_detalleEP", TypeName = "date")]
    public DateTime FechDetalleEp { get; set; }

    [ForeignKey("IdEmpl")]
    [InverseProperty("Detalleevs")]
    public virtual Empleado IdEmplNavigation { get; set; } = null!;

    [ForeignKey("IdProv")]
    [InverseProperty("Detalleevs")]
    public virtual Proveedor IdProvNavigation { get; set; } = null!;
}
