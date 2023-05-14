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
    public class DetalleEVUpdate
    {
        public int IdDetalleEp { get; set; }
        public int IdEmpl { get; set; }
        public int IdProv { get; set; }
        public DateTime FechDetalleEp { get; set; }
    }

}
