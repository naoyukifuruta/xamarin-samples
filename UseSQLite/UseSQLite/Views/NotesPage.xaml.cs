using UseSQLite.Models;
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

            listView.ItemsSource = await App.Database.GetNotesAsync();
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new NoteEntryPage
                {
                    BindingContext = e.SelectedItem as Note
                });
            }
        }
    }
}
