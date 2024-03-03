# Personal blog
  ![MIT License](https://img.shields.io/github/license/dotnet/aspnetcore?color=%230b0&style=flat-square)
  ![GitHub repo size](https://img.shields.io/github/repo-size/thevi31415/Nguyen_Duong_The_Vi)
  ![GitHub code size in bytes](https://img.shields.io/github/languages/code-size/thevi31415/Nguyen_Duong_The_Vi)
  ![GitHub repo file or directory count](https://img.shields.io/github/directory-file-count/thevi31415/Nguyen_Duong_The_Vi)
  ![GitHub contributors](https://img.shields.io/github/contributors/thevi31415/Nguyen_Duong_The_Vi)
  ![GitHub last commit](https://img.shields.io/github/last-commit/thevi31415/Nguyen_Duong_The_Vi)
  ![YouTube Channel Subscribers](https://img.shields.io/youtube/channel/subscribers/UCHolhpqtcjh-r4bICRRnqyA)

 
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
- Link: 
This is my personal website, built with ASP.NET Core 6. The interface is constructed using Bootstrap and Tailwind CSS. For the back-end, I utilize the C# programming language and Microsoft SQL Server for the database, following the Code First approach in database design

The website interface is primarily built using Tailwind CSS:
<p align="center">
  <a href="https://tailwindcss.com" target="_blank">
    <picture>
      <source media="(prefers-color-scheme: dark)" srcset="https://raw.githubusercontent.com/tailwindlabs/tailwindcss/HEAD/.github/logo-dark.svg">
      <source media="(prefers-color-scheme: light)" srcset="https://raw.githubusercontent.com/tailwindlabs/tailwindcss/HEAD/.github/logo-light.svg">
      <img alt="Tailwind CSS" src="https://raw.githubusercontent.com/tailwindlabs/tailwindcss/HEAD/.github/logo-light.svg" width="350" height="70" style="max-width: 100%;">
    </picture>
  </a>
</p>
In the process of coding the project, I referenced and copied some interfaces and templates available on the Internet, making modifications as needed.

## Blog
- Home:
  
![H34](https://github.com/thevi31415/Nguyen_Duong_The_Vi/assets/92256900/f49ee5a5-3d2b-4bee-86fb-e96f2d493af9)

![T2](https://github.com/thevi31415/Nguyen_Duong_The_Vi/assets/92256900/58ab483f-437f-4983-accd-bacac7afc614)

- Post display page:

![H3](https://github.com/thevi31415/Nguyen_Duong_The_Vi/assets/92256900/5a0998a6-46a1-4f7d-a828-41dfc8cb6078)

- View article details::

![H4](https://github.com/thevi31415/Nguyen_Duong_The_Vi/assets/92256900/acd650fa-141f-43cf-9c84-55357f312ba8)

![H5](https://github.com/thevi31415/Nguyen_Duong_The_Vi/assets/92256900/c9a170e8-9dc2-4510-bf87-19eaf46e42f1)

- Display mathematical formulas within the article:
  
![H13](https://github.com/thevi31415/Nguyen_Duong_The_Vi/assets/92256900/5eba9162-0f2a-4ae9-a28a-66848dc5cd5a)

- Comment below the article:
  
![T1](https://github.com/thevi31415/Nguyen_Duong_The_Vi/assets/92256900/f09663b5-7525-4469-a3f0-a6ceab2f6a22)

 - View the personal information of a user account:

![H15](https://github.com/thevi31415/Nguyen_Duong_The_Vi/assets/92256900/a99db699-2dcc-4e1d-99c9-182aa3a16204)

- Filter posts by Tags:
  
![H6](https://github.com/thevi31415/Nguyen_Duong_The_Vi/assets/92256900/2d68ad7f-d284-42ef-a2bd-c728b3b5ebc3)

![H7](https://github.com/thevi31415/Nguyen_Duong_The_Vi/assets/92256900/7597e573-1c8d-4003-924d-69d02a594061)

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
- https://github.com/timlrx/tailwind-nextjs-starter-blog
- https://tailwindui.com/components
- https://flowbite.com/docs/components/
