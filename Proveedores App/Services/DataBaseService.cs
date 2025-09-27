using Proveedores_App.Models;
using SQLite;

namespace Proveedores_App.Services
{
    public class DataBaseService : IDataBaseService
    {
        private SQLiteAsyncConnection _db;

        public DataBaseService()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Proveedores.db3");
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Proveedores>();
        }

        public async Task<int> CreateProveedor(Proveedores proveedor)
        {
            return await _db.InsertAsync(proveedor);
        }

        public async Task<int> DeleteProveedor(Proveedores proveedor)
        {
            return await _db.DeleteAsync(proveedor);
        }

        public async Task<List<Proveedores>> GetAllProveedores()
        {
            return await _db.Table<Proveedores>().ToListAsync();
        }

        public async Task<int> UpdateProveedor(Proveedores proveedor)
        {
            return await _db.UpdateAsync(proveedor);
        }
    }
}
