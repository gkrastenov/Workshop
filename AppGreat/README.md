
## Usage

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
POST: api/Orders
```

Change order status -> It will be given for params -> orderId and new status.

```http
POST: api/Orders/ChangeStatus
```

#### Products Endpoint
Get all products.

```http
GET: api/Products
```

GET specific product by id.

```http
GET: api/Products/5
```

Create product with params -> name and price.
```http
PUT: api/Products
```
Create product by given Id.
```http
DELETE: api/Products/5

```
