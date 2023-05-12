using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TALLERPOON.Models.dbModels;

[Table("venta", Schema = "farmacia")]
[Index("IdEmpl", Name = "IX_venta_Id_empl")]
public partial class Ventum
{
    [Key]
    [Column("Id_vent")]
    public int IdVent { get; set; }

    [Column("Fech_vent", TypeName = "date")]
    public DateTime FechVent { get; set; }

    [Column("total_vent", TypeName = "decimal(19, 4)")]
    public decimal TotalVent { get; set; }

    [Column("Id_empl")]
    public int IdEmpl { get; set; }

    [ForeignKey("IdEmpl")]
    [InverseProperty("Venta")]
    public virtual Empleado IdEmplNavigation { get; set; } = null!;
}
