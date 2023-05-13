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
    public class DetalleAPUpdate
    {
        public int IdDetalleap { get; set; }
        public int IdProd { get; set; }
        public int IdAlm { get; set; }
    }
}
