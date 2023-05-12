using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TALLERPOON.Models.dbModels;

[PrimaryKey("IdEmpl", "IdProd")]
[Table("carrito")]
[Index("IdProd", Name = "IX_carrito_id_prod")]
public partial class Carrito
{
    [Key]
    [Column("id_empl")]
    public int IdEmpl { get; set; }

    [Key]
    [Column("id_prod")]
    public int IdProd { get; set; }

    [Column("cantidad")]
    public int Cantidad { get; set; }

    [Column("total", TypeName = "money")]
    public decimal Total { get; set; }

    [ForeignKey("IdEmpl")]
    [InverseProperty("Carritos")]
    public virtual Empleado IdEmplNavigation { get; set; } = null!;

    [ForeignKey("IdProd")]
    [InverseProperty("Carritos")]
    public virtual Producto IdProdNavigation { get; set; } = null!;
}
