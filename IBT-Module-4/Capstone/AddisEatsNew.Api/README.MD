## API Route Table

| Method | Endpoint | Description | Success | Failure |
|---|---|---|---|---|
| GET | `/api/v1/menu-items` | Retrieve menu items | 200 | 500 |
| GET | `/api/v1/menu-items/{id}` | Retrieve menu item by ID | 200 | 400, 404, 500 |
| GET | `/api/v1/orders/{id}` | Retrieve order by ID | 200 | 400, 404, 500 |
| POST | `/api/v1/orders` | Create an order | 201 | 400, 404, 500 |
| GET | `/api/v1/restaurants` | Retrieve restaurants | 200 | 500 |
| GET | `/api/v1/restaurants/{id}` | Retrieve restaurant by ID | 200 | 400, 404, 500 |
| GET | `/api/v1/restaurants?name={name}` | Filter restaurants by name | 200 | 400, 500 |
| GET | `/api/v1/restaurants?is-active=true` | Retrieve active restaurants | 200 | 400, 500 |

## Error Catalog

| Status Code | Error | Description |
|---|---|---|
| 400 | Bad Request | Invalid request or validation failure |
| 404 | Not Found | The requested resource does not exist |
| 409 | Conflict | The request conflicts with existing data |
| 500 | Internal Server Error | An unexpected server error occurred |

## Error Response Format

Errors are returned using a consistent response structure.

Example:

```json
{
  "status": 404,
  "title": "Resource not found",
  "detail": "The requested resource was not found."
}
```
