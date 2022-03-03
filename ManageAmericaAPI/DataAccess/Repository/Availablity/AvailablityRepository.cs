using ManageAmericaAPI.Data;
using ManageAmericaAPI.Helpers;
using ManageAmericaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ManageAmericaAPI.DataAccess.Repository.Availablity

{
    public class AvailablityRepository : IAvailablityRepository
    {
        private readonly ApplicationDbContext _context;
        public AvailablityRepository(ApplicationDbContext context)
        {
            _context = context;

        }


        public async Task<IEnumerable<GetAvailablityModel>> GetAvailablities()
        {
            try
            {
                List<GetAvailablityModel> result = new List<GetAvailablityModel>();
                var data = _context.Availablity.Where(p => p.IsDeleted == false).ToList();

                foreach (var item in data)
                {

                    result.Add(new GetAvailablityModel
                    {

                        Date = item.Date,
                        PropertyId = item.PropertyId,
                        ManagerId = item.ManagerId,
                        availablityModels = new List<AvailablityModel>
                        {
                             new AvailablityModel
                             {
                                 Id = item.Id,
                                 FromDate =item.FromDate,
                                 ToDate = item.ToDate,
                                 FromTime = item.FromTime,
                                 ToTime = item.ToTime,
                                 IsDeleted = item.IsDeleted,
                                 IsReccurence = item.IsReccurence,
                                 Reccurences = _context.Reccurence.Where(x => x.AvailablityId == item.Id)
                                 .Select(x => new Reccurence
                                 {
                                     Id=x.Id,
                                     AvailablityId=x.AvailablityId,
                                     ToTime=x.ToTime,
                                     FromTime=x.FromTime,
                                     Date=x.Date

                                 }).ToList()

                             }
                        }
                    });
                }
                return result;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<IEnumerable> GetAllAvailablities()
        {
            try
            {
                var result = _context.Availablity.Where(x => x.IsDeleted == false).ToList();
                return result;
            }
            catch (Exception)
            {

                throw new ConflictException("AvailablityRepository: Conflict Arises ");
            }
        }

        public AvailablityModel GetAvailablityById(long Id) => _context.Availablity.Where(x => x.IsDeleted == false).FirstOrDefault(x => x.Id == Id);

        public async Task<IEnumerable> GetAvailablityByManagerId(long ManagerId)
        {
            var response = (from xd in _context.Availablity
                            where xd.ManagerId == ManagerId && xd.IsDeleted == false
                            orderby xd.ManagerId
                            select new
                            {
                                xd.Id,
                                xd.ManagerId,
                                xd.ToDate,
                                xd.FromDate,
                                xd.Date,
                                xd.ToTime,
                                xd.FromTime
                            }).ToList();
            return response;
        }

        public AvailablityModel UpdateById(long Id, AvailablityUpdateModel _availablity)
        {
            try
            {
                var result = _context.Availablity.Where(e => e.IsDeleted == false).FirstOrDefault(x => x.Id == Id);
                if (result != null)
                {
                    if (result.IsReccurence == true)
                    {
                        result.Date = _availablity.Date;
                        result.ToTime = _availablity.ToTime;
                        result.FromTime = _availablity.FromTime;
                        result.ModifiedDate = _availablity.ModifiedDate;
                        result.ModifiedBy = _availablity.ManagerId;
                        result.IsReccurence = _availablity.IsReccurence;
                        if (_availablity.IsReccurence == true)
                        {
                            var response = _context.Reccurence.Where(c => c.AvailablityId == Id).FirstOrDefault();
                            response.Date = _availablity.Date;
                            response.ToTime = _availablity.ToTime;
                            response.FromTime = _availablity.FromTime;
                            response.ModifiedDate = _availablity.ModifiedDate;
                            response.ModifiedBy = _availablity.ManagerId;
                            _context.Update(response);
                        }
                        else
                        {
                            result.IsReccurence = false;
                            var response = _context.Reccurence.Where(c => c.AvailablityId == Id).FirstOrDefault();
                            response.IsDeleted = true;
                            response.DeletedDate = result.ModifiedDate;
                            response.DeletedBy = result.ModifiedBy;
                            _context.Update(response);
                        }

                    }
                    else
                    {
                        if (_availablity.IsReccurence == true)
                        {
                            result.Date = _availablity.Date;
                            result.ToTime = _availablity.ToTime;
                            result.FromTime = _availablity.FromTime;
                            result.ModifiedDate = _availablity.ModifiedDate;
                            result.ModifiedBy = _availablity.ManagerId;
                            result.IsReccurence = _availablity.IsReccurence;
                            result.FromDate = _availablity.FromDate;
                            result.ToDate = _availablity.ToDate;

                            Reccurence reccurence = new Reccurence();
                            reccurence.Date = _availablity.Date;
                            reccurence.FromTime = _availablity.FromTime;
                            reccurence.ToTime = _availablity.ToTime;
                            reccurence.CreatedBy = result.ManagerId;
                            reccurence.CreatedDate = (DateTime)result.ModifiedDate;
                            result.Reccurences.Add(reccurence);

                        }
                        else
                        {
                            result.Date = _availablity.Date;
                            result.ToTime = _availablity.ToTime;
                            result.FromTime = _availablity.FromTime;
                            result.ModifiedDate = _availablity.ModifiedDate;
                            result.ModifiedBy = _availablity.ManagerId;
                            result.IsReccurence = _availablity.IsReccurence;
                        }
                    }

                }
                _context.SaveChanges();
                return (result);
            }
            catch (Exception)
            {
                throw new ConflictException("AvailablityRepository: Please Enter Correct Data");
            }

        }
        public AvailablityModel DeleteAvailablityById(long AvailablityId, long ReccurenceId, AvailablityDeleteModel availablityDeleteModel)
        {
            try
            {
                var result = _context.Availablity.Where(e => e.Id == AvailablityId).FirstOrDefault();
                if (result != null)
                {
                    if (result.IsReccurence == true)
                    {
                        if (result.IsDeleted == false)
                        {
                            result.IsDeleted = true;
                            result.DeletedBy = availablityDeleteModel.ManagerId;
                            result.DeletedDate = availablityDeleteModel.DeletedDate;
                            var response = _context.Reccurence.Where(c => c.AvailablityId == AvailablityId && c.Id == ReccurenceId).FirstOrDefault();
                            response.IsDeleted = result.IsDeleted;
                            response.DeletedBy = result.DeletedBy;
                            response.DeletedDate = result.DeletedDate;
                            _context.Update(response);
                            _context.SaveChanges();
                            return (result);
                        }
                    }
                    else
                    {
                        if (result.IsDeleted == false)
                        {
                            result.IsDeleted = true;
                            result.DeletedBy = availablityDeleteModel.ManagerId;
                            result.DeletedDate = availablityDeleteModel.DeletedDate;
                            _context.SaveChanges();
                            return (result);
                        }

                    }
                }
                throw new InvalidException("AvailablityRepository: InValid Id : Please Enter Correct Id");
            }
            catch (Exception)
            {
                throw new InvalidException("AvailablityRepository: InValid Id : Please Enter Correct Id ");
            }
        }
        public async Task<IEnumerable> GetPropertyByManagerId(long ManagerId)
        {
            var response = (from xd in _context.Availablity
                            where xd.ManagerId == ManagerId && xd.IsDeleted == false
                            join pd in _context.Property on xd.PropertyId equals pd.Id
                            orderby xd.PropertyId
                            select new
                            {
                                xd.ManagerId,
                                xd.PropertyId,
                                pd.PropertyName
                            }).Distinct().ToList();
            return response;

        }
        public async Task<IEnumerable<GetAvailablityModel>> AvailablityByIds(long ManagerId, long PropertyId)
        {
            try
            {
                List<GetAvailablityModel> result = new List<GetAvailablityModel>();
                var data = _context.Availablity.Where(p => p.ManagerId == ManagerId && p.PropertyId == PropertyId && p.IsDeleted == false).ToList();

                var datelist = data.Select(p => p.Date).Distinct().ToList();
                foreach (var item in datelist)
                {
                    GetAvailablityModel response = new GetAvailablityModel();
                    response.Date = item.Date;
                    response.ManagerId = ManagerId;
                    response.PropertyId = PropertyId;
                    AvailablityModel availablity = null;
                    foreach (var i in data.Where(p => p.Date == item.Date))
                    {
                        availablity = new AvailablityModel();
                        availablity.Id = i.Id;
                        availablity.Date = i.Date;
                        availablity.FromDate = i.FromDate;
                        availablity.ToDate = i.ToDate;
                        availablity.FromTime = i.FromTime;
                        availablity.ToTime = i.ToTime;
                        availablity.IsDeleted = i.IsDeleted;
                        availablity.IsReccurence = i.IsReccurence;
                        availablity.Reccurences = _context.Reccurence.Where(x => x.AvailablityId == i.Id)
                             .Select(x => new Reccurence
                             {
                                 Id = x.Id,
                                 AvailablityId = x.AvailablityId,
                                 ToTime = x.ToTime,
                                 FromTime = x.FromTime,
                                 Date = x.Date

                             }).ToList();


                        response.availablityModels.Add(availablity);


                    }

                    result.Add(response);

                }
                return result;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<IEnumerable<GetAvailablityModel>> AvailablityByManagerId(long ManagerId)
        {
            try
            {
                List<GetAvailablityModel> result = new List<GetAvailablityModel>();
                var data = _context.Availablity.Where(p => p.ManagerId == ManagerId && p.IsDeleted == false).ToList();

                var datelist = data.Select(p => p.Date).Distinct().ToList();
                foreach (var item in datelist)
                {
                    GetAvailablityModel response = new GetAvailablityModel();
                    response.Date = item.Date;
                    response.ManagerId = ManagerId;


                    AvailablityModel availablity = null;
                    foreach (var i in data.Where(p => p.Date == item.Date))
                    {
                        availablity = new AvailablityModel();
                        availablity.Id = i.Id;
                        availablity.Date = i.Date;
                        availablity.FromDate = i.FromDate;
                        availablity.ToDate = i.ToDate;
                        availablity.FromTime = i.FromTime;
                        availablity.ToTime = i.ToTime;
                        availablity.IsDeleted = i.IsDeleted;
                        availablity.IsReccurence = i.IsReccurence;
                        availablity.Reccurences = _context.Reccurence.Where(x => x.AvailablityId == i.Id)
                             .Select(x => new Reccurence
                             {
                                 Id = x.Id,
                                 AvailablityId = x.AvailablityId,
                                 ToTime = x.ToTime,
                                 FromTime = x.FromTime,
                                 Date = x.Date

                             }).ToList();


                        response.availablityModels.Add(availablity);


                    }

                    result.Add(response);

                }

                return result;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<IEnumerable> GetAvailablity(long PropertyId, long ManagerId)
        {
            try
            {
                var result = (from u in _context.Availablity
                              where !_context.TourDetail.Any(e => (e.StartTime == u.FromTime
                              && e.EndTime == u.ToTime))
                              where u.PropertyId == PropertyId && u.ManagerId == ManagerId
                              select new
                              {
                                  Id = u.Id,
                                  Date = u.Date,
                                  ManagerId = u.ManagerId,
                                  PropertyId = u.PropertyId,
                                  FromTime = u.FromTime,
                                  ToTime = u.ToTime
                              }).Distinct().ToList();

                return result;



            }
            catch (Exception)
            {

                throw new ConflictException("AvailablityRepository: Conflict Arises ");
            }
        }




    }

}
