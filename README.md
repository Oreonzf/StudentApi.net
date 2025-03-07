# Student API

This is a simple **ASP.NET Core API** for managing student records. It uses **MariaDB** as the database and is **containerized** using Docker.

## Features

- **CRUD Operations**: Create, Read, Update, and Delete student records.
- **Docker Support**: Easily run the application and database using Docker.
- **Entity Framework Core**: ORM for seamless database interactions.
- **Swagger Documentation**: API documentation available at runtime.

## Prerequisites

Before running the project, ensure you have the following installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/install/)

## Getting Started

Follow these steps to set up and run the project locally.

### 1. Clone the Repository

```bash
git clone https://github.com/Oreonzf/StudentApi.net
```

### 2. Set Up Environment Variables

Ensure your environment variables are set in the `appsettings.json` or in the Docker environment. Specifically, configure the MariaDB connection string.

### 3. Build and Run with Docker

Run the following commands to build and start the Docker containers:

```bash
docker-compose up --build
```

This will:

- Start a **MariaDB** database container.
- Build and start the **ASP.NET Core API** container.

### 4. Access the API

Once the containers are running, you can access the API at:

- **Swagger UI**: [http://localhost:5000/swagger](http://localhost:5000/swagger)
- **API Endpoint**: [http://localhost:5000/api/students](http://localhost:5000/api/students)

### 5. Stop the Containers

To stop the containers, run:

```bash
docker-compose down
```

## API Endpoints

### Students

- **GET /api/students**: Get all students.
- **GET /api/students/{id}**: Get a student by ID.
- **POST /api/students**: Create a new student.
- **PUT /api/students/{id}**: Update a student by ID.
- **DELETE /api/students/{id}**: Delete a student by ID.

## Example Requests

### Create a Student

```bash
curl -X POST "http://localhost:5000/api/students" \
-H "Content-Type: application/json" \
-d '{
  "nome": "Rafael",
  "sobrenome": "Cavalcante",
  "matricula": "123",
  "telefone": "11987654321"
}'
```

### Get All Students

```bash
curl -X GET "http://localhost:5000/api/students"
```

## Database Schema

The database consists of a single table:

### Students Table

| Column     | Type        | Description                       |
|------------|-------------|-----------------------------------|
| Id         | BIGINT      | Primary key                       |
| Nome       | VARCHAR(50) | Student's first name             |
| Sobrenome  | VARCHAR(50) | Student's last name              |
| Matricula  | VARCHAR(50) | Student's registration number    |
| Telefone   | VARCHAR(20) | Student's phone number           |

## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/YourFeatureName`).
3. Commit your changes (`git commit -m 'Add some feature'`).
4. Push to the branch (`git push origin feature/YourFeatureName`).
5. Open a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
