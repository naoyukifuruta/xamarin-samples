using UseSQLite.ViewModels;
using Xamarin.Forms;

namespace UseSQLite.Views
{
    public partial class NotesPage : ContentPage
    {
        private NotesViewModel _notesViewModel;

        public NotesPage()
        {
            InitializeComponent();
            BindingContext = _notesViewModel = new NotesViewModel(this.Navigation);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            _notesViewModel.OnAppearing();

            // TODO: ViewModel
            listView.ItemsSource = await App.Database.GetNotesAsync();
        }
    }
}
