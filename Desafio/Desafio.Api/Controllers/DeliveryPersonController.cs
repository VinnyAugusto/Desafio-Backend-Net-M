using Desafio.Application.InputModel;
using Desafio.Application.Services.Interfaces;
using Desafio.Core.Exceptions;
using Desafio.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers
{
    [Route("api/DeliveryPerson")]
    public class DeliveryPersonController : ControllerBase
    {
        private readonly IDeliveryPersonService _deliveryPersonService;
        private readonly ILocalDiskStorage _localDiskStorage;

        public DeliveryPersonController(IDeliveryPersonService deliveryPersonService, ILocalDiskStorage localDiskStorage)
        {
            _deliveryPersonService = deliveryPersonService;
            _localDiskStorage = localDiskStorage;
        }

        // api/DeliveryPerson
        [HttpGet]
        public IActionResult Get()
        {
            var deliveryPersons = _deliveryPersonService.GetAll();

            return Ok(deliveryPersons);
        }

        // api/DeliveryPerson/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var deliveryPerson = _deliveryPersonService.GetById(id);
                return Ok(deliveryPerson);
            }
            catch (InvalidDeliveryPersonException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        //api/DeliveryPerson
        [HttpPost]
        public IActionResult Post([FromBody] CreateDeliveryPersonInputModel inputModel)
        {
            try
            {
                var id = _deliveryPersonService.Create(inputModel);

                return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
            }
            catch (InvalidNewDeliveryPersonException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidCnhTypeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (CnpjAlreadyRegisteredException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (CnhAlreadyRegisteredException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        //api/DeliveryPerson
        [HttpPatch]
        public IActionResult Patch([FromBody] UpdateDeliveryPersonInputModel inputModel)
        {
            try
            {
                inputModel.updateImageLocation(_localDiskStorage.GetDefaultPath() + inputModel.FileName);
                _deliveryPersonService.Update(inputModel);

                return NoContent();
            }
            catch (InvalidDeliveryPersonException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidCnhImageException ex)
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
