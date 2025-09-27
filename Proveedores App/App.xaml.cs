namespace Proveedores_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new Proveedores_App.Views.ProveedoresView();
        }

    }
}