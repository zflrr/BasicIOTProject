using System;
using System.ComponentModel;

namespace BasicIOT.Models
{
    /// Device model implements INotifyPropertyChanged so the UI updates when a property changes.
    /// Initialize the object with default values.

    public class Device : INotifyPropertyChanged
    {
        private int NoId;
        private string devName = string.Empty;
        private string devType = string.Empty;
        private string devStatus = "Offline";
        private DateTime devLastSeen = DateTime.Now;

        public int Id
        {
            get => NoId;
            set { NoId = value; OnPropertyChanged(nameof(Id)); }
        }

        public string Name
        {
            get => devName;
            set { devName = value; OnPropertyChanged(nameof(Name)); }
        }

        public string Type
        {
            get => devType;
            set { devType = value; OnPropertyChanged(nameof(Type)); }
        }

        public string Status
        {
            get => devStatus;
            set { devStatus = value; OnPropertyChanged(nameof(Status)); }
        }

        public DateTime LastSeen
        {
            get => devLastSeen;
            set { devLastSeen = value; OnPropertyChanged(nameof(LastSeen)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
