using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HermadosEvangelicos.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CrearHermano : ContentPage
	{
		public CrearHermano ()
		{
			InitializeComponent();
            nuevoButton.Clicked += NuevoButton_Clicked;
            using (var datos = new DataAccess())
            {

            }

             async void NuevoButton_Clicked(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(CedulaEntry.Text))
                {
                    await DisplayAlert("Error", "Debe ingresar cedula", "Aceptar");
                    CedulaEntry.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(nombreEntry.Text))
                {
                    await DisplayAlert("Error", "Debe ingresar nombres", "Aceptar");
                    nombreEntry.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(apellidoEntry.Text))
                {
                    await DisplayAlert("Error", "Debe ingresar apellidos", "Aceptar");
                    apellidoEntry.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(sexoPicker.SelectedItem.ToString()))
                {
                    await DisplayAlert("Error", "Debe ingresar sexo", "Aceptar");
                    sexoPicker.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(CivilPicker.SelectedIndex.ToString()))
                {
                    await DisplayAlert("Error", "Debe selecionar su Estado Civil", "Aceptar");
                    CivilPicker.Focus();
                    return;
                }

                Hermano hermano = new Hermano()
                {
                    activo = true,
                    cedula = CedulaEntry.Text,
                    nombre = nombreEntry.Text,
                    apellidos = apellidoEntry.Text,
                    IdSexo = sexoPicker.SelectedItem.ToString(),
                    Fecha_Nac = fechaNacDateP.Date,
                    IdProvincia = provinciaEntry.Text,
                    IdCiudad = ciudadEntry.Text,
                    Direccion = direccionEntry.Text,
                    Telefono = telefonoEntry.Text,
                    IdEstadoCivil = CivilPicker.SelectedItem.ToString(),
                    TipoSangre = TipoSangreEntry.Text,
                    Bautizo = Bautizado.IsToggled,
                    Fecha_Bautizo = FechaBauDateP.Date
                };

                using (var data = new DataAccess())
                {
                    data.InsertEmpleado(hermano);
                    if (data == null)
                    {
                        await DisplayAlert("Error", "Los Datos No pudierón ser Grabados", "Aceptar");
                        return;
                    }
                    await DisplayAlert("Error", "Los Datos Fueron Grabados", "Aceptar");
                    Limpiar();

                }


            }

            void Limpiar()
            {

                CedulaEntry.Text = string.Empty;
                nombreEntry.Text = string.Empty;
                apellidoEntry.Text = string.Empty;
                sexoPicker.SelectedIndex = -1;
                fechaNacDateP.Date = DateTime.Now;
                provinciaEntry.Text = string.Empty;
                ciudadEntry.Text = string.Empty;
                direccionEntry.Text = string.Empty;
                telefonoEntry.Text = string.Empty;
                CivilPicker.SelectedIndex = -1;
                TipoSangreEntry.Text = string.Empty;
                Bautizado.IsToggled = false;
                FechaBauDateP.Date = DateTime.Now;
            }

        }
    }
}