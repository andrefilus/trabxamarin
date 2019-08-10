using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Okra.Models;
using Okra.Services;
using Prism.Commands;
using Prism.Navigation;

namespace Okra.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
        private readonly IRecipeService recipeService;
        Recipe recipe = new Recipe();

        public DetailViewModel(
            INavigationService navigationService,
            IRecipeService recipeService)
            : base(navigationService)
        {
            this.recipeService = recipeService;
            AddCommand = new DelegateCommand(async () => await AddExecute()).ObservesCanExecute(() => IsNotBusy);
        }

        public ICommand AddCommand { get; }

        private async Task AddExecute()
        {
            await ExecuteBusyAction(async () =>
            {
                if (!recipe.IsFavorite) {
                    await recipeService.Favorite(recipe);
                    Favorite = "Desfavoritar";
                    recipe.IsFavorite = true;
                } else
                {
                    await recipeService.RemoveFavorite(recipe);
                    Favorite = "Favoritar";
                    recipe.IsFavorite = false;
                }

            });
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            recipe = parameters.GetValue<Recipe>("recipe");
            if (recipe.IsFavorite)
            {
                Favorite = "Desfavoritar";
            } else
            {
                Favorite = "Favoritar";
            }
            
            Title = recipe.Title;
            Category = recipe.Category;
            Steps = recipe.Steps;
            Author = recipe.AuthorName;
            PictureAuthor = recipe.AuthorPath;
            PictureRecipe = recipe.PicturePath;
        }

        #region properties
        private string _favorite;
        private string _category;
        private string _author;
        private string _steps;
        private string _pictureAuthor;
        private string _pictureRecipe;
        public string _title;

        public string Favorite
        {
            get { return _favorite; }
            set { _favorite = value; OnPropertyChanged(); }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(); }
        }

        public string Category
        {
            get { return _category; }
            set { _category = value; OnPropertyChanged(); }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; OnPropertyChanged(); }
        }

        public string Steps
        {
            get { return _steps; }
            set { _steps = value; OnPropertyChanged(); }
        }

        public string PictureAuthor
        {
            get { return _pictureAuthor; }
            set { _pictureAuthor = value; OnPropertyChanged(); }
        }

        public string PictureRecipe
        {
            get { return _pictureRecipe; }
            set { _pictureRecipe = value; OnPropertyChanged(); }
        }
        #endregion
    }
}
