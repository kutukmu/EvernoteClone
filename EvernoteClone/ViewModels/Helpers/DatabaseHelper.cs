using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.ViewModels.Helpers
{
    public class DatabaseHelper
    {
        private static string path = Path.Combine(Environment.CurrentDirectory, "notedDb");

        public static bool AddItem<T>(T newItem)
        {
            bool isAdded = false;
            using(SQLiteConnection connection = new SQLiteConnection(path))
            {
                connection.CreateTable<T>();
                var val = connection.Insert(newItem);
                if (val > 0) 
                    isAdded = true;
            }

            return isAdded;
        }

        public static bool UpdateItem<T>(T newItem)
        {
            bool isUpdated = false;
            using (SQLiteConnection connection = new SQLiteConnection(path))
            {
                connection.CreateTable<T>();
                var val = connection.Update(newItem);
                if (val > 0)
                    isUpdated = true;
            }

            return isUpdated;
        }

        public static bool DeleteItem<T>(T item)
        {
            bool isDeleted = false;
            using(SQLiteConnection connection = new SQLiteConnection(path))
            {
                connection.CreateTable<T>();
                var val = connection.Delete(item);
                if(val > 0)
                {
                    isDeleted = true;
                }
            }

            return isDeleted;
        }

        public static List<T> GetItems<T>() where T:new()
        {
            List<T> list;
            using(SQLiteConnection connection = new SQLiteConnection(path))
            {
                connection.CreateTable<T>();
                list = connection.Table<T>().ToList();

            }

            return list;
        }

        


    }
}
