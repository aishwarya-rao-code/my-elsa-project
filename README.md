# Elsa 3.5 Workflow Automation Project

This project is a customized implementation of [Elsa Workflows 3.5](https://elsa-workflows.github.io/elsa-core/) – a lightweight workflow engine built on .NET. It demonstrates how to build, manage, and visualize workflows for modern web applications using **Elsa Server** and **Elsa Studio**.

## 🚀 Features

- ✅ Elsa 3.5 integration for workflow orchestration  
- ✅ Built-in HTTP endpoints, timers, and activities  
- ✅ Visual workflow editor using Elsa Studio  
- ✅ Modular and extensible architecture  
- ✅ Built with ASP.NET Core and C#  
- ✅ REST API support for dynamic workflow execution  
- ✅ PowerShell script support (optional)

## 🛠️ Tech Stack

- C# (.NET Core 9.0)
- ASP.NET Core Web API
- Elsa Workflows 3.5 (Server + Studio)
- Entity Framework (optional for persistence)
- Bootstrap (for UI components)
- PowerShell (for script automation - optional)

## 📁 Project Structure
Elsa_3.5/

├── ElsaServerAndStudio

│ ├── ElsaServer/ # Backend server hosting the workflow engine

│ ├── ElsaStudio/ # Visual workflow editor (Blazor WebAssembly)

│

├── Elsa_With_Power_Shell_Scripts.zip # Optional PowerShell automation scripts

└── README.md

## 🧪 Getting Started

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/)
- Git
- Node.js (if modifying front-end components)
- Visual Studio or VS Code

### Run the Server & Studio

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/my-elsa-project.git
   cd my-elsa-project
   
### Restore packages:
```bash dotnet restore ```

### Run the server:
```bash cd ElsaServerAndStudio/ElsaServer dotnet run ``` 

### Run Elsa Studio (optional if already included in project build):
```bash cd ElsaServerAndStudio/ElsaStudio dotnet run ```

### Access: 
- Elsa Server API → http://localhost:5000
- Elsa Studio UI → http://localhost:5002
- You can define, trigger, and monitor workflows directly via Elsa Studio.

## Use Cases 
- Background job automation
- Event-driven microservices
- Approval flows
- Custom scripting integration (e.g., PowerShell)
  
## 📌 To Do 
- [ ] Add PostgreSQL persistence
- [ ] Deploy via Docker
- [ ] Integrate authentication for Elsa Studio

## 🤝 Contributing 
Contributions are welcome! Please fork the repo and submit a PR. 

## 📜 License
This project is licensed under the MIT License.
