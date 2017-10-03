using AdvisorsThesisSearchApp.Core.Data;
using AdvisorsThesisSearchApp.Core.Models.AdvisorsThesisSearchApp;
using AdvisorsThesisSearchApp.Core.OS;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisorsThesisSearchApp.Core.ViewModels
{
    public class MainViewModel: ViewModelBase
    {

        private ATSAppDataContext _dtx;
        /// <summary>
        /// Obtiene la instancia del datacontext
        /// </summary>
        private ATSAppDataContext dtx
        {
            get { return _dtx ?? (_dtx = new ATSAppDataContext()); }
        }

        private ObservableCollection<Persona> personas;
        /// <summary>
        /// Obtiene o asigna la lista de productos cargados
        /// </summary>
        public ObservableCollection<Persona> Personas { get { return personas; } set { Set(ref personas, value); } }

        private Persona personaSeleccionado;
        /// <summary>
        /// Obtiene o asigna el producto seleccionado
        /// </summary>
        public Persona PersonaSeleccionado
        {
            get { return personaSeleccionado; }
            set
            {
                Set(ref personaSeleccionado, value);
            }
        }

        private Tablas catalogosBL;
        public Tablas CatalogosBL
        {
            get
            {
                if (catalogosBL == null)
                    catalogosBL = new Tablas();
                return catalogosBL;
            }
        }





        private bool insercionExitosa;
        public bool InsercionExitosa
        {
            get => insercionExitosa;
            set
            {
                Set(ref insercionExitosa, value);
            }
        }
        RelayCommand insertarPersonasCommand = null;
        public RelayCommand InsertarPersonasCommand
        {
            get => insertarPersonasCommand ?? (insertarPersonasCommand = new RelayCommand(async () =>
            {
               this.InsercionExitosa = await CatalogosBL.InsertaRegistrosPersonas();

            }, () => { return true; }));
        }



    }
}
