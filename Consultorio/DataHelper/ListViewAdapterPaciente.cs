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
using Java.Lang;

namespace Consultorio.DataHelper
{
    
    public   class ListViewAdapterPaciente : BaseAdapter
    {
        private Activity activity;
        private List<Paciente> lstPaciente;

        public ListViewAdapterPaciente(Activity activity, List<Paciente> lstPaciente)
        {
            this.activity = activity;
            this.lstPaciente = lstPaciente;
        }

        public override int Count
        {
            get
            {
                return lstPaciente.Count();
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return lstPaciente[position].IdPaciente;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.TemplatePaciente, parent, false);

            var txtUno = view.FindViewById<TextView>(Resource.Id.txtPacienteUno);
            var txtDos = view.FindViewById<TextView>(Resource.Id.txtPacienteDos);
            var txtTres = view.FindViewById<TextView>(Resource.Id.txtPacienteTres);
            var txtCuatro = view.FindViewById<TextView>(Resource.Id.txtPacienteCuatro);
            var txtCinco = view.FindViewById<TextView>(Resource.Id.txtPacienteCinco);
            var txtSeis = view.FindViewById<TextView>(Resource.Id.txtPacienteSeis);
            var txtSiete = view.FindViewById<TextView>(Resource.Id.txtPacienteSiete);
            var txtOcho = view.FindViewById<TextView>(Resource.Id.txtPacienteOcho);
            var txtNueve = view.FindViewById<TextView>(Resource.Id.txtPacienteNueve);
            var txtDiez = view.FindViewById<TextView>(Resource.Id.txtPacienteDiez);

            txtUno.Text = lstPaciente[position].NomPaciente;
            txtDos.Text = lstPaciente[position].Email;
            txtTres.Text = lstPaciente[position].Telefono;
            txtCuatro.Text = lstPaciente[position].FechaNacimiento;
            txtCinco.Text = lstPaciente[position].Alergias;
            txtSeis.Text = lstPaciente[position].MedicamentosNoPermitidos;
            txtSiete.Text = lstPaciente[position].EnfermedadesCronicas;
            txtOcho.Text = lstPaciente[position].Sexo;
            txtNueve.Text = lstPaciente[position].Ocupacion;
            txtDiez.Text = lstPaciente[position].NumeroEmergencia;
            return view;
        }
    }
}