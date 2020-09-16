using System;
using System.ComponentModel;
using System.Windows.Input;
using GostosoDemaisApp.Models;
using Xamarin.Forms;

namespace GostosoDemaisApp.ViewModels
{
    public class NewAccountViewModel
    {

        public NewAccountViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }

        public Action ShowInvalidDomainEmail;
        public Action ShowInvalidRegexEmail;
        public Action ShowExistEmail;
        public Action ShowSuccessCreateAccount;
        public Action ClearInputEmail;
        public Action ShowGenericError;

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

        public ICommand SubmitCommand { protected set; get; }

        public async void OnSubmit()
        {
            try
            {
                if (!String.IsNullOrEmpty(email))
                {
                    if (!email.Contains("@senac.edu.br"))
                    {
                        ClearInputEmail();
                        ShowInvalidDomainEmail();
                    }
                    else
                    {
                        bool existEmail = false;
                        var emailsPresent = await App.AccountsDatabase.GetAllAsync();
                        emailsPresent.ForEach(e =>
                        {
                        // verifica se já existe o email informado na lista
                        if (e.Email == email)
                            {
                                existEmail = true;
                            }
                        });

                        if (!existEmail)
                        {
                            // salva no banco local a conta cadastrada
                            var result = await App.AccountsDatabase.SaveAsync(new Account
                            {
                                Email = email
                            });

                            // limpa o campo de email e mostra o alerta de sucesso
                            if (result == 1)
                            {
                                ClearInputEmail();
                                this.ShowSuccessCreateAccount();
                            }
                        }
                        else
                        {
                            // mostra a mensagem que o email já existe no banco de dados local
                            this.ShowExistEmail();
                        }
                    }
                }
                else
                {
                    ShowInvalidRegexEmail();
                }
            }
            catch (Exception ex)
            {
                this.ShowGenericError();
            }
        }
    }
}
