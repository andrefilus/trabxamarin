using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;

namespace Okra.ViewModels
{
    public abstract class BaseViewModel : BindableBase, INavigationAware
    {
        protected BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public INavigationService NavigationService { get; }

        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }   

        public bool IsNotBusy => !IsBusy;

        protected async Task ExecuteBusyAction(Func<Task> theBusyAction)
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                await theBusyAction();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }
    }
}
