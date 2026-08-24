using APIv1.Data;
using APIv1.DTO;
using APIv1.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIv1.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public CarsController(AppDbContext context)
        {
            _dbContext = context;
        }

        private bool IsValidYear(int year)
        {
            int currentYear = DateTime.Now.Year;
            return year >= currentYear - 5;
        }

        private CarDTO ToDto(Car dto)
        {
            return new CarDTO
            {
                Id = dto.Id,
                Brand = dto.Brand,
                Model = dto.Model,
                Price = dto.Price,
                Year = dto.Year
            };
        }
        private Car ToEntity(CarDTO dto)
        {
            return new Car
            {
                Id = dto.Id,
                Brand = dto.Brand,
                Model = dto.Model,
                Price = dto.Price,
                Year = dto.Year
            };
        }


        [HttpPost]
        public async Task<ActionResult<CarDTO>> CreateMethodName(CarDTO carDto)
        {
            if (!IsValidYear(carDto.Year))
                return BadRequest("El auto no puede tener 5 años de antiguedad");


            var car = ToEntity(carDto);
            _dbContext.Cars.Add(car);
            await _dbContext.SaveChangesAsync();

            carDto.Id = car.Id;
            return CreatedAtAction(nameof(GetCar), new { id = car.Id }, carDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDTO>>> GetCars()
        {
            var cars = await _dbContext.Cars.ToListAsync();
            return cars.Select(ToDto).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarDTO>> GetCar(int id)
        {
            var car = await _dbContext.Cars.FindAsync(id);
            if (car == null)
                return NotFound();

            return ToDto(car);
        }

    }

}