using AdvisorsThesisSearchApp.Core.Models.AdvisorsThesisSearchApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisorsThesisSearchApp.Core.Data
{
   public class Tablas
    {
        ATSAppDataContext db;
        public Tablas()
        {
            this.db = new ATSAppDataContext();
        }

        public async Task<bool> InsertaRegistrosPersonas()
        {
            var ListaRegistros = new List<Persona>();
            //for (int i = 0; i < 10; i++)
            //{
            ListaRegistros.Add(new Persona() { Id = 1, NombreCompleto = $"Jorge Antonio Zepeda Ramírez", Estatus= (int)EstatusPersona.Activo, TipoPersona= (int)TitpoPersona.Alumno, RutaFoto = $"", Usuario = "jazr", Contrasenna = "jazr" });
            ListaRegistros.Add(new Persona() { Id = 2, NombreCompleto = $"Maria del Carmen", Estatus = (int)EstatusPersona.Activo, TipoPersona = (int)TitpoPersona.Alumno, RutaFoto = $"", Usuario = "maria", Contrasenna = "maria" });
            ListaRegistros.Add(new Persona() { Id = 3, NombreCompleto = $"Juanito Del Carpio", Estatus = (int)EstatusPersona.Activo, TipoPersona = (int)TitpoPersona.Alumno, RutaFoto = $"", Usuario = "juanito", Contrasenna = "juanito" });
            ListaRegistros.Add(new Persona() { Id = 4, NombreCompleto = $"Facundo Lopez", Estatus = (int)EstatusPersona.Activo, TipoPersona = (int)TitpoPersona.Alumno, RutaFoto = $"", Usuario = "facundo", Contrasenna = "facundo" });
            //}

            var insercion = await this.db.InsertaPersonas(ListaRegistros);
            return true;
        }


        public async Task<bool> InsertaRegistrosSolicitudes()
        {
            var ListaRegistros = new List<Solicitud>();
            //for (int i = 0; i < 10; i++)
            //{
            ListaRegistros.Add(new Solicitud() { Id = 1, IdUsuario =12, IdAsesor = 12, Descripcion ="Descrpcion", TituloTesis = $"Titulo" });
            //}

            var insercion = await this.db.InsertaSolicitudes(ListaRegistros);
            return true;
        }


        public async Task<List<Persona>> ObtieneListaPersona()
        {
            return await this.db.GetAllAsync<Persona>();
        }
    }
}
