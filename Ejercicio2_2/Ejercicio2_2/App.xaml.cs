using Ejercicio2_2.Controlles;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2_2
{
    public partial class App : Application
    {
        static BasedeDatos database;
        public static BasedeDatos BasedeDatos
        {
            get
            {
                if (database == null)
                {
                    database = new BasedeDatos(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FirmasDB.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
