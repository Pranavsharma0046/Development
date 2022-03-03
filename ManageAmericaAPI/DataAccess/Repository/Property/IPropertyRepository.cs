using ManageAmericaAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageAmericaAPI.DataAccess.Repository.Property

{
    public interface IPropertyRepository
    {
        Task<IEnumerable> AddProperty(PropertyModel propertyModel);
        PropertyModel GetPropertyById(long id);
        List<PropertyModel> GetProperties();

    }
}
