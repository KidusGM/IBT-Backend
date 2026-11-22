# AddisEats API Design Exercises

## Exercise 1: Route Table

| Method | Path | Purpose | Success | Failure |
|---|---|---|---|---|
| GET | `/api/v1/restaurants` | Get restaurants | 200 | 400 |
| GET | `/api/v1/restaurants/{id}/menu` | Get restaurant menu | 200 | 404 |

## Exercise 2: Identifiers and Filters

| Path Segment | Type |
|---|---|
| `restaurants` | Resource |
| `{id}` | Identifier |
| `area` | Filter |
| `page` | Filter |
| `limit` | Filter |

Identifiers belong in the path. Filters belong in query parameters.

Example:

`GET /api/v1/restaurants?area=Bole&page=1&limit=5`

## Exercise 3: Avoid Verbs in Paths

Examples:

| Bad Route | Better Route |
|---|---|
| `/getRestaurants` | `GET /restaurants` |
| `/createOrder` | `POST /orders` |
| `/deleteOrder/5` | `DELETE /orders/5` |

I chose resource-based routes because the HTTP method already describes the action.

## Exercise 4: Error Catalogue

| Code | Status | Message |
|---|---|---|
| E001 | 400 Bad Request | Invalid request. |
| E002 | 401 Unauthorized | Authentication is required. |
| E003 | 403 Forbidden | You do not have permission. |
| E004 | 404 Not Found | Resource not found. |
| E005 | 409 Conflict | The request conflicts with the current state. |
| E006 | 422 Unprocessable Entity | The request data is invalid. |
| E007 | 429 Too Many Requests | Too many requests. |
| E008 | 500 Internal Server Error | An unexpected error occurred. |

## Exercise 5: Status Codes

| Scenario | Status | Reason |
|---|---|---|
| Search returns no rows | 200 OK | The search succeeded and returned an empty list. |
| Cancel an order that is delivered | 409 Conflict | The order cannot be cancelled in its current state. |
| Request has a negative ETB total | 400 Bad Request | The request contains an invalid amount. |
| Courier tries to edit a menu | 403 Forbidden | The courier is authenticated but does not have permission. |

## Exercise 6: Rewrite Bad Routes

I will rewrite the twelve routes from the class exercise using REST resource names and HTTP methods.

## Exercise 7: REST, GraphQL, or gRPC

| Scenario | Choice | Reason |
|---|---|---|
| Public mobile API | REST | REST is simple and widely supported by mobile apps. It is easy to test and document. |
| Internal service-to-service | gRPC | gRPC is efficient and uses strongly typed contracts. It is suitable for communication between backend services. |
| Dashboard needing six resources | GraphQL | GraphQL can request multiple resources in one query. The dashboard can request only the fields it needs. |

## Exercise 8: Unknown Query Parameters

**Decision: Ignore unknown query parameters.**

ASP.NET Core ignores unknown query parameters by default. I will keep this behavior consistent across the API.

Example:

`GET /api/v1/restaurants?unknown=value`

The API processes the known parameters and ignores `unknown`.
