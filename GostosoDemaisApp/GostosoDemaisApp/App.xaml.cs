using System;
using System.IO;
using GostosoDemaisApp.Data;
using GostosoDemaisApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GostosoDemaisApp
{
    public partial class App : Application
    {
        static AccountData accountsDatabase;

        public static AccountData AccountsDatabase
        {
            get
            {
                if (accountsDatabase == null)
                {
                    accountsDatabase = new AccountData(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Accounts.db3"));
                }
                return accountsDatabase;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
