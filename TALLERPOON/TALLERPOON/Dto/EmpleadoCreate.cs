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
    public class EmpleadoCreate
    {
        public int IdEmpl { get; set; }
        public string NomEmpl { get; set; } = null!;
        public string TelEmp { get; set; } = null!;
        public string RfcEmpl { get; set; } = null!;
        public string DirEmpl { get; set; } = null!;
        public int TurnEmpl { get; set; }
        public string Correo { get; set; } = null!;
    }
}
