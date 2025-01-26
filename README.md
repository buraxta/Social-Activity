# Social Network App with ASP.NET Core and React

This project is a fully functional social network application built from scratch using **ASP.NET Core** and **React**. It allows users to sign up, log in, create and join events, upload photos, chat in real-time, and interact with other users. The application is designed with **Clean Architecture**, **CQRS**, and **Mediator patterns** to ensure scalability, maintainability, and clean code organization.

## Key Features
- **User Authentication**: Secure login and registration using ASP.NET Core Identity.
- **Event Management**: Create, join, and manage events.
- **Photo Upload**: Upload and display user profile photos.
- **Real-Time Chat**: Integrated SignalR for real-time messaging.
- **Paging, Sorting, and Filtering**: Efficient data handling for large datasets.
- **Responsive UI**: Built with **Semantic UI** and **React** for a modern and user-friendly interface.
- **Form Handling**: Reusable forms with validation using **React Final Form**.
- **Deployment**: Ready for deployment to **IIS** or **Linux** with an 'A' security rating.

## Technologies Used
- **Backend**: ASP.NET Core 7, Entity Framework Core, AutoMapper, SignalR, CQRS + Mediator Pattern.
- **Frontend**: React 18, TypeScript, React Router v6, Semantic UI, React Final Form.
- **Authentication**: ASP.NET Core Identity.
- **Real-Time Communication**: SignalR.
- **Deployment**: IIS, Linux.

## Project Structure
The application is organized using **Clean Architecture**, with the following layers:
- **Domain**: Core business logic and entities.
- **Application**: Use cases, commands, queries, and validations.
- **Infrastructure**: Database access, identity management, and external services.
- **Presentation**: React frontend with API integration.
