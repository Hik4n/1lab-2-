using QueueApp.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace QueueApp.ViewModels
{
    public class QueueViewModel : INotifyPropertyChanged
    {
        private Queue<string> queue;

        public QueueViewModel()
        {
            queue = new Queue<string>();
        }

        public string? CurrentItem => queue.Count > 0 ? queue.CurrentItem : null; 
        public int Count => queue.Count;
        public bool IsEmpty => queue.IsEmpty;

        public void Enqueue(string item)
        {
            queue.Enqueue(item);
            OnPropertyChanged(nameof(CurrentItem));
            OnPropertyChanged(nameof(Count));
            OnPropertyChanged(nameof(IsEmpty));
        }

        public string Dequeue()
        {
            string item = queue.Dequeue();
            OnPropertyChanged(nameof(CurrentItem));
            OnPropertyChanged(nameof(Count));
            OnPropertyChanged(nameof(IsEmpty));
            return item;
        }

        public void Clear()
        {
            queue.Clear();
            OnPropertyChanged(nameof(CurrentItem));
            OnPropertyChanged(nameof(Count));
            OnPropertyChanged(nameof(IsEmpty));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}