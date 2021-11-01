using OZ.Models;
using OZ.ViewModels;
using System;
using System.Collections.Generic;

namespace OZ.Interfaces
{
    public interface IAddictManagePlaceMap
    {
        List<AddictManagePlaceViewModel> GetAll();
        List<AddictManagePlaceViewModel> GetByAddictID(Guid addictID);
        AddictManagePlaceViewModel GetByID(Guid id);
        bool Delete(Guid id);
        bool Update(AddictManagePlaceViewModel viewModel);
        AddictManagePlaceViewModel Create(AddictManagePlaceViewModel viewModel);
        PagedList<AddictManagePlaceViewModel> GetAddictPlaces(string sortName, string sortDirection, string searchString, int pageNumber, int pageSize);
    }
}
