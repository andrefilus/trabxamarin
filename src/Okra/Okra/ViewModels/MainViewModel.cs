using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Okra.Models;
using Okra.Services;
using Okra.Views;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace Okra.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IRecipeService recipeService;

        public MainViewModel(
            INavigationService navigationService
             , IRecipeService recipeService)
            : base(navigationService)
        {
            this.recipeService = recipeService;
            AddCommand = new DelegateCommand(async () => await AddExecute())
                .ObservesCanExecute(() => IsNotBusy);

            ItemClickCommand = new Command<Recipe>(async (item) => await ItemClickCommandExecute(item));
        }

        private ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();
        public ObservableCollection<Recipe> Recipes
        {
            get => recipes;
            set => SetProperty(ref recipes, value);
        }

        public ICommand AddCommand { get; }
        public ICommand ItemClickCommand { get; }

        private async Task AddExecute()
        {
            await ExecuteBusyAction(async () =>
            {

                await LoadRecipes();
            });
        }

        async Task ItemClickCommandExecute(Recipe recipe)
        {
            if (recipe != null)
            {
                var navParams = new NavigationParameters();
                navParams.Add("recipe", recipe);


                await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(DetailPage)}", navParams);
            }
        }

        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            await ExecuteBusyAction(async () =>
            {
                await LoadRecipes();
            });
        }

        private async Task LoadRecipes()
        {
            var collection = await recipeService.GetRecipesAsync();
            Recipes = new ObservableCollection<Recipe>(collection);
        }
    }
}
