using System;
using System.Collections.Generic;
using System.Diagnostics;
using GostosoDemaisApp.Models;
using GostosoDemaisApp.Services;
using Xamarin.Forms;

namespace GostosoDemaisApp.Views
{
    public partial class MyRecipesList : ContentPage
    {
        public MyRecipesList()
        {
            InitializeComponent();
            
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.GetMyRecipesSaved();
        }


        async void ListViewMyRecipes_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            try
            {
                var RecipeSelected = ((Recipe)((ListView)sender).SelectedItem);
                await Navigation.PushAsync(new RecipeDetails(RecipeSelected));
            }
            catch (Exception ex)
            {
                DisplayAlert("Ops!", "Erro ao tentar ir para os detalhes da receita", "Ok");
            }
            
        }

        async void btnRegister_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new RecipesRegisterList());
        }

        async void GetMyRecipesSaved()
        {
            this.lblNoRecipesFound.IsVisible = false;
            var _recipesSaved = await App.RecipesDatabase.GetAllAsync();

            if(_recipesSaved.Count > 0)
            {
                foreach (var _recipe in _recipesSaved)
                {
                    _recipe.Ingredients = FormatRecipe.FormatIngredients(_recipe.Ingredients, 25);
                }

                this.ListViewMyRecipes.ItemsSource = _recipesSaved;
            } else
            {
                this.lblNoRecipesFound.IsVisible = true;
            }
        }
    }
}
