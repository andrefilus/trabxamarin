using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Okra.Models;
using Okra.Services;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace Okra.ViewModels
{
    public sealed class FavoriteViewModel: BaseViewModel
    {
        private readonly IRecipeService recipeService;

        public FavoriteViewModel(
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
                await recipeService.RemoveFavorite(recipe);
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
            var collection = await recipeService.All();
            Recipes = new ObservableCollection<Recipe>(collection);
        }
    }
}
