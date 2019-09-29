using Prism;
using Prism.Ioc;
using InsurHackMobile.ViewModels;
using InsurHackMobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using InsurHackMobile.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace InsurHackMobile
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/SignInPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();

            // ViewModels
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<SignUpPage, SignUpViewModel>();
            containerRegistry.RegisterForNavigation<SignInPage, SignInViewModel>();

            // Services
            containerRegistry.Register<IUserService, UserService>();
            containerRegistry.Register<IProfessionService, ProfessionService>();
        }
    }
}
