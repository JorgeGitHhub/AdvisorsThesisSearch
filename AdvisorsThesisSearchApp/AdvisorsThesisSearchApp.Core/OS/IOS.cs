using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisorsThesisSearchApp.Core.OS
{
    public interface IOS
    {
        string ObtieneRutaDeBaseDatos(string nombreBD);

        /// <summary>
        /// Obtiene la conexión a la base de datos en modo sincrono
        /// </summary>
        /// <param name="nombreBD">Nombre de la base de datos</param>
        /// <returns>Conexión de la base de datos</returns>
        SQLiteConnection ObtenerConexionDeBaseDatos(string nombreBD);

        /// <summary>
        /// Obtiene la conexión a la base de datos en modo asincrono
        /// </summary>
        /// <param name="nombreBD">Nombre de la base de datos</param>
        /// <returns>Conexión de la base de datos</returns>
        SQLiteAsyncConnection ObtenerConexionDeBaseDatosAsync(string nombreBD);
    }
}
