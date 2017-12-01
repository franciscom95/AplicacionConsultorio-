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
using Android.Util;

namespace Consultorio
{
  public   class Database
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool createDataBase()
        {
            try
            {
                using (var conecction  = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder,"AndroidConsultorioDos.db")))
                {


                    /*Crear las tablas Locales*/
                    conecction.CreateTable<Usuario>();
                    conecction.CreateTable<Doctor>();
                    conecction.CreateTable<Paciente>();
                    conecction.CreateTable<PacienteConsulta>();
                    conecction.CreateTable<Estudios>();
                    //Consultorio.Usuario Usuario = new Consultorio.Usuario
                    //{

                    //    Nombre = "Ivan"
                    //    ,User = "Admin"
                    //    ,Contraseña = "p81bg8f7"
                    //};

                    //conecction.Insert(Usuario);



                    return true;
                }
            }
            catch   (SQLite.SQLiteException ex)
            {

                Log.Info("SQLiteEx",ex.Message);
                return false;
            }
        }

        #region Usuario

        public bool InsertIntoUser(Usuario usuario)
        {

            try
            {
                using (var conecction = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "AndroidConsultorioDos.db")))
                {
                    conecction.Insert(usuario);
                    return true;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }


        }
        public List<Usuario> SelectUsuario()
        {

            try
            {
                using (var conecction = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "AndroidConsultorioDos.db")))
                {

                    return conecction.Table<Usuario>().ToList();
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }


        }
        public bool UpdateUser(Usuario usuario)
        {

            try
            {
                using (var conecction = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "AndroidConsultorioDos.db")))
                {
                    conecction.Query<Usuario>("UPDATE Usuario set User=? ,Contraseña=?,Nombre=? Where  Id=?", usuario.User, usuario.Contraseña, usuario.Nombre, usuario.Id);
                    return true;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }


        }
        public bool DeleteUser(Usuario usuario)
        {

            try
            {
                using (var conecction = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "AndroidConsultorioDos.db")))
                {
                    conecction.Delete(usuario);
                    return true;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }


        }
        public bool SelectUser(int id)
        {

            try
            {
                using (var conecction = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "AndroidConsultorioDos.db")))
                {
                    conecction.Query<Usuario>("Select * FROM Usuario Where  Id=?", id);
                    return true;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }


        }
        #endregion
        
        #region Doctor
        public bool InsertIntoDoctor(Doctor Doctor)
        {

            try
            {
                using (var conecction = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "AndroidConsultorioDos.db")))
                {
                    conecction.Insert(Doctor);
                    return true;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }


        }
        public List<Doctor> SelectDoctor()
        {

            try
            {
                using (var conecction = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "AndroidConsultorioDos.db")))
                {

                    return conecction.Table<Doctor>().ToList();
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }


        }
        public bool UpdateDoctor(Doctor Doctor)
        {

            try
            {
                using (var conecction = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "AndroidConsultorioDos.db")))
                {
                    conecction.Query<Doctor>("UPDATE Doctor set NombreDoctor=? ,Email=?,Telefono=? Where  IdDoctor=?", Doctor.NombreDoctor, Doctor.Email, Doctor.Telefono, Doctor.IdDoctor);
                    return true;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }


        }
        public bool DeleteDoctor(Doctor Doctor)
        {

            try
            {
                using (var conecction = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "AndroidConsultorioDos.db")))
                {
                    conecction.Delete(Doctor);
                    return true;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }


        }
        public bool SelectDoctor(int id)
        {

            try
            {
                using (var conecction = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "AndroidConsultorioDos.db")))
                {
                    conecction.Query<Doctor>("Select * FROM Doctor Where  IdDoctor=?", id);
                    return true;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }


        }
        #endregion
                
        #region Paciente
        public bool InsertIntopaciente(Paciente Paciente)
        {

            try
            {
                using (var conecction = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "AndroidConsultorioDos.db")))
                {
                    conecction.Insert(Paciente);
                    return true;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }


        }
        public List<Paciente> SelectPaciente()
        {

            try
            {
                using (var conecction = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "AndroidConsultorioDos.db")))
                {

                    return conecction.Table<Paciente>().ToList();
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }


        }
        public bool Updatepaciente(Paciente Paciente)
        { 
            
 

            try
            {
                using (var conecction = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "AndroidConsultorioDos.db")))
                {
                    conecction.Query<Paciente>("UPDATE Paciente set NomPaciente=? ,Email=?,Telefono=?,FechaNacimiento=?,Alergias=?,MedicamentosNoPermitidos=?,EnfermedadesCronicas=?,Sexo=?,Ocupacion=?,NumeroEmergencia=? ,Religion=?,Domicilio=? Where  IdPaciente=?"
                    , Paciente.NomPaciente, Paciente.Email, Paciente.Telefono, Paciente.FechaNacimiento,Paciente.Alergias,Paciente.MedicamentosNoPermitidos,Paciente.EnfermedadesCronicas,Paciente.Sexo,Paciente.Ocupacion,Paciente.NumeroEmergencia,Paciente.Religion,Paciente.Domicilio,Paciente.IdPaciente);
                    return true;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }


        }
        public bool Deletepaciente(Paciente Paciente)
        {

            try
            {
                using (var conecction = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "AndroidConsultorioDos.db")))
                {
                    conecction.Delete(Paciente);
                    return true;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }


        }
        public bool Selectpaciente(int id)
        {

            try
            {
                using (var conecction = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "AndroidConsultorioDos.db")))
                {
                    conecction.Query<Paciente>("Select * FROM Paciente Where  IdPaciente=?", id);
                    return true;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }


        }
        #endregion

        #region PacienteConsulta
        public bool InsertIntopacienteConsulta(PacienteConsulta pacienteconsulta)
        {

            try
            {
                using (var conecction = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "AndroidConsultorioDos.db")))
                {
                    conecction.Insert(pacienteconsulta);
                    return true;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }


        }
        public List<PacienteConsulta> SelectpacienteConsulta()
        {

            try
            {
                using (var conecction = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "AndroidConsultorioDos.db")))
                {

                    return conecction.Table<PacienteConsulta>().Where(x=>x.IdPaciente == Singleton.Instance.actualpaciente).ToList();
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }


        }
        public bool UpdatepacienteConsultaConsultaConsulta(PacienteConsulta pacienteConsulta)
        {

            try
            {
                using (var conecction = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "AndroidConsultorioDos.db")))
                {
                    conecction.Query<PacienteConsulta>("UPDATE PacienteConsulta set  PresionArterial =?, Estatura =?,PesoCorporal =?, MotivoConsulta =?, Diagnostico =?, Medicamento =?, Indicadiones =?, EsCumplio =? Where  IdPacienteConsulta=?", pacienteConsulta.PresionArterial, pacienteConsulta.Estatura , pacienteConsulta.PesoCorporal , pacienteConsulta.MotivoConsulta , pacienteConsulta.Diagnostico , pacienteConsulta.Medicamento, pacienteConsulta.Indicadiones , pacienteConsulta.FechaConsulta, pacienteConsulta.EsCumplio, pacienteConsulta.IdPacienteConsulta);
                    return true;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }


        }
        public bool DeletepacienteConsulta(PacienteConsulta pacienteconuslta)
        {

            try
            {
                using (var conecction = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "AndroidConsultorioDos.db")))
                {
                    conecction.Delete(pacienteconuslta);
                    return true;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }


        }
        public List<PacienteConsulta> SelectConsultasXPaciente(int id)
        {

            try
            {
                using (var conecction = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "AndroidConsultorioDos.db")))
                {

                   return  conecction.Query<PacienteConsulta>("Select * FROM PacienteConsulta Where  IdPaciente=?", id).ToList();
                     
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }


        }
        #endregion

        #region Estudios
        public bool InsertIntoEstudios(Estudios estudio)
        {

            try
            {
                using (var conecction = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "AndroidConsultorioDos.db")))
                {
                    conecction.Insert(estudio);
                    return true;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }


        }
        public List<Estudios> SelectEstudioPaciente()
        {

            try
            {
                using (var conecction = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "AndroidConsultorioDos.db")))
                {

                    return conecction.Table<Estudios>().ToList();
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }


        }
        public bool UpdateEstudioPactiente(Estudios estudios)
        {

            try
            {
                using (var conecction = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "AndroidConsultorioDos.db")))
                {
                    conecction.Query<PacienteConsulta>("UPDATE Estudios set  NomEstudio =?, EsRealizado =?,FechaARealizar =?, Resultados =?  where IdEstudio=?", estudios.IdEstudio, estudios.NomEstudio, estudios.EsRealizado,estudios.FechaARealizar,estudios.Resultados,estudios.IdEstudio);
                    return true;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }


        }
        public bool DeleteEstudio(Estudios estudio)
        {

            try
            {
                using (var conecction = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "AndroidConsultorioDos.db")))
                {
                    conecction.Delete(estudio);
                    return true;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }


        }
        public bool SelectEstudio(int id)
        {

            try
            {
                using (var conecction = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "AndroidConsultorioDos.db")))
                {
                    conecction.Query<PacienteConsulta>("Select * FROM Estudios Where  IdEstudio=?", id);
                    return true;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }


        }


        public List<Estudios> SelectEstudiosXConsulta(int id)
        {

            try
            {
                using (var conecction = new SQLite.SQLiteConnection(System.IO.Path.Combine(folder, "AndroidConsultorioDos.db")))
                {

                    return conecction.Query<Estudios>("Select * FROM Estudios Where  IdConsulta =?", id).ToList();

                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }


        }
        #endregion
    }
}