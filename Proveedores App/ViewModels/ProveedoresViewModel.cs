using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proveedores_App.Models;
using Proveedores_App.Services;
using System.Collections.ObjectModel;

namespace Proveedores_App.ViewModels
{
    public partial class ProveedoresViewModel : ObservableObject
    {
        private DataBaseService _dbService;

        [ObservableProperty]
        private Proveedores _proveedorSeleccionado;

        [ObservableProperty]
        private ObservableCollection<Proveedores> _proveedoresCollection;

        public ProveedoresViewModel()
        {
            _dbService = new DataBaseService();
            ProveedoresCollection = new ObservableCollection<Proveedores>();
            LoadProveedoresCommand.ExecuteAsync(null);
            ProveedorSeleccionado = new Proveedores();
        }

        [RelayCommand]
        private async Task LoadProveedores()
        {
            var proveedores = await _dbService.GetAllProveedores();
            ProveedoresCollection.Clear();
            foreach (var proveedor in proveedores)
            {
                ProveedoresCollection.Add(proveedor);
            }
        }

        [RelayCommand]
        private async Task GuardarProveedor()
        {
            try
            {
                // Validaciones para los campos requeridos
                if (string.IsNullOrWhiteSpace(ProveedorSeleccionado.Nombre))
                {
                    Alerta("Escriba el nombre del proveedor");
                    return;
                }

                if (string.IsNullOrWhiteSpace(ProveedorSeleccionado.Direccion))
                {
                    Alerta("Escriba la dirección del proveedor");
                    return;
                }

                if (string.IsNullOrWhiteSpace(ProveedorSeleccionado.Telefono))
                {
                    Alerta("Escriba el teléfono del proveedor");
                    return;
                }

                if (string.IsNullOrWhiteSpace(ProveedorSeleccionado.Email))
                {
                    Alerta("Escriba el email del proveedor");
                    return;
                }

                if (string.IsNullOrWhiteSpace(ProveedorSeleccionado.Producto))
                {
                    Alerta("Escriba el producto del proveedor");
                    return;
                }

                if (ProveedorSeleccionado.Id == 0)
                {
                    await _dbService.CreateProveedor(ProveedorSeleccionado);
                    Alerta("Proveedor creado correctamente");
                }
                else
                {
                    await _dbService.UpdateProveedor(ProveedorSeleccionado);
                    Alerta("Proveedor actualizado correctamente");
                }

                await LoadProveedores();
                ProveedorSeleccionado = new Proveedores();
            }
            catch (Exception ex)
            {
                Alerta($"Ha ocurrido un error: {ex.Message}");
            }
        }

        [RelayCommand]
        private void CrearProveedor()
        {
            ProveedorSeleccionado = new Proveedores();
        }

        [RelayCommand]
        private async Task EliminarProveedor()
        {
            try
            {
                if (ProveedorSeleccionado.Id == 0)
                {
                    Alerta("Debe seleccionar un proveedor a eliminar");
                    return;
                }

                bool respuesta = await Application.Current!.MainPage!.DisplayAlert(
                    "ELIMINAR PROVEEDOR",
                    "¿Desea eliminar este proveedor?",
                    "Si",
                    "No");

                if (respuesta)
                {
                    if (ProveedorSeleccionado != null && ProveedorSeleccionado.Id != 0)
                    {
                        await _dbService.DeleteProveedor(ProveedorSeleccionado);
                        await LoadProveedores();
                        ProveedorSeleccionado = new Proveedores();
                        Alerta("Proveedor eliminado correctamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                Alerta($"Ha ocurrido un error: {ex.Message}");
            }
        }

        private void Alerta(string mensaje)
        {
            Application.Current!.MainPage!.DisplayAlert("", mensaje, "Aceptar");
        }
    }
}