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

    public class ListViewAdapterEstudios : BaseAdapter
    {
        private Activity activity;
        private List<Estudios> lstEstudios;

        public ListViewAdapterEstudios(Activity activity, List<Estudios> lstEstudios)
        {
            this.activity = activity;
            this.lstEstudios = lstEstudios;
        }

        public override int Count
        {
            get
            {
                return lstEstudios.Count();
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return lstEstudios[position].IdEstudio;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.DataTemplateEstudios, parent, false);

            var txtUno = view.FindViewById<TextView>(Resource.Id.estudiouno);
            var txtDos = view.FindViewById<TextView>(Resource.Id.estudiodos);
            var txtTres = view.FindViewById<TextView>(Resource.Id.estuditres);
            var txtCuatro = view.FindViewById<TextView>(Resource.Id.estudiocuatro);
          

            txtUno.Text = lstEstudios[position].NomEstudio;
            txtDos.Text = lstEstudios[position].FechaARealizar;
            txtTres.Text = lstEstudios[position].EsRealizado;
            txtCuatro.Text = lstEstudios[position].Resultados;
            
            return view;
        }
    }
}