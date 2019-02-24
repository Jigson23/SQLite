using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;
using System.Linq;

namespace HermadosEvangelicos.ViewsModels
{
    public class HermanosViewsModels:BaseViewModels
    {
        #region Atributes
        private ObservableCollection<Hermano> hermanos;
        private bool isRefreshing;
        private string filter;
        private List<Hermano> HermanosList;

        #endregion

        #region Properties
        public string Filter
        {
            get { return this.filter; }
            set
            {
                SetValue(ref this.filter, value);
                this.Search();
            }
        }
        public ObservableCollection<Hermano> Hermanos
        {
            get { return this.hermanos; }
            set { SetValue(ref this.hermanos, value); }
        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }
        #endregion

        #region Constructores
        public HermanosViewsModels()
        {
            this.LoadHermanos();
        }

        private async void LoadHermanos()
        {
            this.IsRefreshing = true;
            using (var data = new DataAccess())
            {
                var resul = data.GetHermanos();
                if (resul == null)
                {
                    await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "No Hay Datos",
                    "Accept");
                    return;
                }

                this.HermanosList = (List<Hermano>)data.GetHermanos();
                this.Hermanos = new ObservableCollection<Hermano>(this.HermanosList);
                this.IsRefreshing = false;
            }


            
        }
        #endregion

     
        #region Command
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadHermanos);
            }
        }
        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Hermanos = new ObservableCollection<Hermano>(this.HermanosList);

            }
            else
            {
                this.Hermanos = new ObservableCollection<Hermano>(this.HermanosList.Where(l
                    => l.nombre.ToLower().Contains(this.Filter.ToLower()) ||
                       l.cedula.ToLower().Contains(this.Filter.ToLower())));

            }
        }
        #endregion
    
}
}
