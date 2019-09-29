using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using InsurHackMobile.Lib;
using InsurHackMobile.Models;
using InsurHackMobile.Services;
using Prism.Navigation;

namespace InsurHackMobile.ViewModels
{
    public class SignUpViewModel : ViewModelBase
    {
        private IUserService _userService;
        private IProfessionService _professionService;

        private string _firstName = "";
        private string _lastName = "";
        private string _email = "";
        private string _password = "";
        private string _yearOfBirth = "";
        private bool _isMarried;
        private Profession _selectedProfession;
        private List<Profession> _professions;
        private string _driversLicenseYear = "";

        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }
        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }
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
        public string YearOfBirth
        {
            get => _yearOfBirth;
            set => SetProperty(ref _yearOfBirth, value);
        }
        public bool IsMarried
        {
            get => _isMarried;
            set => SetProperty(ref _isMarried, value);
        }
        public Profession SelectedProfession
        {
            get => _selectedProfession;
            set => SetProperty(ref _selectedProfession, value);
        }
        public List<Profession> ProfessionsList
        {
            get => _professions;
            set => SetProperty(ref _professions, value);
        }
        public string DriversLicenseYear
        {
            get => _driversLicenseYear;
            set => SetProperty(ref _driversLicenseYear, value);
        }

        public ICommand SignUpCommand { get; }

        public SignUpViewModel(INavigationService navigationService, IUserService userService, IProfessionService professionService) : base(navigationService)
        {
            _userService = userService;
            _professionService = professionService;
            Initialize();

            SignUpCommand = new AsyncCommand(SignUp);
        }

        private async void Initialize()
        {
            try
            {
                ProfessionsList = await _professionService.GetAllProfessions();
                SelectedProfession = ProfessionsList[0];
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private async Task SignUp()
        {
            if (!ValidateFields())
                return;
            int licenseYear;
            int birthYear;
            try
            {
                licenseYear = Convert.ToInt32(DriversLicenseYear);
                birthYear = Convert.ToInt32(YearOfBirth);
                var user = new User
                {
                    Name = FirstName,
                    SurName = LastName,
                    EMail = Email,
                    Password = Password,
                    YearOfDriversLicense = licenseYear,
                    Age = birthYear,
                    IsMarried = IsMarried,
                    ProfessionId = "e4e76589-2d7d-4084-8400-526ed80856f6"
                };
                await _userService.SingUpUser(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private bool ValidateFields()
        {
            if(FirstName.Length > 2 && LastName.Length > 2 && Email.Length > 2 && Password.Length > 4)
            {
                if(YearOfBirth.Length == 4 && DriversLicenseYear.Length == 4)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
