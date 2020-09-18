using System;
using System.Collections.Generic;
using GostosoDemaisApp.Models;
using GostosoDemaisApp.Services;
using Xamarin.Forms;

namespace GostosoDemaisApp.Views
{
    public partial class RecipeDetails : ContentPage
    {
        Recipe recipe;
        public RecipeDetails(Recipe recipeSelected)
        {
            InitializeComponent();
            this.GetRecipe(recipeSelected);
        }


        public async void GetRecipe(Recipe recipeSelected)
        {
            if (recipeSelected != null)
            {   
                recipe = await App.RecipesDatabase.GetAsync(recipeSelected.Id);
                this.titleRecipe.Text = recipe.Name;
                this.textIngredients.Text = FormatRecipe.FormatIngredients(recipe.Ingredients, null);
                this.textSteps.Text = FormatRecipe.FormatIngredients(recipe.Steps, null);

                if (recipe.IsFavorite)
                {
                    this.btnChangeFavorite.Text = "REMOVER DOS FAVORITOS";
                    this.btnChangeFavorite.BackgroundColor = Color.Red;
                }
                else
                {
                    this.btnChangeFavorite.Text = "ADICIONAR AOS FAVORITOS";
                    this.btnChangeFavorite.BackgroundColor = Color.Blue;
                }
            }
        }
        

        async void btnChangeFavorite_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                recipe.IsFavorite = !recipe.IsFavorite;

                int result = await App.RecipesDatabase.SaveAsync(recipe);

                if (result == 1)
                {
                    DisplayAlert("Show!!!", "Alteração salvo com sucesso", "Eba, continuar");
                }

                if (recipe.IsFavorite)
                {
                    this.btnChangeFavorite.Text = "REMOVER DOS FAVORITOS";
                    this.btnChangeFavorite.BackgroundColor = Color.Red;
                } else
                {
                    this.btnChangeFavorite.Text = "ADICIONAR AOS FAVORITOS";
                    this.btnChangeFavorite.BackgroundColor = Color.Blue;
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro ao favoritar", "Ops, não foi possivel favoritar agora", "Ok");
            }
        }

    }
}
