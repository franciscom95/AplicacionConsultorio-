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
 public   class ListViewAdapterConsultas : BaseAdapter
    {
        private Activity activity;
        private List<PacienteConsulta> lstPacienteConsulta;


        public ListViewAdapterConsultas(Activity activity, List<PacienteConsulta> lstPacienteConsulta)
        {
            this.activity = activity;
            this.lstPacienteConsulta = lstPacienteConsulta;
        }

        public override int Count
        {
            get
            {
                return lstPacienteConsulta.Count();
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return lstPacienteConsulta[position].IdPacienteConsulta;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.TemplateConsultas, parent, false);
            var IdPacienteConsulta = view.FindViewById<TextView>(Resource.Id.IdPacienteConsulta);
            var PresionArterial = view.FindViewById<TextView>(Resource.Id.PresionArterial);
            var Estatura = view.FindViewById<TextView>(Resource.Id.Estatura);
            var PesoCorporal = view.FindViewById<TextView>(Resource.Id.PesoCorporal);
            var MotivoConsulta = view.FindViewById<TextView>(Resource.Id.MotivoConsulta);
            var Diagnostico = view.FindViewById<TextView>(Resource.Id.Diagnostico);
            var Medicamento = view.FindViewById<TextView>(Resource.Id.Medicamento);
            var Indicadiones = view.FindViewById<TextView>(Resource.Id.Indicadiones);            
            var FechaConsulta = view.FindViewById<TextView>(Resource.Id.FechaConsulta);
            var EsCumplio = view.FindViewById<TextView>(Resource.Id.EsCumplio);
            


            IdPacienteConsulta.Text =  lstPacienteConsulta[position].IdPacienteConsulta.ToString();
            PresionArterial.Text = lstPacienteConsulta[position].PresionArterial.ToString();
            Estatura.Text = lstPacienteConsulta[position].Estatura.ToString();
            PesoCorporal.Text = lstPacienteConsulta[position].PesoCorporal.ToString();
            MotivoConsulta.Text = lstPacienteConsulta[position].MotivoConsulta.ToString();
            Diagnostico.Text = lstPacienteConsulta[position].Diagnostico.ToString();
            Medicamento.Text = lstPacienteConsulta[position].Medicamento.ToString();
            Indicadiones.Text = lstPacienteConsulta[position].Indicadiones.ToString();
            FechaConsulta.Text = lstPacienteConsulta[position].FechaConsulta.ToString();
            EsCumplio.Text = lstPacienteConsulta[position].EsCumplio.ToString();






            return view;
        }
    }
}
