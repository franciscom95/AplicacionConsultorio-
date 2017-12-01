using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace Consultorio
{
    public class PacienteConsulta
    {
        [PrimaryKey AutoIncrement]
        public int IdPacienteConsulta { get; set; }
        public int IdPaciente { get; set; }
        public decimal PresionArterial { get; set; }
        public decimal Estatura { get; set; }
        public decimal PesoCorporal { get; set; }
        public string MotivoConsulta { get; set; }
        public string Diagnostico { get; set; }
        public string Medicamento { get; set; }
        public string Indicadiones { get; set; }
        public string FechaConsulta { get; set; }
        public string EsCumplio { get; set; } 

       


    }
}