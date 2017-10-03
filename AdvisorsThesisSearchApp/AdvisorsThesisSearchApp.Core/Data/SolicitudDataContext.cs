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
        public List<Solicitud> ObtenerSolicitudesQuery()
        {
            return Query<Solicitud>("Select Id, IdUsuario, IdAsesor, Descripcion, TituloTesis, AreaEspecializa, Estatus From Solicitudes");
        }

        /// <summary>
        /// Obtiene los productos de la base de datos local de manera sincrona
        /// </summary>
        /// <returns>Lista de productos</returns>
        public List<Solicitud> ObtenerSolicitudByEstatusQuery(int idEstatusSolicitud)
        {
            StringBuilder query = new StringBuilder();
            query.Append("Select Id, IdUsuario, IdAsesor, Descripcion, TituloTesis, AreaEspecializa, Estatus From Solicitudes ");
            query.Append("Where Estatus = ?");
            var productos = Query<Solicitud>(query.ToString(), idEstatusSolicitud);
            return productos.ToList();
        }

        /// <summary>
        /// Obtiene un producto a partir del identificador dado usando T-SQL de manera sincrona
        /// </summary>
        /// <param name="id">Identificador del producto</param>
        /// <returns>Lista de productos encontrados</returns>
        public List<Solicitud> ObtenerSolicitudesPorIdQuery(int id)
        {
            StringBuilder query = new StringBuilder();
            query.Append("Select Id, IdUsuario, IdAsesor, Descripcion, TituloTesis, AreaEspecializa, Estatus From Solicitudes ");
            query.Append("Where Id = ?");
            var productos = Query<Solicitud>(query.ToString(), id);
            return productos.ToList();
        }

        /// <summary>
        /// Guarda la información del producto en la base de datos local usando T-SQL de manera sincrona
        /// </summary>
        /// <param name="Solicitud">Entidad del producto</param>
        /// <returns>True si es exitoso, sino False</returns>
        public bool GuardarSolicitudesQuery(Solicitud Solicitud)
        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT OR REPLACE INTO Solicitudes");
            query.Append("Id, IdUsuario, IdAsesor, Descripcion, TituloTesis, AreaEspecializa, Estatus) ");
            query.Append("VALUES (?, ?, ?, ?,?,?,?)");
            Exception error = null;
            var resultado = Execute(query.ToString(), (args) =>
            {
                error = args;
            }, Solicitud.Id, Solicitud.IdUsuario, Solicitud.IdAsesor, Solicitud.Descripcion, Solicitud.TituloTesis, Solicitud.AreaEspecializa,Solicitud.Estatus);
            return resultado > 0;
        }

        /// <summary>
        /// Elimina un producto a partir del identificador dado de la base dados local usando T-SQL de manera sincrona
        /// </summary>
        /// <param name="id">Identificador del producto</param>
        /// <returns>True si es exitoso, sino False</returns>
        public bool EliminarSolicitudQuery(int id)
        {
            StringBuilder query = new StringBuilder();
            query.Append("DELETE FROM Solicitudes ");
            query.Append("Where Id = ?");
            var resultado = Execute(query.ToString(), id);
            return resultado > 0;
        }
        #endregion
        /// <summary>
        /// Obtiene los productos de la base de datos local de manera asincrona
        /// </summary>
        /// <returns>Lista de productos</returns>
        public async Task<List<Persona>> ObtenerSolicitudQueryAsync()
        {
            var solicitud = await QueryAsync<Persona>("Select Id, IdUsuario, IdAsesor, Descripcion, TituloTesis, AreaEspecializa, Estatus From Solicitudes").ConfigureAwait(false);
            return solicitud;
        }

        /// <summary>
        /// Obtiene un producto a partir del identificador dado usando T-SQL de manera asincrona
        /// </summary>
        /// <param name="id">Identificador del producto</param>
        /// <returns>Lista de productos encontrados</returns>
        public async Task<List<Solicitud>> ObtenerSolicitudPorIdQueryAsync(int id)
        {
            StringBuilder query = new StringBuilder();
            query.Append("Select Id, IdUsuario, IdAsesor, Descripcion, TituloTesis, AreaEspecializa, Estatus From Solicitudes ");
            query.Append("Where Id = ?");
            var solicitud = await QueryAsync<Solicitud>(query.ToString(), id).ConfigureAwait(false);
            return solicitud;
        }

        /// <summary>
        /// Guarda la información del producto en la base de datos local usando T-SQL de manera asincrona
        /// </summary>
        /// <param name="solicitud">Entidad del producto</param>
        /// <returns>True si es exitoso, sino False</returns>
        public async Task<bool> GuardarSolicitudQueryAsync(Solicitud solicitud)
        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT OR REPLACE INTO Solicitudes");
            query.Append("(Id, IdUsuario, IdAsesor, Descripcion, TituloTesis, AreaEspecializa, Estatus) ");
            query.Append("VALUES (?, ?, ?, ?,?,?,?)");
            Exception error = null;
            var resultado = await ExecuteAsync(query.ToString(), (args) =>
            {
                error = args;
            }, solicitud.Id, solicitud.IdUsuario, solicitud.IdAsesor, solicitud.Descripcion, solicitud.TituloTesis, solicitud.AreaEspecializa, solicitud.Estatus).ConfigureAwait(false);
            return resultado > 0 && error == null;
        }

        /// <summary>
        /// Elimina un producto a partir del identificador dado de la base dados local usando T-SQL de manera asincrona
        /// </summary>
        /// <param name="id">Identificador del producto</param>
        /// <returns>True si es exitoso, sino False</returns>
        public async Task<bool> EliminarSolicitudQueryAsync(int id)
        {
            StringBuilder query = new StringBuilder();
            query.Append("DELETE FROM Solicitudes ");
            query.Append("Where Id = ?");
            var resultado = await ExecuteAsync(query.ToString(), id).ConfigureAwait(false);
            return resultado > 0;
        }

    }
}
