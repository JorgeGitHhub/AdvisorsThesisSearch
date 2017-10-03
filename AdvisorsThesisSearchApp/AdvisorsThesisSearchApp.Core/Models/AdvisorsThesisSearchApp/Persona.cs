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
    [Table("Personas")]
    public class Persona : INotifyPropertyChanged
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

        private string nombreCompleto;
        /// <summary>
        /// Obtiene o asigna el nombre del cliente
        /// </summary>
        public string NombreCompleto { get { return nombreCompleto; } set { Set(ref nombreCompleto, value); } }

        private string rutaFoto;
        /// <summary>
        /// Obtiene o asigna la dirección del cliente
        /// </summary>
        public string RutaFoto { get { return rutaFoto; } set { Set(ref rutaFoto, value); } }

        private string usuario;
        /// <summary>
        /// Obtiene o asigna el teléfono del cliente
        /// </summary>
        public string Usuario { get { return usuario; } set { Set(ref usuario, value); } }

        private string contrasenna;
        /// <summary>
        /// Obtiene o asigna el teléfono del cliente
        /// </summary>
        public string Contrasenna { get { return contrasenna; } set { Set(ref contrasenna, value); } }


        private int tipoPersona;
        /// <summary>
        /// Obtiene o asigna el teléfono del cliente
        /// </summary>
        public int TipoPersona { get { return tipoPersona; } set { Set(ref tipoPersona, value); } }


        private int estatus;
        /// <summary>
        /// Obtiene o asigna el teléfono del cliente
        /// </summary>
        public int Estatus { get { return estatus; } set { Set(ref estatus, value); } }


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        void Set<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            field = newValue;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }



    public enum TitpoPersona
    {
        Administrador = 0,
        Alumno = 1,
        Asesor = 2
    }

    public enum EstatusPersona
    {
        Activo = 1,
        Inactivo = 2
    }
}
