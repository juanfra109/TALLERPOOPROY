using Microsoft.EntityFrameworkCore;
using TALLERPOON.Models.dbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace TALLERPOON.Dto
{
    public class DetalleAPCreate
    {
        public int IdDetalleap { get; set; }

        [Column("id_prod")]
        public int IdProd { get; set; }

        [Column("Id_alm")]
        public int IdAlm { get; set; }
    }
}
