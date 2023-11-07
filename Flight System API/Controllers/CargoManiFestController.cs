using Flight_System_API.Repository.CargoManiFestRepository;
using FlightSystemAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flight_System_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/cargomaniFest")]
    public class CargoManiFestController : Controller
    {
        private readonly ICargoManiFestRepository _cargoManiFestRepository;
        public CargoManiFestController(ICargoManiFestRepository cargoManiFestRepository)
        {
            _cargoManiFestRepository = cargoManiFestRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<CargoManiFest> cargoManiFests = _cargoManiFestRepository.GetAll();
            return Ok(cargoManiFests);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            CargoManiFest cargoManiFest = _cargoManiFestRepository.GetById(id);
            if (cargoManiFest != null)
            {
                return Ok(cargoManiFest);
            }
            return NotFound($"Không tìm thấy ID {id}");
        }
        [HttpPost]
        public IActionResult Create([FromBody] CargoManiFest cargoManiFest)
        {
            bool created = _cargoManiFestRepository.CreateCargoManiFest(cargoManiFest);
            if (created)
            {
                return Ok(new { Message = "Tạo thành công", CargoManiFest = cargoManiFest });
            }
            return BadRequest("Tạo thất bại");
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CargoManiFest cargoManiFest)
        {
            bool updated = _cargoManiFestRepository.UpdateCargoManiFest(cargoManiFest);
            if (updated)
            {
                return Ok(new { Message = $"Cập nhật ID {id} thành công", CargoManiFest = cargoManiFest });
            }
            return BadRequest($"Cập nhật ID {id} thất bại");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            bool deleted = _cargoManiFestRepository.DeleteCargoManiFest(id);
            if (deleted)
            {
                return Ok($"xóa thành công ID {id} ");
            }
            return BadRequest($"Xóa ID {id} thất bại");
        }
    }
}
