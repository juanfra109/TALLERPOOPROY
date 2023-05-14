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
    public class VentaCreate
    {
        public int IdVent { get; set; }
        public DateTime FechVent { get; set; }
        public decimal TotalVent { get; set; }
        public int IdEmpl { get; set; }
    }
}
