# December Retreat RSVP

A simple *Répondez s'il vous plaît* application for the Deeper Life Campus Fellowship (UNZA).

The goal of this project is to simply and automate the registration process. This should help the organizers in the planning process as they would be able to anticipate the number of registered visitors, members, and workers.

The application can be easily modified to accomodate any Retreat program.

## Technologies Used

| Tech | Version |
|------| --------|
| ASP.NET Core| 2.0.3|
| Entity Framework Core | 2.0.1|
| Semantic UI| 2.2.11|
| SQL Server | 2016 |

## Running locally

Simply clone the application and run the following commands in your terminal

> dotnet restore

> dotnet ef migrations add

> dotnet ef database update

This should set up the dependencies and the database, respectively.

Finally run the following command

> dotnet run

This should open up a port which links to the home page.

![alt text](/Screenshots/home.png)


## License

MIT License.
