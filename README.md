🩸 Blood Bank Management System (C# Windows Forms)

My first major C# desktop project, independently developed during my 2nd semester using C# Windows Forms and Microsoft SQL Server. The application helps manage donor records, blood inventory, and user authentication.

📌 Features

🔐 User Authentication

- Login system for authorized users.

👤 Donor Management

- Add new donor records.
- Store donor information such as:
  - Name
  - Father's Name
  - Date of Birth
  - Contact
  - Gender
  - Blood Group
  - Address
- Update existing donor records.
- Search donors by blood group or address.
- View donor records.
- Delete donor records.

🩸 Blood Inventory

- Manage blood stock.
- Increase or decrease blood stock.
- View current blood stock.

🛠️ Technologies Used

- Language: C#
- Framework: .NET Framework / Windows Forms
- Database: Microsoft SQL Server
- Database Tool: SQL Server Management Studio (SSMS)
- IDE: Visual Studio

🗄️ Database

The project uses Microsoft SQL Server for storing application data.

A SQL database script is included in the "Database" folder:

Database/
└── SmartBloodBankSystem.sql

The SQL script contains the database structure and dummy/sample data required for the project.

▶️ How to Run

1. Open the SQL script from the "Database" folder in SSMS.
2. Execute the script to create the required database and tables.
3. Open the project solution (".sln") in Visual Studio.
4. Check the SQL Server connection string in the project.
5. Build and run the application.

📂 Project Type

Desktop Application

👩‍💻 Developed By

Amna
