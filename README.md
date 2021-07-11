# ASP.net Customer Database
---

An ASP.net web API that queries a MsSQL database backend for customer data, written in C#.

## Installation
---
It's recommended to run this project via Docker.

1. Check the project out via git.
2. `cd` into the root directory for the project.
3. Run command: `docker-compose up`

```bash
# Clone this repository
$ git clone https://github.com/ashleymorris2/CF247.git

# Change directory into the repository
$ cd CF247

# Build and start the necessary containers
$ docker-compose up

```

## Usage instructions
Testing can be done using [Postman](https://www.postman.com/), [Insomnia](https://insomnia.rest/) or a similar rest api testing client. Whilst running in docker the api uses http for requests and is listening on port `5001` by default. This can be changed in the docker-compose file if necessary.

---

### Get all customers

#### Request
`GET /api/customers`

#### Response
```json
[
    {
        "id": 1,
        "firstName": "Shirley",
        "surname": "Murray",
        "email": "aiyana.hue6@gmail.com",
        "password": "ga5eiY8Ewee"
    },
    {
        "id": 2,
        "firstName": "Matthew",
        "surname": "McNeill",
        "email": "marquis_les@gmail.com",
        "password": "quieCoodi6P"
    },
    {
        "id": 3,
        "firstName": "Richard ",
        "surname": "Headley",
        "email": "alvis2012@yahoo.com",
        "password": "kahghei1aSu"
    },
    {
        "id": 4,
        "firstName": "Elizabeth",
        "surname": "Marcus",
        "email": "palma_oconn@hotmail.com",
        "password": "ceZui6ok"
    }
]
```

---

### Get a customer

#### Request
`GET /api/customers/{id}`

#### Response

```json
{
    "id": 3,
    "firstName": "Richard ",
    "surname": "Headley",
    "email": "alvis2012@yahoo.com",
    "password": "kahghei1aSu"
}

```

--- 

### Create a customer

#### Request
`POST /api/customers`

```json
{
    "firstName": "Laura",
    "surname": "Haar",
    "email": "lh@gmail.com",
    "password": "faoidsasaaas"
}
```

#### Response

```json
{
    "id": 7,
    "firstName": "Laura",
    "surname": "Haar",
    "email": "lh@gmail.com",
    "password": "faoidsasaaas"
}
```

---

### Update a customer

#### Request
`PUT /api/customers/{id}`

```json
{
    "firstName": "Barry",
    "surname": "Daniels",
    "email": "barry@gmail.com",
    "password": "faoiaas"
}
```

#### Response


```json
[]
```

---

### Delete a customer

#### Request
`DELETE /api/customers/{id}`

#### Response

```json
[]
```
