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
            vm.ShowErroEmptyEmail += () => DisplayAlert("Email em branco", "Por favor, informe um e-mail valído.", "OK");
            vm.ShowErroEmptyPassword += () => DisplayAlert("Verifique a senha", "Verifique se a senha foi digitada corretamente, deve conter pelo menos 3 caracteres.", "OK");

            vm.EnterApp += async () =>
            {
                await Navigation.PushAsync(new MyRecipesList());
            };
        }

        async void btnNewAccount_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new NewAccountView());
        }

        async void btnIrRceitas_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MyRecipesList());
        }

    }
}
