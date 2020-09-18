using System;
using SQLite;

namespace GostosoDemaisApp.Models
{

    public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsFavorite { get; set; }
        public string Ingredients { get; set; }

        public string Steps { get; set; }
    }

    public class RecipeRequest
    {
        public string receita { get; set; }
        public string ingredientes { get; set; }
        public string preparo { get; set; }
    }
}
