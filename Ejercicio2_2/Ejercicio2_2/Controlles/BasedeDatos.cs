using Ejercicio2_2.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_2.Controlles
{

    public class BasedeDatos
    {
        readonly SQLiteAsyncConnection db;
        public BasedeDatos(String path)
        {
            db = new SQLiteAsyncConnection(path);
            db.CreateTableAsync<Firmas>().Wait();
        }
        public Task<List<Firmas>> GetListFirmas()
        {
            return db.Table<Firmas>().ToListAsync();
        }

        public Task<Firmas> GetFirmaporId(int id)
        {
            return db.Table<Firmas>()
                .Where(i => i.id == id)
                .FirstOrDefaultAsync();
        }
        public Task<int> guardaFirma(Firmas firma)
        {
            return firma.id != 0 ? db.UpdateAsync(firma) : db.InsertAsync(firma);
        }
        public Task<int> borrarFirma(Firmas firma)
        {
            return db.DeleteAsync(firma);
        }
    }
}
