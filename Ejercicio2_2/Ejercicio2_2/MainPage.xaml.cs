using Ejercicio2_2.Models;
using Ejercicio2_2.Views;
using SignaturePad.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2_2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public String encriptado;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            Stream img = await firmita.GetImageStreamAsync(SignatureImageFormat.Png);
            var memmo = (MemoryStream)img;
            byte[] data = memmo.ToArray();
            encriptado = Convert.ToBase64String(data);
            string vnombre = txtname.Text;
            try
            {
                if (vnombre.Length > 0)
                {
                    var firma = new Firmas
                    {
                        imageencripted = encriptado,
                        nombre = txtname.Text,
                        desc = txtdesc.Text
                    };
                    int respuesta = await App.BasedeDatos.guardaFirma(firma);
                    if (respuesta == 1) { await DisplayAlert("Información", "Firma guardada!", "OK"); }
                    else
                    {
                        await DisplayAlert("Error", "Intente de nuevo", "OK");
                    }
                    
                }
                else
                {
                    await DisplayAlert("Alerta", "Campos vacios!", "OK");
                }
            }
            catch { }
            
        }

        private async void btnLista_Clicked(object sender, EventArgs e)
        {
            firmita.Clear();
            txtdesc.Text = "";
            txtname.Text = "";
            await Navigation.PushAsync(new ListFirmas());
           
        }
    }
}
