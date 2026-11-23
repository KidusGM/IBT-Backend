# Exercise 1 and 2 — Route Constraints and Parameter Binding

## Exercise 1: Integer Route Constraints

**What I changed:**  
Added the `:int` route constraint to the ID route.

Example:

```csharp
[HttpGet("{id:int}/menu")]
```

**Test:**  
Requested `/api/v1/restaurants/abc/menu`

**Result:**  
The API returned `404 Not Found` because `abc` is not an integer and does not match the route.

## Exercise 2: Route Parameter Name Mismatch

**What I changed:**  
Changed the route parameter name from `id` to `restaurantId`, while keeping the action method parameter as `id`.

```csharp
[HttpGet("{restaurantId:int}/menu")]
public IActionResult GetRestaurantMenu(int id)
```

**Test:**  
Requested `/api/v1/restaurants/1/menu`

**Result:**  
The API returned `400 Bad Request` because the route parameter `restaurantId` did not bind to the action parameter `id`.

**Explanation:**  
It is not a compile error because route matching and model binding happen at runtime, not during C# compilation.

**After testing:**  
Restored the route parameter name to `id` so it matches the action method parameter.
