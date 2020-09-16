using System;
using System.ComponentModel;
using System.Windows.Input;
using GostosoDemaisApp.Models;
using Xamarin.Forms;

namespace GostosoDemaisApp.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }

        public Action ShowError;
        public Action ShowInvalidAccount;
        public Action EnterApp;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }

        public async void OnSubmit()
        {
            try
            {
                if (!String.IsNullOrEmpty(email))
                {
                    bool existEmail = false;
                    var emailsPresent = await App.AccountsDatabase.GetAllAsync();
                    emailsPresent.ForEach(e =>
                    {
                        // verifica se existe o email informado na lista
                        if (e.Email == email && password == "123")
                        {
                            existEmail = true;
                        }
                    });

                    // se a conta existe e confere com a senha redireciona para a lista de receitas
                    if (existEmail)
                    {
                        EnterApp();
                    } else
                    {
                        this.ShowInvalidAccount();
                    }
                } else
                {
                    // email vazio
                }
            }
            catch (Exception ex)
            {
                this.ShowError();
            }
        }
    }
}
