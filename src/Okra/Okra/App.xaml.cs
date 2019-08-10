using Okra.Repositories;
using Okra.Services;
using Okra.ViewModels;
using Okra.Views;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Xamarin.Forms;

namespace Okra
{
    public partial class App : PrismApplication
    {
        public App()
        {
        }

        public App(IPlatformInitializer platformInitializer)
            : base(platformInitializer)
        {
        }

        public App(IPlatformInitializer platformInitializer, bool setFormsDependencyResolver)
            : base(platformInitializer, setFormsDependencyResolver)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            //await NavigationService.NavigateAsync($"NavigationPage/{nameof(MainPage)}");
            await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(HomePage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>(nameof(NavigationPage));
            containerRegistry.RegisterForNavigation<HomePage, HomeViewModel>(nameof(HomePage));
            containerRegistry.RegisterForNavigation<MainPage, MainViewModel>(nameof(MainPage));
            containerRegistry.RegisterForNavigation<DetailPage, DetailViewModel>(nameof(DetailPage));
            containerRegistry.RegisterForNavigation<FavoritePage, FavoriteViewModel>(nameof(FavoritePage));

            containerRegistry.Register<IRecipeService, RecipeService>();
            containerRegistry.Register<ILocalDataBaseRepository, LocalDataBaseRepository>();
        }
    }
}
