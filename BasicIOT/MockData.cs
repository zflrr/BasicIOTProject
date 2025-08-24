using System;
using System.Collections.ObjectModel;
using BasicIOT.Models;

namespace BasicIOT.Data
{
    //sample mock data for seeding the application
    public static class MockData
    {
        public static ObservableCollection<Device> GetDevices()
        {
            return new ObservableCollection<Device>
            {
                new Device { Id = 1, Name = "Device - Web Camera", Type = "Web Camera", Status = "Online", LastSeen = DateTime.Now.AddMinutes(-2) },
                new Device { Id = 2, Name = "Device - Door Gate", Type = "Door", Status = "Offline", LastSeen = DateTime.Now.AddMinutes(-30) },
                new Device { Id = 3, Name = "Device - Room Cam", Type = "Camera", Status = "Online", LastSeen = DateTime.Now.AddMinutes(-5) }
            };
        }
    }
}
