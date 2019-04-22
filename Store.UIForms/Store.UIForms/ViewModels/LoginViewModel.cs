﻿namespace Store.UIForms.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Store.UIForms.Views;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        public LoginViewModel()
        {
            this.Email = "rafaelsantos@portugalmail.pt";
            this.Password = "123456";
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an email",
                    "Accept");

                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a password",
                    "Accept");

                return;
            }

            if(!this.Email.Equals("rafaelsantos@portugalmail.pt") || !this.Password.Equals("123456"))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "User or password wrong",
                    "Accept");

                return;
            }

            //await Application.Current.MainPage.DisplayAlert(
            //    "Ok",
            //    "Fuck yeah!!!",
            //    "Accept");

            MainViewModel.GetInstance().Products = new ProductsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new ProductsPage());
        }
    }
}