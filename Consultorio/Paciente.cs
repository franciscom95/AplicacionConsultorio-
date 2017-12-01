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
   public  class Paciente
    {

        [PrimaryKey AutoIncrement]
        public int    IdPaciente { get; set; }
        public string NomPaciente { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string FechaNacimiento { get; set; }
        public string Alergias { get; set; }
        public string MedicamentosNoPermitidos { get; set; }
        public string EnfermedadesCronicas { get; set; }
        public string Sexo { get; set; }
        public string Ocupacion { get; set; }
        public string NumeroEmergencia { get; set; }
        public string Religion { get; set; }
        public string Domicilio { get; set; }

    }
}