using HermadosEvangelicos.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermadosEvangelicos.ViewsModels
{
    public class MainViewModels
    {
        public CrearHermano Crear { get; set; }
        public HermanosViewsModels Hermanos { get; set; }
        public HomeViewModels Home { get; set; }

        #region Constructores
        public MainViewModels()
        {
            instance = this;
            this.Home = new HomeViewModels();
        }
        #endregion

        #region Singleton
        private static MainViewModels instance;

        public static MainViewModels GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModels();
            }
            return instance;
        }
        #endregion
    }
}
