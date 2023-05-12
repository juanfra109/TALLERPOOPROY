using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TALLERPOON.Models.dbModels;

[Table("almacen", Schema = "farmacia")]
public partial class Almacen
{
    [Key]
    [Column("Id_alm")]
    public int IdAlm { get; set; }

    [Column("nom_alm")]
    [StringLength(60)]
    public string NomAlm { get; set; } = null!;

    [InverseProperty("IdAlmNavigation")]
    public virtual ICollection<Detalleap> Detalleaps { get; set; } = new List<Detalleap>();

    [InverseProperty("IdAlmNavigation")]
    public virtual ICollection<Detalleea> Detalleeas { get; set; } = new List<Detalleea>();
}
