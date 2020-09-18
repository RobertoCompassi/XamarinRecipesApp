using System;
namespace GostosoDemaisApp.Services
{
    public static class FormatRecipe
    {
        public static string FormatIngredients(string ingredients, int? cropLength)
        {
            try
            {
                if (!String.IsNullOrEmpty(ingredients))
                {
                    string _ingredients = String.Empty;

                    _ingredients = ingredients.Replace("[\"", "").Replace("\", \"", "\n").Replace("\"]", "");

                    // corta o texto na quantidade desejada e adicionada ...
                    if(cropLength != null)
                    {
                        if (ingredients.Length > cropLength)
                        {
                            _ingredients = _ingredients.Substring(0, (int)cropLength) + "...";
                        }
                    }
                    
                    if (ingredients.Length < 5)
                    {
                        _ingredients = "Nenhuma descrição";
                    }

                    return _ingredients;
                } else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
