# Contact Manager API
REST API which manages contact records.


---
## Features
Stores, retrieves, updates, and deletes contact records.



## Documentation

### [API Specifications and Test Harness](https://cmbscontactmanagerapi.azurewebsites.net/)


### Endpoints
| Method | Endpoint                        | Description                                        |
|--------|---------------------------------|----------------------------------------------------|
| GET    | `/contacts` | List all contacts.       |
| GET    | `/contacts/:id` | Get a specific contact with the provided `id`. |
| GET    | `/contacts/call-list` | Get a list of all contacts with home phone numbers. |
| POST    | `/contacts` | Create a new contact. |
| PUT    | `/contacts/:id` | Update a ticket.                   |
| DELETE | `/contacts/:id` | Delete a contact.                            |



## Technologies

- [.NET 5](https://dotnet.microsoft.com/download)
- [ASP.NET Core 5](https://docs.microsoft.com/en-us/aspnet/core)
- [LiteDB](http://www.litedb.org/)



## Installation
- Clone this repo to your local machine from `https://github.com/wmemorgan/contact-manager-api`


## Setup and Usage
<details>
<summary>Command Line</summary>

#### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download/dotnet)

#### Steps

1. Open directory **source\ContactManagerApi** in command line and execute **dotnet run**.
2. Open <https://localhost:5001>.

</details>

<details>
<summary>Visual Studio Code</summary>

#### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download/dotnet)
- [Visual Studio Code](https://code.visualstudio.com)
- [C# Extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)

#### Steps

1. Open **source** directory in Visual Studio Code.
2. Press **F5**.

</details>

<details>
<summary>Visual Studio</summary>

#### Prerequisites

- [Visual Studio](https://visualstudio.microsoft.com)


#### Steps

1. Open **source\ContactManagerApi.sln** in Visual Studio.
2. Set **ContactManagerApi** as startup project.
3. Press **F5**.

</details>



## License
[MIT](https://github.com/wmemorgan/contact-manager-api/blob/master/LICENSE)