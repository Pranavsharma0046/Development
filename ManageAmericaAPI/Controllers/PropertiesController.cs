using ManageAmericaAPI.Helpers;
using ManageAmericaAPI.Models;
using ManageAmericaAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ManageAmericaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        
        private readonly PropertyService _propertyService;
        public PropertiesController(PropertyService propertyService)
        {
            _propertyService = propertyService;
        }
        
       
        /// <summary>
        /// push api for inserting properties
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("addproperty")]
        public async Task<IActionResult> AddProperty(PropertyModel propertyModel)
        {
            try
            {
               var result = await _propertyService.AddProperty(propertyModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new UnSucessFullException("PropertiesController: UnSuccessfull Attempt");
            }
        }
        /// <summary>
        /// Get API for Property by ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("property/{Id}")]
        public IActionResult GetPropertyById( long Id)
        {
            try
            {
                var val = _propertyService.GetPropertyById(Id);
                if (val == null) throw new InvalidException("PropertiesController: Id Can't be Null");
                return Ok(val);
            }
            catch (Exception )
            {
                throw new InvalidException("PropertiesController: Invalid Id");
            }

        }
        [HttpGet]
        [Route("properties")]
        public IActionResult GetProperties()
        {
            try
            {
                var result = _propertyService.GetProperties();
                return Ok(result);
            }
            catch (Exception)
            {

                throw new HttpResponseException("availablitiesController: Not Found");
            }
        }
       

    }
}
