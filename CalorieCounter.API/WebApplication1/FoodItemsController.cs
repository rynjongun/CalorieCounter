using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class FoodItemsController : ControllerBase
{
    private readonly AppDbContext _context;

    public FoodItemsController(AppDbContext context)
    {
        _context = context;
    }

    // Define methods for CRUD operations here
}
