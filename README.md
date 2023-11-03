# grocery-list

## Project Structure

This .NET application is structured into distinct layers, each serving a specific purpose:

- **GroceryList.Api**:
  - The API layer responsible for handling incoming requests and responses.
  - Exposes endpoints to interact with the application.

- **GroceryList.Core**:
  - The core layer representing the heart of the application, containing the domain model.
  - Defines domain entities, value objects and repositories.
  - Enforces domain-specific business rules and logic.

- **GroceryList.Application**:
  - The application layer responsible for orchestrating domain logic and application-specific operations.
  - Defines application services that use the Core layer to interact with the domain model.

- **GroceryList.Infrastructure**:
  - The infrastructure layer responsible for data access, external services, and integration.
  - Manages data storage using Entity Framework or other data access technologies.