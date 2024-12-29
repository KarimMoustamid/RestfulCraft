using CarvedRock.Domain;
using CarvedRock.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarvedRock.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductLogic _productLogic;

    public ProductController(ILogger<ProductController> logger, IProductLogic productLogic)
    {
        _logger = logger;
        _productLogic = productLogic;
    }

    [HttpGet]
    public async Task<IEnumerable<ProductModel>> Get(string category = "all")
    {
    // Logs a message using structured logging.
    // Instead of directly formatting the string, the message template "Getting products for category: {category}"
    // uses a placeholder {category} which will be dynamically replaced by the value of the variable `category` at runtime.
    //
    // Example:
    // If category = "Electronics", the log message will appear as:
    // "Getting products for category: Electronics"
    //
    // Structured logging benefits:
    // 1. Efficiency: The log message template and dynamic values are passed separately, avoiding unnecessary string concatenation.
    // 2. Rich Data: In addition to the formatted message, the logging framework also captures key-value metadata
    //    (e.g., {category: "Electronics"}), which can be used for querying or analysis in centralized logging systems.
    // 3. Clarity: Separates the message template from the dynamic values, making it more readable and queryable.
    //
    // Note: This is different from regular string interpolation (e.g., $"...{variable}") and is preferred for structured logging.
        _logger.LogInformation("Getting products for category: {category}", category);
        return await _productLogic.GetProductsForCategory(category);
    }
}