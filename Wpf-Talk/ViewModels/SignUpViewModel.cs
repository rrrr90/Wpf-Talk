﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Wpf_Talk.Models;
using Wpf_Talk.Repositories;
using Wpf_Talk.Services;
using Wpf_Talk.ViewModels.Bases;

namespace Wpf_Talk.ViewModels
{
    internal class SignUpViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IAccountRepository _accountRepository;
		private readonly Random _random = new Random();

		private string _email = default!;
		private string _password = default!;
        private string _passwordR = default!;

        public string Email
		{
			get => _email;
			set { SetProperty(ref _email, value); }
		}

		public string Password
		{
			get => _password;
			set { SetProperty(ref _password, value); }
		}

		public string PasswordR
		{
			get => _passwordR;
			set { SetProperty(ref _passwordR, value); }
		}

		public SignUpViewModel(INavigationService navigationService, IAccountRepository accountRepository)
		{
			this._navigationService = navigationService;
			this._accountRepository = accountRepository;
		}

        public ICommand SignUpCommand => new RelayCommand<object>(RequestSignUp);
        public ICommand ToSignInCommand => new RelayCommand(ToSignIn);


        private void RequestSignUp(object? _)
		{
			if (Password != PasswordR)
			{
				MessageBox.Show("passwords do not match");
				return;
			}

			long id = -1;
			try
			{
				id = _accountRepository.Insert(new Account()
				{
					Email = Email,
					Password = Password,
					Nickname = "null",
					CellPhone = "010" + GetRandomNumber(8)
				});
			}
			catch (Exception ex) { MessageBox.Show(ex.Message); }
			if(id >= 0)
			{
				MessageBox.Show("OK");
				_navigationService.Navigate(LoginNavType.SignInView);
			}
		}

        private void ToSignIn()
        {
            _navigationService.Navigate(LoginNavType.SignInView);
        }

        private string GetRandomChar(int count = 1)
        {
            char[] mem = new char[count];
            for (int i = 0; i < count; i++)
                mem[i] = (char)(_random.Next(26) + 'a');
            return new string(mem);
        }

        private string GetRandomNumber(int count = 1)
        {
            char[] mem = new char[count];
            for (int i = 0; i < count; i++)
                mem[i] = (char)(_random.Next(10) + '0');
            return new string(mem);
        }
    }
}
