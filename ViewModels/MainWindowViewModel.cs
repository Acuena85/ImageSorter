using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Threading.Tasks;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.VisualTree;
using Avalonia.Threading;

namespace ImageSorter.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty] private bool showIndexingInfo = true;
        [ObservableProperty] public string textInfo = "Indexing files: 0 found";
        [ObservableProperty] public int test = 0; // Just for testing
        [ObservableProperty] public string? selectedFolder;

       
        [RelayCommand]
        public void TestButton()
        {
            if (!ShowIndexingInfo) return;
            Test++;
            TextInfo = $"Indexing files: {Test} found";
        }

        [RelayCommand]
        public async void SelectFolder()
        {
            var dialog = new OpenFolderDialog();

            // Set the initial directory (optional)
            dialog.Directory = "C:\\";

            // Show the folder selection dialog asynchronously
            var app = (IClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime;
            var mainWindow = app.MainWindow;
            var selectedFolder = await dialog.ShowAsync(mainWindow);

            if (selectedFolder != null)
            {
                // Do something with the selected folder path
                // For example, display it in a text box
                SelectedFolder = selectedFolder;
            }
        }
    }
}