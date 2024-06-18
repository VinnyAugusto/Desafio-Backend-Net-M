using Desafio.Application.InputModel;
using Desafio.Application.Services.Interfaces;
using Desafio.Core.Exceptions;
using Desafio.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers
{
    [Route("api/Rent")]
    public class RentController : ControllerBase
    {
        private readonly IRentService _rentService;

        public RentController(IRentService rentService)
        {
            _rentService = rentService;
        }

        // api/rent
        [HttpGet]
        public IActionResult Get()
        {
            var rentals = _rentService.GetAll();

            return Ok(rentals);
        }

        // api/rent/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var rent = _rentService.GetById(id);
                return Ok(rent);
            }
            catch (InvalidRentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        /// <summary>
        /// Rent Plans:
        /// 1: 7 dias 
        /// 2: 15 dias
        /// 3: 30 dias
        /// 4: 45 dias
        /// 5: 50 dias
        /// </summary>
        [HttpPost]
        public IActionResult Post([FromBody] CreateRentInputModel inputModel)
        {
            try
            {
                var id = _rentService.Create(inputModel);

                return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
            }
            catch (InvalidNewRentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidDeliveryPersonException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidCnhTypeToRentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // api/rent/GetTotalCost?id=1&expectedEndDate=2024-01-15
        [HttpGet("GetTotalCost")]
        public IActionResult GetTotalCost(int id, DateTime expectedEndDate)
        {
            try
            {
                var rent = _rentService.GetTotalCost(new GetRentTotalCostInputModel() { Id = id, ExpectedEndDate = expectedEndDate});
                return Ok(rent);
            }
            catch (InvalidRentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidExpectedEndDateException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

    }
}
