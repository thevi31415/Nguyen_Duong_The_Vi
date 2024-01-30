# Blog cá nhân
![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Bootstrap](https://img.shields.io/badge/bootstrap-%238511FA.svg?style=for-the-badge&logo=bootstrap&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![CSS3](https://img.shields.io/badge/css3-%231572B6.svg?style=for-the-badge&logo=css3&logoColor=white)
![HTML5](https://img.shields.io/badge/html5-%23E34F26.svg?style=for-the-badge&logo=html5&logoColor=white)
![JavaScript](https://img.shields.io/badge/javascript-%23323330.svg?style=for-the-badge&logo=javascript&logoColor=%23F7DF1E)
![Git](https://img.shields.io/badge/git-%23F05033.svg?style=for-the-badge&logo=git&logoColor=white)
![TailwindCSS](https://img.shields.io/badge/Tailwind_CSS-38B2AC?style=for-the-badge&logo=tailwind-css&logoColor=white)
## Introduction
This is my personal website, built with ASP.NET Core 6. The interface is constructed using Bootstrap and Tailwind CSS

## Technologies Used
- ASP.NET 6 MVC: The core framework for building web applications with Model-View-Controller architecture.

- Entity Framework Core: An object-relational mapping (ORM) framework for .NET used for database interactions.

- C#: The primary programming language for building the application logic.

- HTML5 and CSS3: For structuring and styling the web pages.

- Bootstrap: A front-end framework for designing responsive and visually appealing user interfaces.
  
- Tailwind CSS: Utilized for efficient and utility-first styling, allowing for a highly customizable and maintainable design approach.

- JavaScript: Used for client-side scripting to enhance user interactions.

- SQL Server: The database management system employed for storing and managing data.

- Git: Version control system for tracking changes in the source code.

## Installation
1. Begin by cloning the project with the following command:
   `https://github.com/thevi31415/Nguyen_Duong_The_Vi.git`
2. Navigate to the  `appsettings.json` file and ensure the connection string is updated as follows:

   "ConnectionStrings": {
     "DefaultConnection": "Server=.;Database=blog;Trusted_Connection=True;"
   }

3. Remove the  `Migrations` folder from the project.
4. Open Tools > Package Manager > Package manager console
5. Execute the following two commands:
    ```
     (i) add-migration init
     (ii) update-database
     ````
6. You are now ready to launch the project.

## License

Copyright © 2024, [Nguyen Duong The Vi](https://github.com/thevi31415).
## References
- ASP.NET Documentation
- Entity Framework Core Documentation
- Bootstrap Documentation
