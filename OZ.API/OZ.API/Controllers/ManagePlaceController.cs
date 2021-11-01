using OZ.Interfaces;
using OZ.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OZ.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ManagePlaceController : Controller
    {
        IManagePlaceMap userMap;
        public ManagePlaceController(IManagePlaceMap map)
        {
            userMap = map;
            
        }
        // GET api/Employee
        [HttpGet]
        public IEnumerable<ManagePlaceViewModel> Get()
        {
            return userMap.GetAll();
        }
        // GET api/Employee
        [HttpGet("GetByType")]
        public IEnumerable<ManagePlaceViewModel> Get(int typeid=0)
        {
            if (typeid == 0)
                return userMap.GetAll();
            return userMap.GetByType(typeid);
        }
        [HttpGet("GetPaging")]
        public IActionResult GetPaging(int pageNumber, int pageSize)
        {
            int totalPages = 0;
            int totalRecords = 0;
            var res= userMap.GetPaging("", pageNumber, pageSize, out totalPages, out totalRecords);

            //return res;
            return Ok(new {
                totalPage = totalPages,
                TotalCount = totalRecords,
                items = res
            });
        }
        // GET api/user/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return "value";
        }
        // POST api/user
        [HttpPost]
        public void Post([FromBody]ManagePlaceViewModel user)
        {
            userMap.Update(user);
        }
        // PUT api/user/5
        [HttpPut]
        public void Put([FromBody]ManagePlaceViewModel user)
        {
            userMap.Create(user);
        }
        // DELETE api/user/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
