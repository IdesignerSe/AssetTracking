# Asset Tracking System 

## 📝 How to Run it:
1.- Clone the repository

2.- Open in Visual Studio or VS Code 

3.- Build the project
    At the terminal: dotnet build

4.- Run the console application
    dotnet run

If assets.json does not exist, the program creates it automatically.

## 📂 Project Structure

AssetTracking/
│
├── Models/
│   ├── Asset.cs
│   ├── Computer.cs
│   ├── MobilePhone.cs
│   └── Tablet.cs
│
├── FileManager.cs
├── Program.cs
└── README.md

------------------------------------

## 🖥️ Example Console Output 

Loading assets from file...
5 assets loaded successfully.

=============================
COMPANY ASSET TRACKING SYSTEM
=============================

1. Add Asset
2. View Assets
3. Search Asset
4. Remove Asset
5. Exit

## 📄 Exported Report Example

ASSET REPORT
====================================
ID: 1
Type: Computer
Brand: Apple
Model: MacBook Pro
Office: Sweden
Price USD: 1500
Purchase Date: 2022-08-10