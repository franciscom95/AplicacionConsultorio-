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

namespace Consultorio
{
    [Activity(Label = "Menu")]
    public class Menu : Activity
    {
         ImageButton btn1 = null,btn2=null;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Singleton sn = new Singleton();
            sn.actualpaciente = -1;

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Menu);

            btn1 = FindViewById<ImageButton>(Resource.Id.Menu_btn1);
            btn2 = FindViewById<ImageButton>(Resource.Id.Menu_btn2);
            

            btn1.Click += Btn1_Click;
            btn2.Click += Btn2_Click;
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Activitys.ListaPacientes));
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            //Ir al Menú
            StartActivity(typeof(Listas));
        }
    }
}