using OZ.ViewModels;
using System;
using System.Collections.Generic;

namespace OZ.Interfaces
{
    public interface IManagePlaceMap
    {
        List<ManagePlaceViewModel> GetAll();
        ManagePlaceViewModel GetByID(Guid id);
        List<ManagePlaceViewModel> GetByType(int typ);
        List<ManagePlaceViewModel> GetPaging(string fieldOrder, int pageNumber, int pageSize, out int totalPages, out int totalRecords);
        string GetPlaceTypeName(int oid);
        bool Delete(Guid id);
        bool Update(ManagePlaceViewModel viewModel);
        ManagePlaceViewModel Create(ManagePlaceViewModel viewModel);
    }
}
