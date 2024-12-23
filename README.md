To start the project, navigate to the NumberGuessingTask folder where the docker-compose.yml file is located and run docker compose up -d --build.

Note that the API does not currently wait for the database to be ready, so you must ensure the database container is fully initialized before starting the API container.

The address of the API is https://localhost:8081/swagger/index.html
