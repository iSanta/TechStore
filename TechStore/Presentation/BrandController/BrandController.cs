using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static TechStore.Application.ICustomService.ICustomService;
using TechStore.Core.Entities;
using TechStore.Domain.Data;
using TechStore.Domain.Models;

namespace TechStore.Presentation.BrandController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly ICustomService<Brand> customService;
        private readonly DataContext applicationDbContext;

        public BrandController(ICustomService<Brand> _customService, DataContext _applicationDbContext)
        {
            customService = _customService;
            applicationDbContext = _applicationDbContext;
        }

        [HttpGet(nameof(GetAllBrands))]
        public IActionResult GetAllBrands()
        {
            var obj = customService.GetAll();
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }

        [HttpPost(nameof(CreateBrand))]
        public IActionResult CreateBrand(Brand brand)
        {
            if (brand != null)
            {
                customService.Insert(brand);
                return Ok("Created Successfully");
            }
            else
            {
                return BadRequest("Somethingwent wrong");
            }
        }
    }
}
