using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdvisorsThesisSearchApp.Core.Models.AdvisorsThesisSearchApp
{
    [Table("Solicitudes")]
    public class Solicitud : INotifyPropertyChanged
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <remarks>
        /// Se inicializan valores predeterminados de propiedades para la entidad
        /// </remarks>
        private int id;
        /// <summary>
        /// Obtiene o asigna el identificador del registro
        /// </summary>
        /// <remarks>
        /// Es marcado como llave primaria y autoincrementable
        /// </remarks>
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get { return id; } set { Set(ref id, value); } }

        private int idUsuario;
        /// <summary>
        /// Obtiene o asigna el nombre del cliente
        /// </summary>
        public int IdUsuario { get { return idUsuario; } set { Set(ref idUsuario, value); } }

        private int idAsesor;
        /// <summary>
        /// Obtiene o asigna el nombre del cliente
        /// </summary>
        public int IdAsesor { get { return idAsesor; } set { Set(ref idAsesor, value); } }

        private string descripcion;
        /// <summary>
        /// Obtiene o asigna el teléfono del cliente
        /// </summary>
        public string Descripcion { get { return descripcion; } set { Set(ref descripcion, value); } }

        private string tituloTesis;
        /// <summary>
        /// Obtiene o asigna el teléfono del cliente
        /// </summary>
        public string TituloTesis { get { return tituloTesis; } set { Set(ref tituloTesis, value); } }

        private string areaEspecializa;
        /// <summary>
        /// Obtiene o asigna el teléfono del cliente
        /// </summary>
        public string AreaEspecializa { get { return areaEspecializa; } set { Set(ref areaEspecializa, value); } }


        private string estatus;
        /// <summary>
        /// Obtiene o asigna el teléfono del cliente
        /// </summary>
        public string Estatus { get { return estatus; } set { Set(ref estatus, value); } }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        void Set<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            field = newValue;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

    public enum EstatusSolicitud
    {
        Aceptada = 1,
        Rechazada = 2
    }
}