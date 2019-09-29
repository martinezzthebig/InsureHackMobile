using InsurHackMobile.Lib;
using InsurHackMobile.Services;
using InsurHackMobile.Views;
using Prism.Navigation;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InsurHackMobile.ViewModels
{
    public class SignInViewModel : ViewModelBase
    {
        private IUserService _userService;

        private string _email = "";
        private string _password = "";
        private string _errorLabel = "";

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        public string ErrorLabel
        {
            get => _errorLabel;
            set => SetProperty(ref _errorLabel, value);
        }

        public ICommand NavigateToSignUpCommand { get; }
        public ICommand SignInCommand { get; }

        public SignInViewModel(INavigationService navigationService, IUserService userService) : base(navigationService)
        {
            _userService = userService;

            NavigateToSignUpCommand = new AsyncCommand(NavigateToSignUp);
            SignInCommand = new AsyncCommand(SignIn);
        }

        private async Task SignIn(object arg)
        {
            if (Email.Length > 0 && Password.Length > 0)
                EnvironmentConstants.signedInUser = await _userService.SignInUser(Email, Password);
            else
            {
                ErrorLabel = "The fields cannot be empty.";
                return;
            }

            if (EnvironmentConstants.signedInUser != null)
                await NavigationService.NavigateAsync(nameof(MainPage));
            else
                ErrorLabel = "Invalid credentials";
        }

        private async Task NavigateToSignUp() => await NavigationService.NavigateAsync(nameof(SignUpPage));
    }
}
