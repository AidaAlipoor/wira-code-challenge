using Microsoft.AspNetCore.Mvc;
using WiraCodeChallenge.Application.Interfaces;

namespace WiraCodeChallenge.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CityInfoController(ICityInfo cityInfo) : ControllerBase
{
    [HttpGet("{cityName}")]
    public async Task<IActionResult> Get([FromRoute] string cityName)
    {
        if (string.IsNullOrWhiteSpace(cityName))
        {
            return BadRequest(new
            { message = "City name is required" });
        }

        var data = await cityInfo.GetAsync(cityName);

        if (data == null)
        {
            return NotFound(new
            { message = $"Data not found for city: {cityName}" });
        }

        return Ok(data);
    }
}
