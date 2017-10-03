using AdvisorsThesisSearchApp.Core.Models.AdvisorsThesisSearchApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisorsThesisSearchApp.Core.Data
{
    public partial class ATSAppDataContext 
    {
        #region Sync
        /// <summary>
        /// Obtiene los productos de la base de datos local de manera sincrona
        /// </summary>
        /// <returns>Lista de productos</returns>
        public List<Persona> ObtenerPersonasQuery()
        {
            return Query<Persona>("Select Id, NombreCompleto, RutaFoto, Usuario, Contrasenna, Tipopersona,Estatus From Personas");
        }

        /// <summary>
        /// Obtiene los productos de la base de datos local de manera sincrona
        /// </summary>
        /// <returns>Lista de personas dependiendo el tipo</returns>
        public List<Persona> ObtenerPersonaByTipoPersonaQuery(int idTipopersona)
        {
            StringBuilder query = new StringBuilder();
            query.Append("Select Id, NombreCompleto, RutaFoto, Usuario, Contrasenna, Tipopersona,Estatus From Personas ");
            query.Append("Where TipoPersona = ?");
            var personas = Query<Persona>(query.ToString(), idTipopersona);
            return personas.ToList();
        }


        /// <summary>
        /// Obtiene los productos de la base de datos local de manera sincrona
        /// </summary>
        /// <returns>Lista de personas dependiendo el estatus</returns>
        public List<Persona> ObtenerPersonaByEstatusQuery(int idEstatus)
        {
            StringBuilder query = new StringBuilder();
            query.Append("Select Id, NombreCompleto, RutaFoto, Usuario, Contrasenna, Tipopersona,Estatus From Personas ");
            query.Append("Where Estatus = ?");
            var personas = Query<Persona>(query.ToString(), idEstatus);
            return personas.ToList();
        }


        /// <summary>
        /// Obtiene un producto a partir del identificador dado usando T-SQL de manera sincrona
        /// </summary>
        /// <param name="id">Identificador del producto</param>
        /// <returns>Lista de productos encontrados</returns>
        public List<Persona> ObtenerPersonasPorIdQuery(int id)
        {
            StringBuilder query = new StringBuilder();
            query.Append("Select Id, NombreCompleto, RutaFoto, Usuario, Contrasenna, Tipopersona,Estatus From Personas ");
            query.Append("Where Id = ?");
            var personas = Query<Persona>(query.ToString(), id);
            return personas.ToList();
        }

        /// <summary>
        /// Guarda la información del producto en la base de datos local usando T-SQL de manera sincrona
        /// </summary>
        /// <param name="persona">Entidad del producto</param>
        /// <returns>True si es exitoso, sino False</returns>
        public bool GuardarPersonasQuery(Persona persona)
        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT OR REPLACE INTO Personas");
            query.Append("(Id, NombreCompleto, RutaFoto, Usuario, Contrasenna, Tipopersona,Estatus) ");
            query.Append("VALUES (?, ?, ?, ?,?,?,?)");
            Exception error = null;
            var resultado = Execute(query.ToString(), (args) =>
            {
                error = args;
            }, persona.Id, persona.NombreCompleto, persona.RutaFoto, persona.Usuario, persona.Contrasenna, persona.TipoPersona);
            return resultado > 0;
        }

        /// <summary>
        /// Elimina un producto a partir del identificador dado de la base dados local usando T-SQL de manera sincrona
        /// </summary>
        /// <param name="id">Identificador del producto</param>
        /// <returns>True si es exitoso, sino False</returns>
        public bool EliminarPersonasQuery(int id)
        {
            StringBuilder query = new StringBuilder();
            query.Append("DELETE FROM Personas ");
            query.Append("Where Id = ?");
            var resultado = Execute(query.ToString(), id);
            return resultado > 0;
        }
        #endregion

        #region Async
        /// <summary>
        /// Obtiene los productos de la base de datos local de manera asincrona
        /// </summary>
        /// <returns>Lista de productos</returns>
        public async Task<List<Persona>> ObtenerPersonasQueryAsync()
        {
            var personas = await QueryAsync<Persona>("Select Id, NombreCompleto, RutaFoto, Usuario, Contrasenna, Tipopersona,Estatus From Personas").ConfigureAwait(false);
            return personas;
        }

        /// <summary>
        /// Obtiene los productos de la base de datos local de manera sincrona
        /// </summary>
        /// <returns>Lista de personas dependiendo el tipo</returns>
        public async Task<List<Persona>> ObtenerPersonaByTipoPersonaQueryAsync(int idTipopersona)
        {
            StringBuilder query = new StringBuilder();
            query.Append("Select Id, NombreCompleto, RutaFoto, Usuario, Contrasenna, Tipopersona,Estatus From Personas ");
            query.Append("Where TipoPersona = ?");
            var personas = await QueryAsync<Persona>(query.ToString(), idTipopersona).ConfigureAwait(false);
            return personas;
        }


        /// <summary>
        /// Obtiene los productos de la base de datos local de manera sincrona
        /// </summary>
        /// <returns>Lista de personas dependiendo el estatus</returns>
        public async Task<List<Persona>> ObtenerPersonaByEstatusQueryAsync(int idEstatus)
        {
            StringBuilder query = new StringBuilder();
            query.Append("Select Id, NombreCompleto, RutaFoto, Usuario, Contrasenna, Tipopersona,Estatus From Personas ");
            query.Append("Where Estatus = ?");
            var personas = await QueryAsync<Persona>(query.ToString(), idEstatus).ConfigureAwait(false);
            return personas;
        }
        /// <summary>
        /// Obtiene un producto a partir del identificador dado usando T-SQL de manera asincrona
        /// </summary>
        /// <param name="id">Identificador del producto</param>
        /// <returns>Lista de productos encontrados</returns>
        public async Task<List<Persona>> ObtenerPersonasPorIdQueryAsync(int id)
        {
            StringBuilder query = new StringBuilder();
            query.Append("Select Id, NombreCompleto, RutaFoto, Usuario, Contrasenna, Tipopersona,Estatus From Personas ");
            query.Append("Where Id = ?");
            var personas = await QueryAsync<Persona>(query.ToString(), id).ConfigureAwait(false);
            return personas;
        }

        /// <summary>
        /// Guarda la información del producto en la base de datos local usando T-SQL de manera asincrona
        /// </summary>
        /// <param name="persona">Entidad del producto</param>
        /// <returns>True si es exitoso, sino False</returns>
        public async Task<bool> GuardarPersonasQueryAsync(Persona persona)
        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT OR REPLACE INTO Personas");
            query.Append("(Id, NombreCompleto, RutaFoto, Usuario, Contrasenna, Tipopersona,Estatus) ");
            query.Append("VALUES (?, ?, ?, ?,?,?,?)");
            Exception error = null;
            var resultado = await ExecuteAsync(query.ToString(), (args) =>
            {
                error = args;
            }, persona.Id, persona.NombreCompleto, persona.RutaFoto, persona.Usuario,persona.Contrasenna, persona.TipoPersona, persona.Estatus).ConfigureAwait(false);
            return resultado > 0 && error == null;
        }

        /// <summary>
        /// Elimina un producto a partir del identificador dado de la base dados local usando T-SQL de manera asincrona
        /// </summary>
        /// <param name="id">Identificador del producto</param>
        /// <returns>True si es exitoso, sino False</returns>
        public async Task<bool> EliminarPersonaQueryAsync(int id)
        {
            StringBuilder query = new StringBuilder();
            query.Append("DELETE FROM Personas ");
            query.Append("Where Id = ?");
            var resultado = await ExecuteAsync(query.ToString(), id).ConfigureAwait(false);
            return resultado > 0;
        }
        #endregion
    }
}
