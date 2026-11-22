HTTP and API Fundamentals
AddisEats API – Assignment
1. What is a server?
A server is like a waiter in a restaurant. You ask the waiter for something, such as a menu or a meal. The waiter takes your request to the kitchen and brings back what you asked for. In the same way, when you open a website, your phone or laptop sends a request to a server. The server receives the request, finds the information, and sends it back. For example, when you log in to Facebook, the server checks your account details and sends your profile and messages to your screen. A server helps many people access information and services through a network.
2. Three HTTP requests
The following examples use the AddisEats API running locally on port 5201.
#	Method	Full path	Status code	Request body
1	GET	http://localhost:5201/Api/OrderControllers/1	200 OK	No
2	POST	http://localhost:5201/Api/OrderControllers	201 Created	Yes
3	GET	http://localhost:5201/api/v1/MenuItemConrollers	200 OK	No


3. Request and response headers
Request headers for the order creation request:
- Accept: / — The client can accept any response content type.
- Content-Type: application/json — The request body contains JSON data.
- Host: localhost:5201 — Identifies the server host and port.
- User-Agent: Swagger UI — Identifies the client software making the request.
  Response headers:
- Content-Type: application/json; charset=utf-8 — The response body is JSON encoded as UTF-8.
- Date: Sat, 21 Nov 2026 17:03:28 GMT — Shows when the server generated the response.
- Server: Kestrel — Identifies the web server software.
- Location: http://localhost:5201/Api/OrderControllers/1 — Gives the URL of the newly created order.
4. Full HTTP request to create an order
This example creates an order for two portions of menu item 7 from restaurant 14 in Bole, with TeleBirr selected as the payment method.

POST /Api/OrderControllers HTTP/1.1
Host: localhost:5201
Content-Type: application/json
Accept: application/json
User-Agent: AddisEatsClient/1.0

{
"restaurantId": 14,
"menuItemId": 7,
"customerName": "Abebe",
"deliveryAddress": "Bole, Addis Ababa",
"customerPhone": "+251911000000",
"quantity": 2,
"totalAmount": 400,
"paymentMethod": "TeleBirr"
}

The total amount of 400 is an example amount. The paymentMethod field is included for this assignment scenario; the current CreateOrderDTO must include that property for the API to accept it.
5. Correct HTTP status codes
Outcome	Status code	Justification
(a) A list of restaurants is returned	200 OK	The request succeeded and returned the restaurant collection.
(b) An order is created	201 Created	A new order resource was successfully created.
(c) An order is cancelled and nothing is returned	204 No Content	The cancellation succeeded and the response has no body.
(d) The qty field arrives as "two"	400 Bad Request	The quantity is invalid because the API expects a number.
(e) The auth token has expired	401 Unauthorized	The client must provide a valid authentication token.
(f) A courier attempts to edit a menu	403 Forbidden	The courier is authenticated but does not have permission to edit the menu.
(g) Someone requests order 99999, which does not exist	404 Not Found	The requested order resource cannot be found.
(h) Your code throws an unhandled exception	500 Internal Server Error	The server encountered an unexpected error.


6. Public API and its contract
API chosen: JSONPlaceholder (https://jsonplaceholder.typicode.com/).

JSONPlaceholder is a free public fake REST API used for testing and learning.
1. It provides resources such as /posts, /comments, /albums, /photos, /todos, and /users.
2. It supports common HTTP methods such as GET, POST, PUT, PATCH, and DELETE on its resources.
3. It provides sample JSON data and documented routes that developers can use for testing and prototyping.
   One thing I would want to know: I would want to know whether the API has a guaranteed uptime or service-level agreement (SLA) before depending on it in a real application. Since it is intended for testing and prototyping, I would not assume it is suitable for a production application without checking its reliability guarantees.
Additional Common HTTP Status Codes
The assignment asks about eight specific outcomes, and the eight answers above are enough to answer that question. The following are extra examples of other status codes that are useful to know.
Status code	Example situation	Meaning
405 Method Not Allowed	A client sends DELETE to an endpoint that only supports GET.	The HTTP method is not supported for that endpoint.
415 Unsupported Media Type	A client sends XML to an endpoint that only accepts JSON.	The request content type is not supported.
422 Unprocessable Content	The JSON is valid, but a value fails a business rule, such as quantity being zero.	The server understands the request format but cannot process its instructions.
429 Too Many Requests	A client sends too many requests in a short period.	The client has exceeded the allowed request rate.
503 Service Unavailable	The API is temporarily unavailable because of maintenance or overload.	The server cannot handle the request temporarily.