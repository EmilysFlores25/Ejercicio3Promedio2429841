using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Ejercicio3Promedio2429841
{
    public class LocalDbService
    {
        private const string DB_Emily = "demo_suma_db3";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_Emily));

            _connection.CreateTableAsync<NotasProm>();
        }

        public async Task<List<NotasProm>> GetPromedio()
        {
            return await _connection.Table<NotasProm>().ToListAsync();
        }

        public async Task<NotasProm> GetById(int id)
        {
            return await _connection.Table<NotasProm>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Create(NotasProm notasProm)
        {
            await _connection.InsertAsync(notasProm);
        }

        public async Task Update(NotasProm notasProm)
        {
            await _connection.UpdateAsync(notasProm);
        }

        public async Task Delete(NotasProm notasProm)
        {
            await _connection.DeleteAsync(notasProm);
        }
    }
}
