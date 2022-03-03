using ManageAmericaAPI.DataAccess.Repository.Property;
using ManageAmericaAPI.Models;
using System.Collections;
using System.Threading.Tasks;
using ManageAmericaAPI.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ManageAmericaAPI.Services
{
    public class PropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }
        public async Task<IEnumerable> AddProperty(PropertyModel propertyModel)
        {
            try
            {
                var resp = new PropertyModel()
                {
                    PropertyName = propertyModel.PropertyName,
                    AddressLine1 = propertyModel.AddressLine1,
                    AddressLine2 = propertyModel.AddressLine2,
                    Street = propertyModel.Street,
                    City = propertyModel.City,
                    State = propertyModel.State,
                    ZipCode = propertyModel.ZipCode,
                    CreatedBy = propertyModel.CreatedBy,
                    CreatedDate = propertyModel.CreatedDate
                };
                return await _propertyRepository.AddProperty(propertyModel);
            }
            catch (Exception)
            {
                throw new UnSucessFullException("PropertyService: UnSuccessfull");
            }
        }


        public PropertyModel GetPropertyById(long Id)
        {
            try
            {
                return _propertyRepository.GetPropertyById(Id);
            }
            catch (Exception)
            {
                throw new ConflictException("PropertyService: Conflict Arises In adding Items");
            }
        }
        public List<PropertyModel> GetProperties()
        {
            try
            {
                return _propertyRepository.GetProperties();
            }
            catch (Exception)
            {
                throw new ConflictException("AvailablityService: Conflict Arises In adding Items");
            }

        }
    }
}
