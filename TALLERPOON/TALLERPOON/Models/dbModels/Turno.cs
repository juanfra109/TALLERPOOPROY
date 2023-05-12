using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TALLERPOON.Models.dbModels;

[Table("turno")]
public partial class Turno
{
    [Key]
    [Column("id_turn")]
    public int IdTurn { get; set; }

    [Column("nombre_turn")]
    [StringLength(50)]
    public string NombreTurn { get; set; } = null!;

    [InverseProperty("TurnEmplNavigation")]
    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
