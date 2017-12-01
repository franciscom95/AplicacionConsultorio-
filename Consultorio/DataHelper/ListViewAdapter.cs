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
    public class ViewHolder : Java.Lang.Object
    {
        public TextView txtname { get; set; }
        public TextView txtEspecialidad { get; set; }

    }
  public   class ListViewAdapter:BaseAdapter
    {

        private Activity activity;
        private List<Doctor> lstUsuario;

        public ListViewAdapter(Activity activity,List<Doctor>lstUsuario)
        {
            this.activity = activity;
            this.lstUsuario = lstUsuario;
        }

        public override int Count
        {
            get
            {
                return lstUsuario.Count();
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
           return  null;
        }

        public override long GetItemId(int position)
        {
            return lstUsuario[position].IdDoctor;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.DataTemplate,parent,false);

            var txtnombre = view.FindViewById<TextView>(Resource.Id.textouno);
            var txtEmail = view.FindViewById<TextView>(Resource.Id.textodos);
            var txtTelefono = view.FindViewById<TextView>(Resource.Id.textotres);

            txtnombre.Text = lstUsuario[position].NombreDoctor;
            txtEmail.Text = lstUsuario[position].Email;
            txtTelefono.Text = lstUsuario[position].Telefono;
            return view;
        }
    }
}