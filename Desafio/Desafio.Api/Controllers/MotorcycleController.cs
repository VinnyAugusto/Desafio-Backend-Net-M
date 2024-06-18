using Desafio.Application.InputModel;
using Desafio.Application.Services.Interfaces;
using Desafio.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers
{
    [Route("api/Motorcycle")]
    public class MotorcycleController : ControllerBase
    {
        private readonly IMotorcycleService _motorcycleService;
        public MotorcycleController(IMotorcycleService motorcycleService)
        {
            _motorcycleService = motorcycleService;
        }

        // api/Motorcycle?plate=AAA-0000
        [HttpGet]
        public IActionResult Get(string plate)
        {
            var motorcycles = _motorcycleService.GetAll(plate);

            return Ok(motorcycles);
        }

        // api/Motorcycle/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var motorcycle = _motorcycleService.GetById(id);
                return Ok(motorcycle);
            }
            catch (InvalidMotorcycleException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        //api/Motorcycle
        [HttpPost]
        public IActionResult Post([FromBody] CreateMotorcycleInputModel inputModel)
        {
            try
            {
                var id = _motorcycleService.Create(inputModel);

                return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
            }
            catch (InvalidNewMotorcycleException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (PlateAlreadyRegisteredException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        //api/Motorcycle
        [HttpPatch]
        public IActionResult Patch([FromBody] UpdateMotorcycleInputModel inputModel)
        {
            try
            {
                _motorcycleService.Update(inputModel);

                return NoContent();
            }
            catch (InvalidMotorcycleException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (PlateAlreadyRegisteredException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        //api/Motorcycle/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _motorcycleService.Delete(id);

                return NoContent();
            }
            catch (InvalidMotorcycleException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidMotorcycleDeleteException ex)
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
