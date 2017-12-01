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
namespace Consultorio.Activitys
{
    [Activity(Label = "ListadoEstudios")]
    public class ListadoEstudios : Activity
    {
        #region Propertys
        ListView lsData;

        #endregion
        List<Estudios> LstSource = new List<Estudios>();
        Database db;
        Button Btnagregar = null, BtnEliminar = null, BtnModificar = null, Buscar = null;
        EditText NomEstudio = null,Resultados=null,BuscarTexto=null;
        DatePicker FechaEstudio = null;
        CheckBox EsRealizado = null;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Pacientes);
            lsData = FindViewById<ListView>(Resource.Id.ListViewEstudios);
            db = new Database();
            Btnagregar = FindViewById<Button>(Resource.Id.BtnAgregarEstudio);            
            BtnModificar = FindViewById<Button>(Resource.Id.btnEditarEstudio);
            Buscar = FindViewById<Button>(Resource.Id.BuscarEstudio);            
            #region Bildear
            NomEstudio = FindViewById<EditText>(Resource.Id.TxtNombrePaciente);
            Resultados = FindViewById<EditText>(Resource.Id.TxtEmailPaciente);
            FechaEstudio = FindViewById<DatePicker>(Resource.Id.datePicker1Estudios);
            EsRealizado = FindViewById<CheckBox>(Resource.Id.checkBox1Estudios);

            #endregion
            BuscarTexto = FindViewById<EditText>(Resource.Id.txtBuscarEstudios);
            Btnagregar.Click += Btnagregar_Click;
            BtnEliminar.Click += BtnEliminar_Click;
            BtnModificar.Click += BtnModificar_Click;
            Buscar.Click += Buscar_Click;
            LoadData();
            lsData.ItemClick += LsData_ItemClick;
            // Create your application here
        }

        private void LsData_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LoadData()
        {
            LstSource = db.SelectEstudiosXConsulta(Singleton.Instance.IdConsultaactual);
            var adapter = new ListViewAdapterEstudios(this, LstSource);
            lsData.Adapter = adapter;
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Btnagregar_Click(object sender, EventArgs e)
        {
            
        }
    }
}