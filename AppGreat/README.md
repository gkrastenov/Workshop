
## Usage

This REST API using in memory database. 
In the database is not set initial mock data. For tasting have to create some objects new user,product and order.
Launch the application and use the following routings
https://localhost:port/...

#### Authorization Endpoint
Get all users.

```http
GET: api/Users
```

Create new user with the following params - username, password and currency.
code

```http
POST: api/Users/Register
```

Login - username and password - in return, the API generate a token to be used for consequent calls.
```http
POST: api/Users/Login
```

#### Orders Endpoint
Get all orders.

```http
GET: api/Orders
```

GET specific order by id.

```http
GET: api/Orders/{id}
```

Get user orders.

```http
GET: api/Users/{id}/Orders
```

Create new order.

```http
POST: api/Orders/Create
```

Change order status -> It will be given for params -> set new status from 1 to 5

```http
POST: api/Orders/{id}/ChangeStatus
```

#### Products Endpoint
Get all products.

```http
GET: api/Products
```

GET specific product by id.

```http
GET: api/Products/{id}
```

Create product with params -> name and price.
```http
PUT: api/Products
```
Delete product by given Id.
```http
DELETE: api/Products/{id}

```
