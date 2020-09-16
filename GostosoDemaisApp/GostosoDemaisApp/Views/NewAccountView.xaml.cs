using System;
using System.Collections.Generic;
using GostosoDemaisApp.ViewModels;
using Xamarin.Forms;

namespace GostosoDemaisApp.Views
{
    public partial class NewAccountView : ContentPage
    {
        public NewAccountView()
        {
            var vm = new NewAccountViewModel();
            this.BindingContext = vm;
            vm.ShowInvalidDomainEmail += () => DisplayAlert("Erro", "Erro ao tentar criar a conta", "Continuar");
            vm.ShowInvalidDomainEmail += () => DisplayAlert("Email não permitido", "Só é possivel cadastrar com e-mail do dominio @senac.edu.br.", "Continuar");
            vm.ShowInvalidRegexEmail += () => DisplayAlert("E-mail inválido", "Por favor, informe um e-mail valído.", "Continuar");
            vm.ShowExistEmail += () => DisplayAlert("E-mail já existe!", "O e-mail informado já possui cadastro, por favor informe um e-mail diferente.", "Continuar");
            vm.ShowSuccessCreateAccount += () => DisplayAlert("Conta criada!", "Sua conta foi criado com sucesso, volte para o login e acesse com a nova conta.", "Continuar");

            vm.ClearInputEmail += () => { txtEmail.Text = ""; };

            InitializeComponent();
        }

        async void btnBackToLogin_Clicked(System.Object sender, System.EventArgs e)
        { 
            await Navigation.PushAsync(new LoginView());
        }
    }
}
