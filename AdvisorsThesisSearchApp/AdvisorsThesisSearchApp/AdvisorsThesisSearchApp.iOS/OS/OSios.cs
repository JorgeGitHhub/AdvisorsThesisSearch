using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using AdvisorsThesisSearchApp.Core.OS;
using SQLite;
using System.IO;

namespace AdvisorsThesisSearchApp.iOS.OS
{
    public class OSios : IOS
    {
      
        public SQLiteConnection ObtenerConexionDeBaseDatos(string nombreBD) => new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), $"{nombreBD}.db3"));

        
        public SQLiteAsyncConnection ObtenerConexionDeBaseDatosAsync(string nombreBD) => new SQLiteAsyncConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), $"{nombreBD}.db3"));

       
        public string ObtieneRutaDeBaseDatos(string nombreBD) => System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), $"{nombreBD}.db3");
    }
}