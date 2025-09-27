using Proveedores_App.Models;

namespace Proveedores_App.Services
{
    /// <summary>
    /// Interfaz donde están los métodos para el uso con la base de datos
    /// </summary>
    public interface IDataBaseService
    {
        /// <summary>
        /// Obtener todo el listado de proveedores
        /// </summary>
        /// <returns>Listado de proveedores</returns>
        public Task<List<Proveedores>> GetAllProveedores();

        /// <summary>
        /// Crea un nuevo proveedor
        /// </summary>
        /// <param name="proveedor">Objeto con los registros a crear</param>
        /// <returns>Número de proveedores creados</returns>
        public Task<int> CreateProveedor(Proveedores proveedor);

        /// <summary>
        /// Actualiza un proveedor
        /// </summary>
        /// <param name="proveedor">Objeto con los registros a actualizar</param>
        /// <returns>Número de proveedores actualizados</returns>
        public Task<int> UpdateProveedor(Proveedores proveedor);

        /// <summary>
        /// Elimina un proveedor
        /// </summary>
        /// <param name="proveedor">Objeto del proveedor a eliminar</param>
        /// <returns>Número de proveedores eliminados</returns>
        public Task<int> DeleteProveedor(Proveedores proveedor);
    }
}