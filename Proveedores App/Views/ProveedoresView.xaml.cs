using Proveedores_App.ViewModels;

namespace Proveedores_App.Views;

public partial class ProveedoresView : ContentPage
{
    public ProveedoresView()
    {
        InitializeComponent();
        BindingContext = new ProveedoresViewModel();
    }
}