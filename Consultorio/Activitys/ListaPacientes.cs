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
    [Activity(Label = "Pacientes")]
    public class ListaPacientes : Activity
    {
        #region Propertys
        ListView lsData;

        #endregion
        List<Paciente> LstSource = new List<Paciente>();
        Database db;
        Button Btnagregar = null, BtnEliminar = null, BtnModificar = null, Buscar = null,BtnAgregarConsulta = null;

        int id = 0;

        EditText NomPaciente = null, Email = null, Telefono = null, FechaNacimiento = null, Alergias=null,MedicamentosNoPermitidos=null, EnfermedadesCronicas= null,Sexo = null, Ocupacion = null, NumeroEmergencia = null,txtbuscarPaciente =null,Religion = null,Domicilio=null;

        ScrollView scroll = null;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Pacientes);
            lsData = FindViewById<ListView>(Resource.Id.ListViewPacientes);
            db = new Database();
            Btnagregar = FindViewById<Button>(Resource.Id.btnAgregarPaciente);
            BtnEliminar = FindViewById<Button>(Resource.Id.btnEliminarPacienter);
            BtnModificar = FindViewById<Button>(Resource.Id.btnEditarPaciente);
            Buscar = FindViewById<Button>(Resource.Id.BuscarPaciente);
            BtnAgregarConsulta = FindViewById<Button>(Resource.Id.btnAgregarConsulta);
            #region Bildear
            NomPaciente = FindViewById<EditText>(Resource.Id.TxtNombrePaciente);
            Email = FindViewById<EditText>(Resource.Id.TxtEmailPaciente);
            Telefono = FindViewById<EditText>(Resource.Id.txtTelefonoPaciente);
            FechaNacimiento = FindViewById<EditText>(Resource.Id.txtFechaNacimiento);
            Alergias = FindViewById<EditText>(Resource.Id.TxtalergiasPaciente);
            MedicamentosNoPermitidos = FindViewById<EditText>(Resource.Id.TxtMedicamentosNoPermitidos);
            EnfermedadesCronicas = FindViewById<EditText>(Resource.Id.TXTEnfermedadesCronicas);
            Sexo = FindViewById<EditText>(Resource.Id.txtSexo);
            Ocupacion = FindViewById<EditText>(Resource.Id.TxtOcupacion);
            Religion = FindViewById<EditText>(Resource.Id.TxtReligion);
            Domicilio = FindViewById<EditText>(Resource.Id.TxtDomicilio);
            NumeroEmergencia = FindViewById<EditText>(Resource.Id.TxtNumerodeEmergencia);
              
            scroll = FindViewById<ScrollView>(Resource.Id.ScrollView_Paciente);

            #endregion


            


            txtbuscarPaciente = FindViewById<EditText>(Resource.Id.txtbuscarPaciente);

            Btnagregar.Click += Btnagregar_Click;
            BtnEliminar.Click += BtnEliminar_Click;
            BtnModificar.Click += BtnModificar_Click;
            Buscar.Click += Buscar_Click;
            BtnAgregarConsulta.Click += BtnAgregarConsulta_Click;
            LoadData();
            lsData.ItemClick += LsData_ItemClick;




            //Cuando se activa el textbox
            FechaNacimiento.FocusChange += FechaNacimiento_FocusChange;
        }

        private void FechaNacimiento_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            /*Cuando esta enfocado el de nacimiento voy a desplazar la posicion en +10 */
            scroll.ScrollTo(scroll.ScrollX, 10);
        }

        private void BtnAgregarConsulta_Click(object sender, EventArgs e)
        {
            if(id == 0)
            {
                Toast toast = Toast.MakeText(this, "No Tiene un elemento seleccionado", ToastLength.Short);
                toast.Show();
            }
            else {
                Singleton.Instance.actualpaciente = id;
                id = 0;
                LimpiarControles();
                StartActivity(typeof(Activitys.PacienteConsultaListas));
            }
            
         }

        private void Buscar_Click(object sender, EventArgs e)
        {
            if (txtbuscarPaciente.Text.Length == 0)
            {
                LoadData();
            }
            else
            {
                LstSource = LstSource.Where(x => x.NomPaciente.Contains(txtbuscarPaciente.Text)).ToList();
                var adapter = new ListViewAdapterPaciente(this, LstSource);
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

                if (NomPaciente.Text.Length <= 0
                   || Email.Text.Length <= 0
                   || Telefono.Text.Length <= 0
                   || MedicamentosNoPermitidos.Text.Length <= 0
                   || EnfermedadesCronicas.Text.Length <= 0
                   || Alergias.Text.Length <= 0
                   || Sexo.Text.Length <= 0
                   || NumeroEmergencia.Text.Length <= 0
                   || Ocupacion.Text.Length <= 0
                   || FechaNacimiento.Text.Length <= 0
                   || Religion.Text.Length <= 0
                   || Domicilio.Text.Length <= 0
                   )
                {
                    Toast toast = Toast.MakeText(this, "Llena todos los campos", ToastLength.Short);
                    toast.Show();
                }
                else { 
                db.Updatepaciente(new Paciente { IdPaciente = id,NomPaciente = NomPaciente.Text,Email= Email.Text
                    ,Telefono= Telefono.Text,MedicamentosNoPermitidos=MedicamentosNoPermitidos.Text
                    ,Alergias=Alergias.Text,Sexo=Sexo.Text,NumeroEmergencia=NumeroEmergencia.Text,Ocupacion=Ocupacion.Text
                    ,EnfermedadesCronicas=EnfermedadesCronicas.Text,FechaNacimiento = FechaNacimiento.Text
                    ,Religion = Religion.Text,Domicilio=Domicilio.Text
                });
                LimpiarControles();
                LoadData();
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                Toast toast = Toast.MakeText(this, "No Tiene un elemento seleccionado", ToastLength.Short);
                toast.Show();
            }
            else
            {
                db.Deletepaciente(new Paciente { IdPaciente = id });
                LoadData();
            }
        }

        private void LsData_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            NomPaciente.Text = LstSource[e.Position].NomPaciente;
            Email.Text = LstSource[e.Position].Email;
            Telefono.Text = LstSource[e.Position].Telefono;
            id = LstSource[e.Position].IdPaciente;
            MedicamentosNoPermitidos.Text = LstSource[e.Position].MedicamentosNoPermitidos;
            Alergias.Text = LstSource[e.Position].Alergias;
            Sexo.Text = LstSource[e.Position].Sexo;
            NumeroEmergencia.Text = LstSource[e.Position].NumeroEmergencia;
            Ocupacion.Text = LstSource[e.Position].Ocupacion;
            EnfermedadesCronicas.Text = LstSource[e.Position].EnfermedadesCronicas;
            Religion.Text = LstSource[e.Position].Religion;
            Domicilio.Text = LstSource[e.Position].Domicilio;

        }

        private void Btnagregar_Click(object sender, EventArgs e)
        {


            if(NomPaciente.Text.Length<=0
               || Email.Text.Length <= 0
               || Telefono.Text.Length <= 0
               || MedicamentosNoPermitidos.Text.Length <= 0
               || EnfermedadesCronicas.Text.Length <= 0
               || Alergias.Text.Length <= 0
               || Sexo.Text.Length <= 0
               || NumeroEmergencia.Text.Length <= 0
               || Ocupacion.Text.Length <= 0
               || FechaNacimiento.Text.Length <= 0
               || Religion.Text.Length <= 0
               || Domicilio.Text.Length <= 0
               )
            {
                Toast toast = Toast.MakeText(this, "Llena todos los campos", ToastLength.Short);
                toast.Show();
            }
            else { 

            Paciente pac = new Consultorio.Paciente
            {
                NomPaciente = NomPaciente.Text,
                Email = Email.Text,
                Telefono = Telefono.Text,
                MedicamentosNoPermitidos = MedicamentosNoPermitidos.Text,
                EnfermedadesCronicas = EnfermedadesCronicas.Text,
                Alergias = Alergias.Text,
                Sexo = Sexo.Text,
                NumeroEmergencia = NumeroEmergencia.Text,
                Ocupacion = Ocupacion.Text,
                FechaNacimiento = FechaNacimiento.Text
                ,Religion = Religion.Text
                ,Domicilio = Domicilio.Text
            };
            db.InsertIntopaciente(pac);
            LimpiarControles();
            LoadData();
            }
        }

        private void LimpiarControles()
        {
            id = 0;
            NomPaciente.Text = string.Empty;
            Email.Text = string.Empty;
            Telefono.Text = string.Empty;
            MedicamentosNoPermitidos.Text = string.Empty;
            EnfermedadesCronicas.Text = string.Empty;
            Alergias.Text = string.Empty;
            Sexo.Text = string.Empty;
            NumeroEmergencia.Text = string.Empty;
            Ocupacion.Text = string.Empty;
            FechaNacimiento.Text = string.Empty;
            Religion.Text = string.Empty;
            Domicilio.Text = string.Empty;

        }

        private void LoadData()
        {
            LstSource = db.SelectPaciente();
            var adapter = new ListViewAdapterPaciente(this, LstSource);
            lsData.Adapter = adapter;
        }

    }
}
