using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static TechStore.Application.ICustomService.ICustomService;
using TechStore.Core.Entities;
using TechStore.Domain.Data;
using TechStore.Domain.Models;
using TechStore.Domain.Entities;
using TechStore.Domain.Models.DTO;

namespace TechStore.Presentation.BrandController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly ICustomService<BrandDto> customService;
        private readonly DataContext applicationDbContext;

        public BrandController(ICustomService<BrandDto> _customService, DataContext _applicationDbContext)
        {
            customService = _customService;
            applicationDbContext = _applicationDbContext;
        }

        [HttpPut(nameof(ChangeStateBrand))]
        public IActionResult ChangeStateBrand(int _id)
        {
            BaseResponse<BrandDto> obj = customService.ChangeState(_id);
            if (obj.Status == true) return Ok(obj);
            else return BadRequest(obj);
        }

        [HttpGet(nameof(GetBrandById))]
        public IActionResult GetBrandById(int _id)
        {
            BaseResponse<BrandDto> obj = customService.Get(_id);
            if (obj.Status == true) return Ok(obj);
            else return BadRequest(obj);
        }

        [HttpGet(nameof(GetAllBrands))]
        public IActionResult GetAllBrands()
        {
            BaseResponse<IEnumerable<BrandDto>> obj = customService.GetAll();
            if (obj.Status == true) return Ok(obj);
            else return BadRequest(obj);
        }

        [HttpPost(nameof(CreateBrand))]
        public IActionResult CreateBrand(BrandCreateRequest _brand)
        {
            var brand = new Brand();
            BaseResponse<BrandDto> obj = customService.Insert(_brand);
            if (obj.Status == true) return Ok(obj);
            else return BadRequest(obj);
        }

        [HttpDelete(nameof(DeleteBrand))]
        public IActionResult DeleteBrand(int _id)
        {
            BaseResponse<BrandDto> obj = customService.Remove(_id);
            if (obj.Status == true) return Ok(obj);
            else return BadRequest(obj);
        }

        [HttpPut(nameof(UpdateBrand))]
        public IActionResult UpdateBrand(BrandUpdateRequest _brand)
        {
            BaseResponse<BrandDto> obj = customService.Update(_brand);
            if (obj.Status == true) return Ok(obj);
            else return BadRequest(obj);
        }
    }
}
