using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.ViewModel
{
    public class DatabaseHelper
    {
        private static readonly string dbFile = Path.Combine(Environment.CurrentDirectory, "notesDb.db3");

        public static bool Insert<T>(T item)
        {
            return OnConnection<T>(conn => conn.Insert(item));
        }

        public static bool Update<T>(T item)
        {
            return OnConnection<T>(conn => conn.Update(item));
        }

        public static bool Delete<T>(T item)
        {
            return OnConnection<T>(conn => conn.Delete(item));
        }

        private static bool OnConnection<T>(Func<SQLiteConnection, int> func)
        {
            bool result = false;

            using (SQLiteConnection conn = new SQLiteConnection(dbFile))
            {
                conn.CreateTable<T>();
                int numbereOfRows = func.Invoke(conn);
                result = numbereOfRows > 0;
            }

            return result;
        }
    }
}
