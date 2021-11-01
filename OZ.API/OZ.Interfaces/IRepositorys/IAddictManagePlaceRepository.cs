using OZ.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZ.Interfaces
{
    public interface IAddictManagePlaceRepository
    {
        IEnumerable<AddictManagePlaceDto> GetAll();
        IEnumerable<AddictManagePlaceDto> GetByAddictID(Guid addictID);
        AddictManagePlaceDto GetByID(Guid id);
        AddictManagePlaceDto SaveCreate(AddictManagePlace domain);
        bool Update(AddictManagePlace domain);
        bool Delete(Guid id);
        public PagedList<AddictManagePlaceDto> GetAddictPlaces(string sortName, string sortDirection, string searchString, int pageNumber, int pageSize);
    }
}
