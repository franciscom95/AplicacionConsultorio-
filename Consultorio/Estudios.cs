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
  public   class Estudios
    {
        [PrimaryKey AutoIncrement]
        public int IdEstudio { get; set; }
        public int  IdPaciente { get; set; }
        public int IdConsulta { get; set; }
        public string NomEstudio { get; set; }
        public string EsRealizado { get; set; }
        public string FechaARealizar { get; set; }
        public string Resultados { get; set; }
    }
}