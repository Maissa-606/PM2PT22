using Ejercicio2_2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2_2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListFirmas : ContentPage
    {
        public ListFirmas()
        {
            InitializeComponent();
        }

        private async void listadp_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selected = (Firmas)e.Item;
            bool answer = await DisplayAlert("¿Consulta?", "Deseas guardar la firma en su almacenamiento", "SI", "NO");
            if (answer == true)
            {
                try
                {
                    var Storagepath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/FOTOS1";
                    if (!Directory.Exists(Path.Combine(Storagepath, "ACH")))
                    {
                        Directory.CreateDirectory(Path.Combine(Storagepath, "ACH"));
                    }
                    string path = Path.Combine(Storagepath.ToString(), selected.nombre.Trim() + ".png");
                    System.IO.File.WriteAllBytes(path, selected.img2);
                    await DisplayAlert("Información", "Imagen guardada en !\n" + Storagepath, "OK");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", "Imagen no guardada!", "OK");
                }
            }
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            listadp.ItemsSource = await App.BasedeDatos.GetListFirmas();
        }
    }
}