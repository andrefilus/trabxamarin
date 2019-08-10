using System;
using Prism.Navigation;
using Prism.Services;

namespace Okra.ViewModels
{
    public sealed class HomeViewModel: BaseViewModel
    {
        private readonly IPageDialogService pageDialogService;
        public HomeViewModel(INavigationService navigationService
            , IPageDialogService pageDialogService) : base(navigationService)
        {
            this.pageDialogService = pageDialogService;
        }
    }
}
