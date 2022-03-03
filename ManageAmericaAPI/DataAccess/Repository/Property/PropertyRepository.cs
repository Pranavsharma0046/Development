using ManageAmericaAPI.Data;
using ManageAmericaAPI.Helpers;
using ManageAmericaAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageAmericaAPI.DataAccess.Repository.Property
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public PropertyRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable> AddProperty(PropertyModel propertyModel)
        {
            try
            {

                await _dbcontext.Property.AddAsync(propertyModel);
                await _dbcontext.SaveChangesAsync();
                return ("Successfully added");
            }
            catch (Exception)
            {
                throw new ConflictException("PropertyRepository: Conflict Arises ");

            }
        }
        public PropertyModel GetPropertyById(long Id)
        {
            try
            {
                var response = _dbcontext.Property.FirstOrDefault(x => x.Id == Id);
                return response;
            }
            catch (Exception)
            {
                throw new InvalidException("PropertyRepository: Id Does not Match With database");
            }
        }
        public List<PropertyModel> GetProperties()
        {

            try
            {

                return _dbcontext.Property.ToList();
            }
            catch (Exception)
            {
                throw new UnSucessFullException("PropertyRepository:Not Found");
            }

        }
    }
}
