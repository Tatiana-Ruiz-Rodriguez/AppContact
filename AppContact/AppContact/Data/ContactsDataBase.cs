using System;
using System.Collections.Generic;
using System.Text;
using AppContact.Models;

namespace AppContact.Data
{
    using SQLite;
    using System.Threading.Tasks;

    public class ContactsDataBase
    {

        private readonly SQLiteAsyncConnection dataBase;

        public ContactsDataBase(string dbPath)
        {
            dataBase = new SQLiteAsyncConnection(dbPath);
            dataBase.CreateTableAsync<Contact>().Wait();
        }

        public async Task<List<Contact>> GetItemsAsync()
        {
            var data = await dataBase.Table<Contact>().ToListAsync();
            return data;
        }

        public Task<Contact> GetItemAsync(int Id)
        {
            return dataBase.Table<Contact>()
                .Where(c=>c.ID == Id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Contact item)
        {
            if (item.ID != 0)
            {
                return dataBase.UpdateAsync(item);
            }
            else
            {
                return dataBase.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Contact item)
        {

            return dataBase.DeleteAsync(item);

        }

    }
}
