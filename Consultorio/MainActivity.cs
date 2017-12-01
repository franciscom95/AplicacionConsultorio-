using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace Consultorio
{
    [Activity(Label = "Consultorio", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        EditText txtUsuario = null;
        EditText txtContraseña = null;
        Button btnIniciarSesion = null;
        private Database db;

        protected override void OnCreate(Bundle bundle)
        {
            
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            btnIniciarSesion = FindViewById<Button>(Resource.Id.btnIniciarSesion);
            txtUsuario = FindViewById<EditText>(Resource.Id.txtUsuario);
            txtContraseña = FindViewById<EditText>(Resource.Id.pass);

            btnIniciarSesion.Click += BtnIniciarSesion_Click;

            //Create DB

            Database db = new Database();
            db.createDataBase();

        }

        private void BtnIniciarSesion_Click(object sender, System.EventArgs e)
        {
            if(txtUsuario.Text.Length>0 && txtContraseña.Text.Length>0)
            {
               if(txtUsuario.Text== "Admin" && txtContraseña.Text == "Admin")
                {
                    //Ir al Menú
                    StartActivity(typeof(Menu));
                }
                else
                {
                    Toast toast = Toast.MakeText(this, "Datos Incorrectos", ToastLength.Short);
                    toast.Show();
                }
            }
            else
            {
                Toast toast = Toast.MakeText(this, "Llenar usuario y contraseña", ToastLength.Short);
                toast.Show();
            }        
        }        
    }
}


