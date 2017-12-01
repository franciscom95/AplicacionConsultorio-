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
using Consultorio.DataHelper;

namespace Consultorio
{
    [Activity(Label = "Doctores")]
    public class Listas : Activity
    {
        ListView lsData;
        List<Doctor> LstSource = new List<Doctor>();
        Database db;
        Button Btnagregar = null,BtnEliminar = null,BtnModificar = null,Buscar=null;

        int id=0;

        EditText Nombre = null, Correo = null, telefono = null,txtbuscar=null;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Listas);
            lsData = FindViewById<ListView>(Resource.Id.listView);
            db = new Database();
            Btnagregar = FindViewById<Button>(Resource.Id.btnAgregar);
            BtnEliminar = FindViewById<Button>(Resource.Id.btnEliminar);
            BtnModificar= FindViewById<Button>(Resource.Id.btnEditar);
            Buscar = FindViewById<Button>(Resource.Id.Buscar);
            Nombre = FindViewById<EditText>(Resource.Id.txtNombre);
            Correo = FindViewById<EditText>(Resource.Id.txtDoctorEmail);
            telefono = FindViewById<EditText>(Resource.Id.txtTelefono);

            txtbuscar = FindViewById<EditText>(Resource.Id.txtbuscardoctor);

            Btnagregar.Click += Btnagregar_Click;
            BtnEliminar.Click += BtnEliminar_Click;
            BtnModificar.Click += BtnModificar_Click;
            Buscar.Click += Buscar_Click;

            LoadData();
            lsData.ItemClick += LsData_ItemClick;  
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            if (txtbuscar.Text.Length == 0)
            {
                LoadData();
            }
            else
            {
                LstSource = LstSource.Where(x => x.NombreDoctor.Contains(txtbuscar.Text)).ToList();
              
                var adapter = new ListViewAdapter(this, LstSource);
                lsData.Adapter = adapter;
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                Toast toast = Toast.MakeText(this, "No Tiene un elemento seleccionado", ToastLength.Short);
                toast.Show();
            }
            else
            {

                if (Nombre.Text.Length <= 0 || Correo.Text.Length <= 0 || telefono.Text.Length <= 0)
                {
                    Toast toast = Toast.MakeText(this, "Revisar que todos los campos esten llenos", ToastLength.Short);
                    toast.Show();
                }
                else { 

                db.UpdateDoctor(new Doctor { IdDoctor = id,NombreDoctor = Nombre.Text,Email = Correo.Text,Telefono = telefono.Text });
                LimpiarControles();
                LoadData();
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {   if(id==0)
            {
                Toast toast = Toast.MakeText(this, "No Tiene un elemento seleccionado",ToastLength.Short);
                toast.Show();
            }
            else
            {
                db.DeleteDoctor(new Doctor { IdDoctor = id });
                LoadData();
            }
        }

        private void LsData_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Nombre.Text = LstSource[e.Position].NombreDoctor;
            Correo.Text = LstSource[e.Position].Email;
            telefono.Text = LstSource[e.Position].Telefono;
            id = LstSource[e.Position].IdDoctor;


        }

        private void Btnagregar_Click(object sender, EventArgs e)
        {
            if (Nombre.Text.Length<=0 || Correo.Text.Length <= 0|| telefono.Text.Length <= 0)
            {
                Toast toast = Toast.MakeText(this, "Revisar que todos los campos esten llenos", ToastLength.Short);
                toast.Show();
            }
            else
            {
                Doctor doc = new Consultorio.Doctor
                {
                    NombreDoctor = Nombre.Text,
                    Email = Correo.Text,
                    Telefono = telefono.Text
                };


                db.InsertIntoDoctor(doc);
                LimpiarControles();

                LoadData();
            }


          
        }

        private void LoadData()
        {
            LstSource = db.SelectDoctor();
            var adapter = new ListViewAdapter(this, LstSource);
            lsData.Adapter = adapter;
        }


        private void LimpiarControles()
        {

            Nombre.Text = string.Empty;
            Correo.Text = string.Empty;
            telefono.Text = string.Empty;

        }

    }
}

