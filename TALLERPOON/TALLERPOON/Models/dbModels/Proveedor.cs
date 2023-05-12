using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TALLERPOON.Models.dbModels;

[Table("proveedor", Schema = "farmacia")]
public partial class Proveedor
{
    [Key]
    [Column("Id_prov")]
    public int IdProv { get; set; }

    [Column("nom_prov")]
    [StringLength(60)]
    public string NomProv { get; set; } = null!;

    [Column("tel_prov")]
    [StringLength(10)]
    public string TelProv { get; set; } = null!;

    [Column("corr_prov")]
    [StringLength(250)]
    public string CorrProv { get; set; } = null!;

    [Column("dir_prov")]
    [StringLength(250)]
    public string DirProv { get; set; } = null!;

    [InverseProperty("IdProvNavigation")]
    public virtual ICollection<Detalleev> Detalleevs { get; set; } = new List<Detalleev>();

    [InverseProperty("IdProvNavigation")]
    public virtual ICollection<Detallepp> Detallepps { get; set; } = new List<Detallepp>();
}
