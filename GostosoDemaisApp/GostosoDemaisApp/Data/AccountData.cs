using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GostosoDemaisApp.Models;
using SQLite;

namespace GostosoDemaisApp.Data
{
    public class AccountData
    {
        readonly SQLiteAsyncConnection _database;

        public AccountData(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Account>().Wait();
        }

        public Task<List<Account>> GetAllAsync()
        {
            return _database.Table<Account>().ToListAsync();
        }

        public Task<Account> GetAsync(int id)
        {
            return _database.Table<Account>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveAsync(Account account)
        {
            if (account.Id != 0)
            {
                return _database.UpdateAsync(account);
            }
            else
            {
                return _database.InsertAsync(account);
            }
        }

        public Task<int> DeleteAsync(Account account)
        {
            return _database.DeleteAsync(account);
        }
    }
}
