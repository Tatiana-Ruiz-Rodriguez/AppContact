using System;
using System.Collections.Generic;
using System.Text;
using AppContact.Models;

namespace AppContact.Data
{
    using SQLite;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using AppContact.Helpers;

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

        public async 
            Task<ObservableCollection
            <IGrouping<string, Contact>>>
            GetAllGrouped()
        {
            List<Contact> contacts = await App.DataBase().GetItemsAsync();

            IEnumerable<Grouping<string, Contact>> sorted = new Grouping<string, Contact>[0];
            if (contacts != null)
            {
                sorted =
                from f in contacts
                orderby f.Nombre
                group f by f.Nombre[0].ToString()
                into theGroup
                select
                new Grouping<string, Contact>
                (theGroup.Key, theGroup);
            }
            return new
                ObservableCollection
                <Grouping<string, Contact>>(sorted);
        }
    
    }
}
