using AdvisorsThesisSearchApp.Core.Models.AdvisorsThesisSearchApp;
using AdvisorsThesisSearchApp.Core.OS;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdvisorsThesisSearchApp.Core.Data
{
    public partial class ATSAppDataContext : SQLiteDataContext
    {

        /// <summary>
        /// Constructor de la clase DataContext, donde se crean las tablas en la base de datos
        /// </summary>
        public ATSAppDataContext()
        {
            CreateTablesAsync();
        }


        protected override SQLiteConnection db =>
            DependencyService.Get<IOS>().ObtenerConexionDeBaseDatos(this.NombreBD);

        protected override SQLiteAsyncConnection dbAsync =>
            DependencyService.Get<IOS>().ObtenerConexionDeBaseDatosAsync(this.NombreBD);

        protected override string NombreBD => "Equipo2";

        protected override void CreateTables()
        {
            this.db.CreateTable<Persona>();
        }

        protected override void CreateTablesAsync()
        {
            this.dbAsync.CreateTableAsync<Persona>();
            this.dbAsync.CreateTableAsync<Solicitud>();
        }


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        void Set<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            field = newValue;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion



        public async Task<bool> InsertaPersonas(List<Persona> listaPersonas)
        {
            try
            {
                foreach (var persona in listaPersonas)
                {
                    var query = @"INSERT OR REPLACE INTO Personas (Id,NombreCompleto,RutaFoto,TipoPersona,Estatus,Usuario,Contrasenna)
                                VALUES(?,?,?,?,?,?,?)";
                    var cmd = await ExecuteAsync(query, persona.Id, persona.NombreCompleto, persona.RutaFoto,persona.TipoPersona, persona.Estatus, persona.Usuario, persona.Contrasenna);
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task<bool> InsertaSolicitudes(List<Solicitud> listaPersonas)
        {
            try
            {
                foreach (var persona in listaPersonas)
                {
                    var query = @"INSERT OR REPLACE INTO Solicitudes (Id,idUsuario,idAsesor,Descripcion,Titulo)
                                VALUES(?,?,?,?,?,?,?)";
                    var cmd = await ExecuteAsync(query, persona.Id, persona.IdUsuario, persona.IdAsesor, persona.Descripcion, persona.TituloTesis);
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public async Task<bool> EliminaPersona(int idPersona)
        //{
        //    try
        //    {
        //        var eliminado = await dbAsync.Table<Persona>()
        //            .Where(x => x.Id == idPersona).FirstOrDefaultAsync();
        //        if (eliminado != null)
        //        {
        //            return (await dbAsync.DeleteAsync(eliminado) == 1);
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}



    }
}
