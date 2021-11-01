using OZ.Interfaces;
using OZ.Models;
using System;
using System.Collections.Generic;

namespace OZ.Services
{
    public class ManagePlaceService : IManagePlaceService
    {
        private IManagePlaceRepository repository;
        public ManagePlaceService(IManagePlaceRepository userRepository)
        {
            repository = userRepository;
        }
        public ManagePlaceDto SaveCreate(ManagePlace domain)
        {
            return repository.SaveCreate(domain);
        }
        public bool Update(ManagePlace domain)
        {
            return repository.Update(domain);
        }
        public bool Delete(Guid id)
        {
            return repository.Delete(id);
        }
        public IEnumerable<ManagePlaceDto> GetAll()
        {
            return repository.GetAll();
        }

        public ManagePlaceDto GetByID(Guid id)
        {
            return repository.GetByID(id);
        }

        public string GetPlaceTypeName(int oid)
        {
            return repository.GetPlaceTypeName(oid);
        }

        public IEnumerable<ManagePlaceDto> GetByType(int typ)
        {
            return repository.GetByType(typ);
        }

        public IEnumerable<ManagePlace> GetPaging(string fieldOrder, int pageNumber, int pageSize,  out int totalPages, out int totalRecords)
        {
            return repository.GetPaging(fieldOrder, pageNumber, pageSize, out totalPages, out totalRecords);
        }
    }
}


