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
    [Activity(Label = "Consultas del Paciente")]
    public class PacienteConsultaListas : Activity
    {
        #region Propertys
        ListView lsData;

        #endregion
        List<PacienteConsulta> LstSource = new List<PacienteConsulta>();
        Database db;
        Button Btnagregar = null, btnAgregarEstudio = null, BtnModificar = null, Buscar = null;
        int idpaciente = 0,idconsulta;
        EditText PresionArterial = null,Estatura = null, PesoCorporal = null, MotivoConsulta = null, Diagnostico = null, Medicamento = null, Indicadiones = null,txtfechabuscar = null;
        DatePicker FechaConsulta = null;
        CheckBox EsCumplio = null;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            


            /*Obtener Actual*/
            idpaciente = Singleton.Instance.actualpaciente;
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Consultas);
            lsData = FindViewById<ListView>(Resource.Id.ListViewConsultas);
            db = new Database();
            Btnagregar = FindViewById<Button>(Resource.Id.BtnAgregaraddConsulta);
            btnAgregarEstudio = FindViewById<Button>(Resource.Id.BtnAgregarEstudio);
            BtnModificar = FindViewById<Button>(Resource.Id.btnEditarConsulta);
            Buscar = FindViewById<Button>(Resource.Id.BuscaConsulta);
            #region Bildear

            PresionArterial = FindViewById<EditText>(Resource.Id.txtPresionArterial);
            Estatura = FindViewById<EditText>(Resource.Id.txtEstatura);
            PesoCorporal = FindViewById<EditText>(Resource.Id.txtPesoCorporal);
            MotivoConsulta = FindViewById<EditText>(Resource.Id.txtMotivoConsulta);
            Diagnostico = FindViewById<EditText>(Resource.Id.txtDiagnostico);
            Medicamento = FindViewById<EditText>(Resource.Id.txtMedicamento);
            Indicadiones = FindViewById<EditText>(Resource.Id.txtIndicadiones);

            EsCumplio = FindViewById<CheckBox>(Resource.Id.checkBox1);
            FechaConsulta = FindViewById<DatePicker>(Resource.Id.datePicker1);

            #endregion
            txtfechabuscar = FindViewById<EditText>(Resource.Id.txtBuscarConsulta);
            Btnagregar.Click += Btnagregar_Click ;
            btnAgregarEstudio.Click += BtnAgregarEstudio_Click; ;
            BtnModificar.Click += BtnModificar_Click;
            Buscar.Click += Buscar_Click;
            LoadData();
            lsData.ItemClick += LsData_ItemClick;
        }

        private void BtnAgregarEstudio_Click(object sender, EventArgs e)
        {
            Singleton.Instance.IdConsultaactual = idconsulta;
            StartActivity(typeof(ListadoEstudios));

        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            if (txtfechabuscar.Text.Length == 0)
            {
                LoadData();
            }
            else
            {
                LstSource = LstSource.Where(x => x.FechaConsulta.Contains(txtfechabuscar.Text)).ToList();
                var adapter = new ListViewAdapterConsultas(this, LstSource);
                lsData.Adapter = adapter;
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (idconsulta == 0)
            {
                Toast toast = Toast.MakeText(this, "No Tiene un elemento seleccionado", ToastLength.Short);
                toast.Show();
            }
            else
            {

                if (PresionArterial.Text.Length <= 0
              || Estatura.Text.Length <= 0
              || Medicamento.Text.Length <= 0
              || MotivoConsulta.Text.Length <= 0
              || Diagnostico.Text.Length <= 0
              || Indicadiones.Text.Length <= 0
              || PesoCorporal.Text.Length <= 0

              )
                {
                    Toast toast = Toast.MakeText(this, "Llena todos los campos", ToastLength.Short);
                    toast.Show();


                }
                else { 
                db.UpdatepacienteConsultaConsultaConsulta(new PacienteConsulta
                {
                    PresionArterial = Convert.ToDecimal(PresionArterial.Text),
                    Estatura = Convert.ToDecimal(PresionArterial.Text),
                    Medicamento = Medicamento.Text,
                    Diagnostico = Diagnostico.Text,
                    MotivoConsulta = MotivoConsulta.Text,
                    FechaConsulta = FechaConsulta.DayOfMonth.ToString() + "/" + FechaConsulta.Month.ToString() + "/" + FechaConsulta.Year.ToString(),
                    EsCumplio =   EsCumplio.Checked == true ? "Si" : "No"
                    ,Indicadiones = Indicadiones.Text
                    ,PesoCorporal = Convert.ToDecimal(PesoCorporal.Text)
                    
                   
                   
                
                });
                LimpiarControles();
                LoadData();
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (idconsulta == 0)
            {
                Toast toast = Toast.MakeText(this, "No Tiene un elemento seleccionado", ToastLength.Short);
                toast.Show();
            }
            else
            {
                db.DeletepacienteConsulta(new PacienteConsulta { IdPacienteConsulta = idconsulta });
                LoadData();
            }
        }

        private void LsData_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            PresionArterial.Text = LstSource[e.Position].PresionArterial.ToString();
            Estatura.Text = LstSource[e.Position].Estatura.ToString();
            PesoCorporal.Text = LstSource[e.Position].PesoCorporal.ToString();
            idconsulta = LstSource[e.Position].IdPacienteConsulta;
            MotivoConsulta.Text = LstSource[e.Position].MotivoConsulta;
            Diagnostico.Text = LstSource[e.Position].Diagnostico;
            Medicamento.Text = LstSource[e.Position].Medicamento;
            EsCumplio.Checked = LstSource[e.Position].EsCumplio == "Si" ? true : false;            
            Indicadiones.Text = LstSource[e.Position].Indicadiones;
            


        }

        private void Btnagregar_Click(object sender, EventArgs e)
        {

            if (PresionArterial.Text.Length <= 0
                || Estatura.Text.Length <= 0
                || Medicamento.Text.Length <= 0
                || MotivoConsulta.Text.Length <= 0
                || Diagnostico.Text.Length <= 0
                || Indicadiones.Text.Length <= 0
                || PesoCorporal.Text.Length <= 0
               
                )
            {
                Toast toast = Toast.MakeText(this, "Llena todos los campos", ToastLength.Short);
                toast.Show();


            }
            else {
                PacienteConsulta pac = new Consultorio.PacienteConsulta
                {
                    PresionArterial = Convert.ToDecimal(PresionArterial.Text),
                    Estatura = Convert.ToDecimal(Estatura.Text),
                    Medicamento = Medicamento.Text,
                    Diagnostico = Diagnostico.Text,
                    MotivoConsulta = MotivoConsulta.Text,
                    FechaConsulta = FechaConsulta.DayOfMonth.ToString()+"/" + FechaConsulta.Month.ToString()+"/" + FechaConsulta.Year.ToString(),
                    EsCumplio = EsCumplio.Checked == true ? "Si" : "No",
                    Indicadiones = Indicadiones.Text,
                    PesoCorporal = Convert.ToDecimal(PesoCorporal.Text),
                    IdPaciente = idpaciente
               
            };
            db.InsertIntopacienteConsulta(pac);
            LimpiarControles();
            LoadData();
            }
        }

        private void LimpiarControles()
        {
            PresionArterial.Text = string.Empty;
            PresionArterial.Text = string.Empty;
            Medicamento.Text = string.Empty;
            Diagnostico.Text = string.Empty;
            MotivoConsulta.Text = string.Empty;
            EsCumplio.Checked = false;
            Indicadiones.Text = string.Empty;
            PesoCorporal.Text = string.Empty;


        }

        private void LoadData()
        {
            LstSource = db.SelectConsultasXPaciente(idpaciente);
            var adapter = new ListViewAdapterConsultas(this, LstSource);
            lsData.Adapter = adapter;
        }

    }
}