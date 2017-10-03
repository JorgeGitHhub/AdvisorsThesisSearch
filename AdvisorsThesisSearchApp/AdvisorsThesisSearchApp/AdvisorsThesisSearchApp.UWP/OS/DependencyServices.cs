using AdvisorsThesisSearchApp.Core.OS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;

namespace AdvisorsThesisSearchApp.UWP.OS
{
    public class DependencyServices : IOS
    {
        public SQLiteConnection ObtenerConexionDeBaseDatos(string nombreBD) => new SQLiteConnection(Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, $"{nombreBD}.db3"));


        public SQLiteAsyncConnection ObtenerConexionDeBaseDatosAsync(string nombreBD) => new SQLiteAsyncConnection(Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, $"{nombreBD}.db3"));

        
        public string ObtieneRutaDeBaseDatos(string nombreBD) => Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, $"{nombreBD}.db3");
    }
}
