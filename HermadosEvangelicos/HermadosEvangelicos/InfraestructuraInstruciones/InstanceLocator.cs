using System;
using System.Collections.Generic;
using System.Text;

namespace HermadosEvangelicos.InfraestructuraInstruciones
{
    using ViewsModels;
    class InstanceLocator
    {
        #region Propiedad
        public MainViewModels Main { get; set; }
        #endregion

        #region Constructor
        public InstanceLocator()
        {
            this.Main = new MainViewModels();
        }
        #endregion
    }
}
