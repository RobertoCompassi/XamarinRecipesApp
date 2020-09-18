using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GostosoDemaisApp.Models;
using SQLite;

namespace GostosoDemaisApp.Data
{
    public class RecipeData
    {
        readonly SQLiteAsyncConnection _database;

        public RecipeData(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Recipe>().Wait();
        }

        public Task<List<Recipe>> GetAllAsync()
        {
            return _database.Table<Recipe>().ToListAsync();
        }

        public Task<Recipe> GetAsync(int id)
        {
            return _database.Table<Recipe>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveAsync(Recipe recipe)
        {
            if (recipe.Id != 0)
            {
                return _database.UpdateAsync(recipe);
            }
            else
            {
                return _database.InsertAsync(recipe);
            }
        }

        public Task<int> DeleteAsync(Recipe recipe)
        {
            return _database.DeleteAsync(recipe);
        }
    }
}
