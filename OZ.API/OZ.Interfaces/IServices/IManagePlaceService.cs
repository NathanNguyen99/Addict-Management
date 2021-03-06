using OZ.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZ.Interfaces
{
    public interface IManagePlaceService
    {
        IEnumerable<ManagePlaceDto> GetAll();
        IEnumerable<ManagePlaceDto> GetByType(int typ);
        IEnumerable<ManagePlace> GetPaging(string fieldOrder, int pageNumber, int pageSize, out int totalPages, out int totalRecords);
        ManagePlaceDto GetByID(Guid id);
        string GetPlaceTypeName(int oid);
        ManagePlaceDto SaveCreate(ManagePlace domain);
        bool Update(ManagePlace domain);
        bool Delete(Guid id);
    }
}
