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
  public   class Usuario
    {
        [PrimaryKey AutoIncrement]
        public int Id { get; set; }
        public string User { get; set; }
        public string Contraseña { get; set; }
        public string Nombre { get; set; }

    }
}