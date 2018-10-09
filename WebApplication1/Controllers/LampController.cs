using System.Collections.Generic;
using LampApp.Core.ApplicationService;
using LampApp.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class LampController
    {
        [Route("api/[controller]")]
        [ApiController]
        public class LampsController : ControllerBase
        {
            private readonly ILampService _lampService;

            public LampsController(ILampService lampService)
            {
                _lampService = lampService;
            }

            // GET api/customers -- READ All
            [HttpGet]
            public List<Lamp> Get()
            {
                ///Customers with all there orders? NO
                return _lampService.GetAllLamp();
            }

            // GET api/customers/5 -- READ By Id
            [HttpGet("{id}")]
            public ActionResult<Lamp> Get(int id)
            {
                if (id < 1) return BadRequest("Id must be greater then 0");

                //return _customerService.FindCustomerById(id);
                return _lampService.FindLampById(id);
            }

            // POST api/customers -- CREATE JSON
            [HttpPost]
            public ActionResult<Lamp> Post([FromBody] Lamp lamp)
            {
                if (string.IsNullOrEmpty(lamp.Name))
                {
                    return BadRequest("Name is Required for Creating Lamp");
                }

                if (string.IsNullOrEmpty(lamp.Designer))
                {
                    return BadRequest("Designer is Required for Creating Lamp");
                }

                if (string.IsNullOrEmpty(lamp.Color))
                {
                    return BadRequest("Color is Required for Creating Lamp");
                }

                //return StatusCode(503, "Horrible Error CALL Tech Support");
                return _lampService.CreateLamp(lamp);
            }

            // PUT api/customers/5 -- Update
            [HttpPut("{id}")]
            public ActionResult<Lamp> Put(int id, [FromBody] Lamp lamp)
            {
                if (id < 1 || id != lamp.Id)
                {
                    return BadRequest("Parameter Id and lamp ID must be the same");
                }

                return Ok(_lampService.UpdateLamp(lamp));
            }

            // DELETE api/customers/5
            [HttpDelete("{id}")]
            public ActionResult<Lamp> Delete(int id)
            {
                var lamp = _lampService.DeleteLamp(id);
                if (lamp == null)
                {
                    return StatusCode(404, "Did not find Lamp with ID " + id);
                }

                return Ok($"Lamp with Id: {id} is Deleted");
            }
        }
    }
}