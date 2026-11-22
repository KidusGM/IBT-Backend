# Addis Eats API — Endpoint Design
** Later on There will Be other Versions once we Progress through** `v2`, `v3`
**API version:** `v1`  
**Base path:** `/api/v1`  
**Project:** `AddisEatsNew.Api` (ASP.NET Core / .NET 10)

This document defines the API contract before implementation. Collection
paths use plural nouns, resource identifiers appear in the path, and
optional filters belong in the query string. Request validation failures
are client errors, not server errors.

| Method | Path                                       | Purpose                                                                                                                | Success | Likely failure |
|--------|--------------------------------------------|------------------------------------------------------------------------------------------------------------------------|--------:|---------------:|
| GET    | `/api/v1/restaurants`                      | Return a paginated list of restaurants; support filters such as `name`, `address`, and `isActive` in the query string. |     200 |            400 |
| GET    | `/api/v1/restaurants/{id}`                 | Return one restaurant by its identifier.                                                                               |     200 |            404 |
| GET    | `/api/v1/restaurants?name={name}`          | Find a restaurant by its name using a query filter.                                                                    |     200 |            404 |
| POST   | `/api/v1/restaurants`                      | Create a restaurant record for an authorized administrator.                                                            |     201 |            400 |
| GET    | `/api/v1/restaurants/{restaurantId}/menus` | Return the menu items belonging to a restaurant.                                                                       |     200 |            404 |
| GET    | `/api/v1/menu-items`                       | Return menu items; allow `restaurantId`, `category`, `minPrice`, and `maxPrice` filters in the query string.           |     200 |            400 |
| GET    | `/api/v1/menu-items/{id}`                  | Return one menu item by its identifier.                                                                                |     200 |            404 |
| POST   | `/api/v1/menu-items`                       | Create a menu item for a restaurant.                                                                                   |     201 |            400 |
| PUT    | `/api/v1/menu-items/{id}`                  | Replace the editable details of a menu item.                                                                           |     200 |            404 |
| DELETE | `/api/v1/menu-items/{id}`                  | Remove a menu item from the menu.                                                                                      |     204 |            404 |
| GET    | `/api/v1/orders`                           | Return the authenticated customer’s orders; staff may filter by `status` and `customerId`.                             |     200 |            401 |
| GET    | `/api/v1/orders/{id}`                      | Return one order and its order items.                                                                                  |     200 |            404 |
| POST   | `/api/v1/orders`                           | Create an order from menu-item identifiers and quantities.                                                             |     201 |            400 |
| PATCH  | `/api/v1/orders/{id}`                      | Update an order’s permitted status or details.                                                                         |     200 |            409 |
| GET    | `/api/v1/orders/{orderId}/payments`        | Return payment records associated with an order.                                                                       |     200 |            404 |
| GET    | `/api/v1/payments/{id}`                    | Return the status and details of one payment.                                                                          |     200 |            404 |
| POST   | `/api/v1/payments`                         | Create a payment attempt for an existing order.                                                                        |     201 |            400 |
| POST   | `/api/v1/users`                            | Create a customer account.                                                                                             |     201 |            409 |
| POST   | `/api/v1/sessions`                         | Authenticate credentials and create a session or issue an access token.                                                |     201 |            401 |
| DELETE | `/api/v1/sessions/current`                 | End the authenticated user’s current session.                                                                          |     204 |            401 |
| POST   | `/api/v1/password-resets`                  | Request a password-reset process for an account.                                                                       |     202 |            400 |

## Contract notes

- `200 OK` is used for successful reads and updates, not resource
  creation.
- `201 Created` is used when a new resource is created; `202 Accepted`
  is used for a reset request processed asynchronously.
- `204 No Content` is used when deletion or session termination succeeds
  without a response body.
- `400 Bad Request` represents malformed or invalid caller input; it
  must not be reported as `500 Internal Server Error`.
- `401 Unauthorized` means authentication is missing or invalid;
  `403 Forbidden` may be used when the user is authenticated but lacks
  permission.
- `404 Not Found` means the requested resource or parent resource does
  not exist.
- `409 Conflict` means the request conflicts with the current resource
  state, such as a duplicate account or an order that can no longer be
  changed.
- Restaurant and menu-item response DTOs must not expose internal or
  private fields such as `OwnerAddress`.
