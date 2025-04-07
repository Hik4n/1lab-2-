using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using QueueApp.ViewModels;

namespace QueueApp
{
    public partial class MainWindow : Window
    {
        private QueueViewModel viewModel;

        public MainWindow()
        {
            try
            {
                InitializeComponent();
                viewModel = new QueueViewModel();
                DataContext = viewModel;
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Ошибка: {ex.Message}");
                viewModel = new QueueViewModel();
            }
        }

        private void Enqueue_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(InputBox.Text))
            {
                viewModel.Enqueue(InputBox.Text);
            }
            else
            {
                ShowErrorMessage("Поле ввода не может быть пустым.");
            }
        }

        private void Dequeue_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                viewModel.Dequeue();
            }
            catch (InvalidOperationException ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Clear();
        }

        private async void ShowErrorMessage(string message)
        {
            var dialog = new Window
            {
                Title = "Ошибка",
                Content = new TextBlock { Text = message },
                SizeToContent = SizeToContent.WidthAndHeight
            };
            await dialog.ShowDialog(this);
        }
    }
}