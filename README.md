# Kanban

How to run -
Powershell or bash command - docker compose up --build 
Migrations will be initiated on Docker startup. 
Connection strings are currently set to db (the containerized database). These need to be updated if you wish to run the app locally using localhost.

This app demonstrates Clean Architecture and CQRS using minimal API endpoints and a homebrewed Mediator (not dependency-injected).

Redis caching is implemented along with SignalR and NotificationHandlers to invalidate the cache on POST, PUT, DELETE, and PATCH requests, ensuring no stale data is sent to the client.

Hypermedia (HATEOAS) is implemented in pagination handlers for enhanced API discoverability.

Validation:
Data Annotations in POCOs
FluentValidation for input DTOs

Uses the Result pattern and a Global Exception Handler to prevent unnecessary information from being exposed to clients.

ASP.NET Core HealthChecks and Prometheus net metrics as well as RateLimiter are applied. 

Why use strings for DateTime?
In my experience, handling DateTime values as ISO 8601-formatted strings in the frontend and sending them to the API as strings can significantly reduce confusion and bugs related to timezone handling.
When hosting applications—such as on SmarterASP.net, with servers located in the Netherlands—I observed significant discrepancies (sometimes up to an hour) between the date selected by the user and what was persisted in the database. This issue was especially problematic when working across different timezones.

By allowing the client to:
1.Select a date/time using their local system settings,
2.Convert it to an ISO 8601 string in the frontend,
3.And send that string to the API,
...we ensure that the intended value is accurately preserved throughout the system, without relying on implicit timezone conversions that often lead to bugs.

This approach puts formatting and timezone responsibility on the client side, which typically has more context about the user's locale and intent. The API can then safely parse the ISO 8601 string as UTC or local time, depending on the use case.