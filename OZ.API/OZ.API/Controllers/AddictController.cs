using OZ.Interfaces;
using OZ.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Drawing;

namespace OZ.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class AddictController : Controller
    {
        IAddictMap userMap;
        public AddictController(IAddictMap map)
        {
            userMap = map;
        }
        // GET api/Addict
        [HttpGet]
        public IEnumerable<AddictViewModel> Get()
        {
            //JsonSerializer.Deserialize<IEnumerable<EmployeeViewModel>>(userMap.GetAll());         
            return userMap.GetAll(); ;
        }

        [HttpGet("GetByPlaceID")]
        public IEnumerable<AddictViewModel> GetByPlaceID(Guid placeID)
        {
            //JsonSerializer.Deserialize<IEnumerable<EmployeeViewModel>>(userMap.GetAll());         
            return userMap.GetByPlaceID(placeID); ;
        }

        [HttpGet("SearchAddict")]
        //..api/SearchAddict?same=2&&genderID=-1&&fromAge=0&&toAge=3&&SocialNetwork=""&&CitizenID=""&&WarID=null
        //[HttpGet("{sname}/{genderID}/{fromAge}/{toAge}/{SocialNetwork}/{CitizenID}/{WardID}")]
        public IEnumerable<AddictViewModel> Get(string sname, int genderID, int fromAge, int toAge, string SocialNetwork, string CitizenID, Guid? WardID)
        {                    
            return userMap.Search(sname, genderID, fromAge, toAge, SocialNetwork, CitizenID, WardID); ;
        }
        // GET api/Addict/5
        [HttpGet("{id}")]
        public AddictViewModel Get(Guid id)
        {
            return userMap.GetByID(id);
        }
        [HttpGet("GetBaseFields")]
        public IEnumerable<AddictBaseViewModel> GetBaseFields()
        {
            return userMap.GetBaseFields();
        }
        [HttpGet("CheckExists")]
        public ActionResult<bool> CheckExists(string CitizendID)
        {
            return userMap.CheckExists(CitizendID);// true is exists
        }
        // POST api/Addict
        [HttpPost]
        public AddictViewModel Post([FromBody]AddictViewModel user)
        {
            return userMap.Create(user);
        }
        // PUT api/Addict/5
        [HttpPut]
        public bool Put([FromBody]AddictViewModel user)
        {
            return userMap.Update(user);
            //return false;
        }
        //public IEnumerable<object> Post([FromBody] JObject data)
        //{
           
        //}
        // DELETE api/user/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            userMap.Delete(id);
        }
        [HttpPost("CheckFace")]
        public IEnumerable<AddictViewModel> CheckFace()
        {            
            IFormFileCollection files = Request.Form.Files;
            int gender = 0;
            //IEnumerable<AddictViewModel> result = null; ;
            if (files.Count > 0)
            {
                var file1 = files[0];
                var FaceImage = Image.FromStream(file1.OpenReadStream());
                if (file1.FileName == "nu.jpg")
                    gender = 1;
                //result = userMap.SearchByFace(FaceImage);
            }
            
            
            return userMap.GetLimit(gender);
        }
    }
}
