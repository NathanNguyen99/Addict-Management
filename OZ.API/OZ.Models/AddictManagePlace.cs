using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OZ.Models
{
    public class AddictManagePlace
    {
        [Key]
        public Guid OID { get; set; }
        public Guid AddictID { get; set; }
        public int PlaceTypeID { get; set; }
        public Guid ManagePlaceID { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Remarks { get; set; }
    }

    public class AddictManagePlaceDto: AddictManagePlace
    {
        public string AddictCode { get; set; }
        public string AddictName { get; set; }
        public string PlaceTypeName { get; set; }
        public string PlaceName { get; set; }
    }
}
