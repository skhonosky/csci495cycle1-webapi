using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipeApi.Models;
using RecipeApi.Services;

namespace RecipeApi.Controllers
{
    [ApiController]
    [Route("recipes")]
    public class RecipeController : ControllerBase
    {
       

        private readonly ILogger<RecipeController> _logger;
        private IRecipeServices _service;

        public RecipeController(ILogger<RecipeController> logger, IRecipeServices service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IActionResult GetRecipes()
        {
            IEnumerable<Recipe> list = _service.GetRecipes();
            if (list != null)
                return Ok(list);
            else
                return BadRequest();
        }

    }
}