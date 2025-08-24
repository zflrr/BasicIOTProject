using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using BasicIOT.Models;
using BasicIOT.Data;

namespace BasicIOT.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        // Public collections bound to the UI
        public ObservableCollection<Device> Devices { get; private set; }
        public ObservableCollection<string> Logs { get; } = new();

        // The device currently selected in the DataGrid
        private Device? selDevice;
        public Device? SelectedDevice
        {
            get => selDevice;
            set
            {
                selDevice = value;
                OnPropertyChanged(nameof(SelectedDevice));
            }
        }

        // Auto-increment id counter
        private int nextNoId;

        // Commands that exposed to the view
        public ICommand AddDeviceCommand { get; }
        public ICommand UpdateDeviceCommand { get; }
        public ICommand DeleteDeviceCommand { get; }
        public ICommand ToggleStatusCommand { get; }

        //MainViewModel Class
        public MainViewModel()
        {
            // Load mock/seed data from MockData class
            Devices = MockData.GetDevices();
            nextNoId = Devices.Count > 0 ? (Devices[^1].Id + 1) : 1; // next ID after last seed

            // Initialize commands
            AddDeviceCommand = new RelayCommand(_ => AddDevice());
            UpdateDeviceCommand = new RelayCommand(_ => UpdateDevice(), _ => SelectedDevice != null);
            DeleteDeviceCommand = new RelayCommand(_ => DeleteDevice(), _ => SelectedDevice != null);
            ToggleStatusCommand = new RelayCommand(_ => ToggleStatus(), _ => SelectedDevice != null);
        }

        // Add Device Function
        private void AddDevice()
        {
            var d = new Device
            {
                Id = nextNoId++,//generate ID
                Name = $"Device-{nextNoId - 1}", // Showing the "Device-Id" as default name
                Type = "Unknown",
                Status = "Offline", //default to Offline
                LastSeen = DateTime.Now
            };
            Devices.Add(d); //Add into Device Classes collection
            SelectedDevice = d;            // select immediately so user can edit inline
            Log($"Add - {d.Name} (Id={d.Id})");
        }

        // Update Function
        private void UpdateDevice()
        {
            if (SelectedDevice == null) return;
            SelectedDevice.LastSeen = DateTime.Now;
            Log($"Update - {SelectedDevice.Name} (Id={SelectedDevice.Id})");
            // Device properties already changed via two-way binding in the grid
        }

        // Delete Function
        private void DeleteDevice()
        {
            if (SelectedDevice == null) return;
            var name = SelectedDevice.Name;
            var id = SelectedDevice.Id;
            Devices.Remove(SelectedDevice);
            SelectedDevice = null;
            Log($"Delete - {name} (Id={id})");
        }

        // Toggle Offline and Online Function
        private void ToggleStatus()
        {
            if (SelectedDevice == null) return;
            SelectedDevice.Status = SelectedDevice.Status == "Online" ? "Offline" : "Online";
            SelectedDevice.LastSeen = DateTime.Now;
            Log($"ToggleStatus - {SelectedDevice.Name} (Id={SelectedDevice.Id}) → {SelectedDevice.Status}");
        }

        // Log Function
        private void Log(string message)
        {
            // Insert newest at top
            Logs.Insert(0, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}");
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
