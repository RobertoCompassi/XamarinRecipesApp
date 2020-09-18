using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Input;
using GostosoDemaisApp.Models;
using GostosoDemaisApp.Services;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace GostosoDemaisApp.Views
{
    

    public partial class RecipesRegisterList : ContentPage
    {
        List<Recipe> recipesFromServer;
        public ICommand ClickCommand { get; set; }

        public RecipesRegisterList()
        {
            InitializeComponent();

            GetRecipesListFromAPIAsync();

        }


        private async void GetRecipesListFromAPIAsync()
        {
            try
            {
                recipesFromServer = new List<Recipe>();

                using (HttpClient httpClient = new HttpClient())
                {
                    Uri uri = new Uri(string.Format("https://raw.githubusercontent.com/marcospaixao/API-Places/master/receitas.json", string.Empty));

                    HttpResponseMessage response = await httpClient.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        var _recipes = JsonConvert.DeserializeObject<List<RecipeRequest>>(content);
                        foreach(var recipe in _recipes)
                        {
                            recipesFromServer.Add(new Recipe {
                                Id = 0,
                                Name = recipe.receita,
                                Ingredients = FormatRecipe.FormatIngredients(recipe.ingredientes, null),
                                Steps = FormatRecipe.FormatIngredients(recipe.preparo, null),
                            });
                        }
                    }
                    else
                    {
                        DisplayAlert("Erro", "Erro ao tentar obter a lista", "Ok");
                    }

                    this.loader.IsVisible = false;
                    this.listViewRecipes.ItemsSource = recipesFromServer;

                }
            }
            catch (Exception ex)
            {
                this.loader.IsVisible = false;
                DisplayAlert("Erro", "Erro ao tentar obter a lista, " + ex.Message, "Ok");
            }
        }

        async void btnSaveRecipe_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                Recipe recipeFromAPI = ((Recipe)((Button)sender).CommandParameter);
                if (recipeFromAPI != null)
                {
                    recipeFromAPI.IsFavorite = false;
                    int result = await App.RecipesDatabase.SaveAsync(recipeFromAPI);
                    if(result == 1)
                    {
                        DisplayAlert("Receita Salva!", "Essa receita foi salva na sua base local.", "Continuar");
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro ao salvar", "Erro ao tentar salvar a receita na base local, " + ex.Message, "Ok");
            }
        }

    }

}
