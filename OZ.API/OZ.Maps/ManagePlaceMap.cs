using OZ.Interfaces;
using OZ.Models;
using OZ.ViewModels;
using System;
using System.Collections.Generic;

namespace OZ.Maps
{
    public class ManagePlaceMap : IManagePlaceMap
    {
        IManagePlaceService empService;
        public ManagePlaceMap(IManagePlaceService service)
        {
            empService = service;
        }
        public ManagePlaceViewModel Create(ManagePlaceViewModel viewModel)
        {
            ManagePlace user = ViewModelToDomain(viewModel);
            return DomainToViewModel(empService.SaveCreate(user));
        }
        public bool Update(ManagePlaceViewModel viewModel)
        {
            ManagePlace user = ViewModelToDomain(viewModel);
            return empService.Update(user);
        }
        public bool Delete(Guid id)
        {
            return empService.Delete(id);
        }
        public List<ManagePlaceViewModel> GetAll()
        {
            return DomainToViewModel(empService.GetAll());
        }
        
        public ManagePlaceViewModel DomainToViewModel(ManagePlaceDto domain)
        {
            var lst = empService.GetAll();
            ManagePlaceViewModel model = new ManagePlaceViewModel();
            model.Address = domain.Address;
            model.PlaceName = domain.PlaceName;
            model.PlaceTypeID = domain.PlaceTypeID;
            model.OID = domain.OID;
            model.PlaceTypeName = domain.PlaceTypeName;
            //model.PlaceTypeName = empService.GetPlaceTypeName(model.PlaceTypeID);
            return model;
        }
        //public List<ManagePlaceViewModel> DomainToViewModel(IEnumerable<ManagePlaceDto> domain)
        //{
        //    var lst = empService.GetAll();
        //    List<ManagePlaceViewModel> model = new List<ManagePlaceViewModel>();
        //    foreach (ManagePlace of in domain)
        //    {
        //        model.Add(DomainToViewModel(of));
        //    }
        //    return model;
        //}
        public List<ManagePlaceViewModel> DomainToViewModel(IEnumerable<ManagePlaceDto> domain)
        {
            var lst = empService.GetAll();
            List<ManagePlaceViewModel> model = new List<ManagePlaceViewModel> ();
            foreach (ManagePlaceDto of in domain)
            {
                model.Add(DomainToViewModel(of));
            }
            return model;
        }
        public ManagePlace ViewModelToDomain(ManagePlaceViewModel officeViewModel)
        {
            ManagePlace domain = new ManagePlace();
            domain.Address = officeViewModel.Address;
            domain.PlaceName = officeViewModel.PlaceName;
            domain.PlaceTypeID = officeViewModel.PlaceTypeID;
            domain.OID = officeViewModel.OID;
            return domain;
        }
        public ManagePlaceViewModel GetByID(Guid id)
        {
            var objdomain = empService.GetByID(id);
            var model = DomainToViewModel(objdomain);
            return model;
        }

        public string GetPlaceTypeName(int oid)
        {
            return empService.GetPlaceTypeName(oid);
        }

        public List<ManagePlaceViewModel> GetByType(int typ)
        {
            return DomainToViewModel(empService.GetByType(typ));
        }

        public List<ManagePlaceViewModel> GetPaging(string fieldOrder, int pageNumber, int pageSize, out int totalPages, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        //public List<ManagePlaceViewModel> GetPaging(string fieldOrder, int pageNumber, int pageSize, out int totalPages, out int totalRecords)
        //{
        //    //totalPages = 0;
        //    //totalRecords = 0;
        //    return DomainToViewModel(empService.GetPaging(fieldOrder, pageNumber, pageSize, out totalPages, out totalRecords));
        //}
    }
}
