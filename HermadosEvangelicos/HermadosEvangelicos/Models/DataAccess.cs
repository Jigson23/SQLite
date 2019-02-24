using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net;
using Xamarin.Forms;
using System.IO;
using System.Linq;

namespace HermadosEvangelicos
{
    public class DataAccess : IDisposable
    {
        private SQLiteConnection Connection;
        public DataAccess()
        {
            var Config = DependencyService.Get<IConfig>();
            Connection = new SQLiteConnection(Config.Platform, Path.Combine(
                Config.DirectorioDB, "Hermanos.db3"));
            Connection.CreateTable<Hermano>();
        }

        public void InsertEmpleado(Hermano hermano)
        {
            Connection.Insert(hermano);

        }
        public void UpdateEmpleado(Hermano hermano)
        {
            Connection.Update(hermano);

        }

        public void DeleteEmpleado(Hermano hermano)
        {
            Connection.Delete(hermano);

        }
        public Hermano GetHermano(string cedula)
        {
            return Connection.Table<Hermano>().FirstOrDefault(c =>
            c.cedula == cedula);
        }

        public List<Hermano> GetHermanos()
        {
            return Connection.Table<Hermano>().OrderBy(c => c.apellidos).ToList();
        }
        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}
