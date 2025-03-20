
# LifeStream 🏥

A **full-featured Hospital Management System** built to streamline healthcare operations, manage hospital data efficiently, and enhance doctor-patient interactions.

## 🌟 Overview

**LifeStream** is a modular, scalable hospital management platform developed using **ASP.NET Core MVC** and **Entity Framework**, with responsive front-end design using **Bootstrap, HTML5, and jQuery**. It helps manage patient records, appointments, doctors, prescriptions, billing, and more.

---

## ✨ Key Features

- **🔐 Authentication & Authorization**
  - Secure role-based login for Admins, Doctors, and Patients.
  - Session handling with logout timeout.

- **👤 Patient Management**
  - Add, view, edit, and delete patient profiles.
  - Upload documents and manage visit history.

- **👨‍⚕️ Doctor Dashboard**
  - View appointment schedules.
  - Add diagnosis and prescriptions.
  - Manage availability and patient follow-ups.

- **📅 Appointment System**
  - Book and manage appointments between patients and doctors.
  - Calendar UI for scheduling.

- **💊 Prescription Management**
  - Doctors can prescribe medicines with dosage and duration.
  - Patients can access prescription history.

- **💵 Billing Module**
  - Auto-generated invoices for appointments.
  - View and download payment receipts.

- **📊 Admin Panel**
  - Dashboard with analytics.
  - Manage users, doctors, patients, and settings.
  - View hospital-wide reports.

---

## 🛠️ Tech Stack

| Layer         | Technology                       |
|---------------|----------------------------------|
| **Frontend**  | HTML5, CSS3, Bootstrap, jQuery   |
| **Backend**   | ASP.NET Core MVC (C#)            |
| **Database**  | SQL Server / EF Core ORM         |
| **Auth**      | ASP.NET Identity                 |
| **Hosting**   | IIS / Azure / Local Development  |

---

## 🚀 Getting Started

### Prerequisites

- [.NET SDK 6.0+](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) with ASP.NET & EF tools

### Installation Steps

1. **Clone the Repository**

```bash
git clone https://github.com/HardikMasalawala88/LifeStream.git
cd LifeStream
```

2. **Set up Database**

- Open `appsettings.json` and configure your SQL Server connection string.
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=LifeStreamDB;Trusted_Connection=True;"
}
```

- Run the EF Core migration to generate DB schema:
```bash
Update-Database
```

3. **Run the Application**

- In Visual Studio, set the startup project and hit **F5** or run:
```bash
dotnet run
```

---

## 📷 Screenshots

> _Add screenshots or GIFs showing dashboards, appointment system, prescription entry, etc._

---

## 👥 User Roles

| Role      | Description                       |
|-----------|-----------------------------------|
| **Admin** | Manage doctors, patients, users. View analytics. |
| **Doctor**| View appointments, prescribe treatment. |
| **Patient** | Book appointments, view prescriptions. |

---

## 🤝 Contribution Guidelines

1. Fork this repository.
2. Create your feature branch (`git checkout -b feature/my-feature`).
3. Commit your changes (`git commit -m 'Add feature'`).
4. Push to the branch (`git push origin feature/my-feature`).
5. Open a pull request.

---

## 📄 License

This project is licensed under the **MIT License**.  
See the [LICENSE](./LICENSE) file for more info.

---

## 📬 Contact

**Author:** Hardik Masalawala  
📧 [LinkedIn](https://www.linkedin.com/in/hardik-masalawala-24nov/)

---
