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
    public class DetalleEAUpdate
    {
        public int IdDetalleEa { get; set; }
        public int IdEmpl { get; set; }
        public int IdAlm { get; set; }
        public DateTime FechaDetalleEa { get; set; }
    }
}
