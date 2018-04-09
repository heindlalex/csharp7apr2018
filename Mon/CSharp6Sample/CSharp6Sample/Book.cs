using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CSharp6Sample
{
    public class Book : INotifyPropertyChanged
    {
        private string _title;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);

        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            // PropertyChanged(this, new PropertyChangedEventArgs(propertyName));  // throws on null!

            var handler = PropertyChanged;  // thread-safe

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T item, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(item, value)) return false;
            item = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
