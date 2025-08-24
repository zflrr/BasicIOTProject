# Basic IOT Devices Manager

##  **Setup / Build Instructions**

1. Install Visual Studio 2022 (Community edition is fine).
2. Make sure .NET 6.0 or later SDK is installed.
3. Clone or download this project folder.
4. Open the .sln file in Visual Studio.
5. Press F5 (Run) to build and launch the application.

## **Summary of Completed Items**
**1. Device Model**
Implements INotifyPropertyChanged for real-time UI updates.\
Supports fields: Id, Name, Type, Status, LastSeen.\
**2. Main Features**
Add Device – User can add new simulated devices.\
Update Device – Modify device properties.\
Delete Device – Remove devices from the list.\
Toggle Status – Simulate Online/Offline connectivity.\
Action Logs – Record every user action (Add, Update, Delete, Toggle).\
**3. Connectivity Handling**
Devices can be switched to Offline to simulate failure.\
Logs capture connectivity changes.\
**4. UI (WPF, MVVM)**
Device list is automatically updated when properties change.
Logs display history of actions.

## **Tools / Libraries Used**
- C# .NET 6.0 – Core programming language & framework.
- WPF (Windows Presentation Foundation) – For building the desktop UI.
- MVVM Pattern – Used for clean separation of UI and logic.
- System.ComponentModel – Provides INotifyPropertyChanged for real-time UI updates.
