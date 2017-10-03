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
using AdvisorsThesisSearchApp.Core.OS;
using SQLite;
using System.IO;

namespace AdvisorsThesisSearchApp.Droid.OS
{
    public class OSAndroid : IOS
    {
        
        public SQLiteConnection ObtenerConexionDeBaseDatos(string nombreBD) => new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), $"{nombreBD}.db3"));

        
        public SQLiteAsyncConnection ObtenerConexionDeBaseDatosAsync(string nombreBD) => new SQLiteAsyncConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), $"{nombreBD}.db3"));

        
        public string ObtieneRutaDeBaseDatos(string nombreBD) => System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), $"{nombreBD}.db3");
    }
}