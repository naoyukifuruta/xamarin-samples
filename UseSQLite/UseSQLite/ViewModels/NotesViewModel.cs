using System;
using System.Threading.Tasks;
using System.Windows.Input;
using UseSQLite.Models;
using UseSQLite.Views;
using Xamarin.Forms;

namespace UseSQLite.ViewModels
{
    public class NotesViewModel
    {
        public ICommand NoteAddCommand { get; set; }

        public ICommand ListTappedCommand { get; set; }

        private INavigation _navigation;

        public NotesViewModel(INavigation navigation)
        {
            _navigation = navigation;

            NoteAddCommand = new Command(async () => await AddNote());

            ListTappedCommand = new Command<Note>(async (note) => await TapListViewItem(note));
        }

        public void OnAppearing()
        {

        }

        private async Task AddNote()
        {
            await _navigation.PushAsync(new NoteEntryPage
            {
                BindingContext = new Note()
            });
        }

        private async Task TapListViewItem(Note note)
        {
            await _navigation.PushAsync(new NoteEntryPage
            {
                BindingContext = note
            });
        }
    }
}
