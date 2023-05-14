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
    public class DetallePPCreate
    {
        public int IdDetallepp { get; set; }
        public int IdProd { get; set; }
        public string NomProd { get; set; } = null!;
        public int CantProd { get; set; }
        public int IdProv { get; set; }
    }
}
