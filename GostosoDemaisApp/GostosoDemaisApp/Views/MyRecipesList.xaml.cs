using System;
using System.Collections.Generic;
using System.Diagnostics;
using GostosoDemaisApp.Models;
using Xamarin.Forms;

namespace GostosoDemaisApp.Views
{
    public partial class MyRecipesList : ContentPage
    {
        public List<Recipe> myRecipes;

        public MyRecipesList()
        {
            

            myRecipes = new List<Recipe>();
            
            InitializeComponent();

            this.lblNoRecipesFound.IsVisible = false;

            Recipe paoQueijo = new Recipe();
            paoQueijo.Name = "Pao de Queijo";

            for (int i = 0; i < 100; i++)
            {
                myRecipes.Add(paoQueijo);
            }

            this.ListViewMyRecipes.ItemsSource = myRecipes;
        }

        void ListViewMyRecipes_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {

        }

        async void btnRegister_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new RecipesRegisterList());
        }
    }
}
