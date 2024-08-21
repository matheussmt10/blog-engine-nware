## Getting Started

These instructions will get you a copy of the full project up and running on your local machine for development and testing purposes.

## Setting up Databases and Services

The project uses [MySql](https://www.mysql.com/downloads/) as a development database.

I recommend using [Docker](https://www.docker.com) to install and run all project, because all backend, database and frontend are into the docker container.

## How to Install

### Backend (API)

* To download the project follow the instructions below:

```
1. git clone https://github.com/matheussmt10/blog-engine-nware.git

```

* Install the dependencies and start the server:

```
2. open blogengine.API by Visual Studio
4. set docker-compose project as Startup Project
5. press F5
6. both services will start together when the container is ready.
```

Also, I'm sending the Postman file to call the API, download it [here](https://github.com/matheussmt10/blog-engine-nware/blob/main/blog-engine.postman_collection.json).

### Frontend (React)

* The frontend project start up together with the backend project if I start the project up with docker compose.


or


* If you wish to start the frontend project up indiviually, you could follow the instructions below:
```
1. cd frontend
2. npm install
3. npm run dev

```

# API Endpoints

## Categories

| Method | Endpoint              | Description                                |
|--------|-----------------------|--------------------------------------------|
| POST   | `/categories`         | Create a new category                      |
| GET    | `/categories`         | Retrieve all categories                    |
| GET    | `/categories/{id}`    | Retrieve details of a single category      |
| GET    | `/categories/{id}/posts` | Retrieve all posts for a given category |
| PUT    | `/categories/{id}`    | Edit the details of a category             |
| DELETE | `/categories/{id}`    | Delete a single category                   |

## Posts

| Method | Endpoint       | Description                         |
|--------|----------------|-------------------------------------|
| POST   | `/posts`       | Create a new post                   |
| GET    | `/posts`       | Retrieve all posts                  |
| GET    | `/posts/{id}`  | Retrieve details of a single post   |
| PUT    | `/posts/{id}`  | Edit the details of a post          |
| DELETE | `/posts/{id}`  | Delete a single post                |

## License

This project could be used by anyone! MIT License