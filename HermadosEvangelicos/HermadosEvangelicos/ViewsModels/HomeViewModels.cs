using GalaSoft.MvvmLight.Command;
using HermadosEvangelicos.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HermadosEvangelicos.ViewsModels
{
    public class HomeViewModels:BaseViewModels
    {
        #region Atributes
        private bool isRunning;
        private bool isEnabled;
        #endregion

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        public bool IsRecordar { get; set; }
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        public ICommand RegistarComand { get { return new RelayCommand(Registar); } }
        public ICommand BuscarComand { get { return new RelayCommand(Buscar); } }


        private async void Buscar()
        {

            this.IsEnabled = true;
            this.IsRunning = false;

            MainViewModels.GetInstance().Hermanos = new HermanosViewsModels();
            await Application.Current.MainPage.Navigation.PushAsync(new Hermanos());
        }

        private async void Registar()
        {
            
            this.IsEnabled = true;
            this.IsRunning = false;




            MainViewModels.GetInstance().Crear = new CrearHermano();
            await Application.Current.MainPage.Navigation.PushAsync(new CrearHermano());
        }

        public HomeViewModels()
        {
            this.IsRecordar = true;
            this.IsEnabled = true;
        }
    }
}
