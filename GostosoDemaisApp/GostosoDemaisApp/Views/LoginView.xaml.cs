using System;
using System.Collections.Generic;
using GostosoDemaisApp.ViewModels;
using Xamarin.Forms;

namespace GostosoDemaisApp.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            var vm = new LoginViewModel();
            this.BindingContext = vm;
            InitializeComponent();

            vm.ShowInvalidAccount += () => DisplayAlert("Conta Inválida", "A conta não existe ou senha incorreta, verifique os dados.", "Continuar");
            vm.ShowError += () => DisplayAlert("Erro", "Erro ao tentar verificar o login.", "Continuar");

            vm.EnterApp += async () =>
            {
                await Navigation.PushAsync(new RecipesListView());
            };
        }

        async void btnNewAccount_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new NewAccountView());
        }

        
    }
}
