using Microsoft.EntityFrameworkCore;
using OZ.Interfaces;
using OZ.Models;
using OZ.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OZ.Repositories
{
    public class ManagePlaceRepository : RepositoryBase<ManagePlace>, IManagePlaceRepository
    {
        public ManagePlaceRepository(ApplicationContext context) : base(context)
        { }

        public ManagePlaceDto SaveCreate(ManagePlace domain)
        {
            try
            {
                var us = Create(domain);
                var oPlace = new ManagePlaceDto() { OID = us.OID, PlaceName = us.PlaceName, Address = us.Address, PlaceTypeID = us.PlaceTypeID };

                oPlace.PlaceTypeName = GetPlaceTypeName(oPlace.PlaceTypeID);

                    return oPlace;
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }
        
        //public new Employee Create(Employee domain)
        //{
        //    Employee user = RepositoryContext.EmployeesDB.Where(x => x.Oid.Equals(id)).FirstOrDefault();
        //}
        public new bool Update(ManagePlace domain)
        {
            try
            {
                //domain.Updated = DateTime.Now;
                base.Update(domain);
                return true;
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return false;
            }
        }
        public bool Delete(Guid id)
        {
            try
            {
                ManagePlace user = RepositoryContext.ManagePlaces.Where(x => x.OID.Equals(id)).FirstOrDefault();
                if (user != null)
                {
                    Delete(user);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return false;
            }
        }
        public IEnumerable<ManagePlaceDto> GetAll()
        {
            try
            {   
                var lst = (from c in RepositoryContext.ManagePlaces
                           join p in RepositoryContext.PlaceTypes on c.PlaceTypeID equals p.OID into ps
                           from p1 in ps.DefaultIfEmpty()
                           select new ManagePlaceDto() { OID = c.OID,
                               PlaceName = c.PlaceName,
                               Address = c.Address,
                               PlaceTypeID = c.PlaceTypeID,
                               PlaceTypeName = p1.PlaceTypeName });
                return lst;
                //return RepositoryContext.ManagePlaces.OrderBy(x => x.PlaceTypeID);
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }

        public ManagePlaceDto GetByID(Guid id)
        {            
            ManagePlace user = RepositoryContext.ManagePlaces.Where(x => x.OID.Equals(id)).FirstOrDefault();
            var oPlace = new ManagePlaceDto() { OID = user.OID, PlaceName = user.PlaceName, Address = user.Address, PlaceTypeID = user.PlaceTypeID };
            if (user != null)
            {
                 oPlace.PlaceTypeName = GetPlaceTypeName(oPlace.PlaceTypeID);
                return oPlace;
            }
            else
            {
                return null;
            }
        }

        public string GetPlaceTypeName(int oid)
        {
            string strvalue = string.Empty;
            var obj = RepositoryContext.PlaceTypes.FirstOrDefault(r => r.OID == oid);
            if (obj != null)
                strvalue = obj.PlaceTypeName;
            return strvalue;
        }

        public IEnumerable<ManagePlaceDto> GetByType(int typ)
        {
            try
            {
                //return RepositoryContext.ManagePlaces.Where(r => r.PlaceTypeID == typ);

                var lst = (from c in RepositoryContext.ManagePlaces
                           join p in RepositoryContext.PlaceTypes on c.PlaceTypeID equals p.OID into ps
                           from p1 in ps.DefaultIfEmpty()
                           where c.PlaceTypeID == typ
                           select new ManagePlaceDto()
                           {
                               OID = c.OID,
                               PlaceName = c.PlaceName,
                               Address = c.Address,
                               PlaceTypeID = c.PlaceTypeID,
                               PlaceTypeName = p1.PlaceTypeName
                           });
                return lst;
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }

        public async Task<IEnumerable<ManagePlace>> GetPagingAsync(string fieldOrder, int pageNumber, int pageSize)
        {
            try
            {
                //// var pagedData = await context.Customers
                ////.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                ////.Take(validFilter.PageSize)
                ////.ToListAsync();
                //totalRecords = RepositoryContext.ManagePlaces.Count();
                //totalPages=  (int)Math.Ceiling(totalRecords / (double)pageSize);
                return await RepositoryContext.ManagePlaces.AsNoTracking().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }

        public  IEnumerable<ManagePlace> GetPaging(string fieldOrder, int pageNumber, int pageSize, out int totalPages, out int totalRecords)
        {
            try
            {
                totalRecords = RepositoryContext.ManagePlaces.Count();
                totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

                return RepositoryContext.ManagePlaces.AsNoTracking().Skip((pageNumber - 1) * pageSize).Take(pageSize);
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                totalRecords = 0;
                totalPages = 0;
                return null;
            }
        }




        //IEnumerable<ManagePlace> IManagePlaceRepository.GetPagingAsync(string fieldOrder, int pageNumber, int pageSize)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
