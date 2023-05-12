using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TALLERPOON.Models.dbModels;

[Table("detallepp", Schema = "farmacia")]
[Index("IdProd", Name = "IX_detallepp_id_prod")]
[Index("IdProv", Name = "IX_detallepp_id_prov")]
public partial class Detallepp
{
    [Key]
    [Column("id_detallepp")]
    public int IdDetallepp { get; set; }

    [Column("id_prod")]
    public int IdProd { get; set; }

    [Column("nom_prod")]
    [StringLength(50)]
    public string NomProd { get; set; } = null!;

    [Column("cant_prod")]
    public int CantProd { get; set; }

    [Column("id_prov")]
    public int IdProv { get; set; }

    [ForeignKey("IdProd")]
    [InverseProperty("Detallepps")]
    public virtual Producto IdProdNavigation { get; set; } = null!;

    [ForeignKey("IdProv")]
    [InverseProperty("Detallepps")]
    public virtual Proveedor IdProvNavigation { get; set; } = null!;
}
