using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OZ.Models
{
    public class Addict //: IdentityUser
    {
        [Key]
        public Guid OID { get; set; }
        public string AddictCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        //public string FullName { get { return LastName + " " + FistName; } }
        public string OtherName { get; set; }
        public int GenderID { get; set; }
        public Guid? PlaceOfBirthID { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? YearOfBirth { get; set; }
        public int? MonthOfBirth { get; set; }
        public int? DayOfBirth { get; set; }
        public string PemanentAddress { get; set; }
        public string CurrentAddress { get; set; }
        public string Profession { get; set; }
        public string PhoneNumber { get; set; }
        public string SocialNetworkAccount { get; set; }
        public Guid? EducationLevelID { get; set; }
        public string CitizenID { get; set; }
        public string CriminalConviction { get; set; }
        public string CriminalRecord { get; set; }
        public bool? Detoxed { get; set; }
        public string FartherName { get; set; }
        public string MotherName { get; set; }
        public string PartnerName { get; set; }
        public string Characteristics { get; set; }

        //public Guid JailID { get; set; }
        //public Guid RehabCampID { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }
        public int? ManageType { get; set; }
        public bool? Complete { get; set; }
        public DateTime? CompleteDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public Guid? CreateUser { get; set; }
        public string ImgLink { get; set; }
        public Guid? ManagePlaceID { get; set; } // de biet thuoc phuong nao quan ly

    }

    public class AddictBaseDto 
    {        
        public Guid OID { get; set; }
        public string AddictCode { get; set; }
        public string FullName { get; set; }
    }

    public class Addict2Dto
    {
        public Guid OID { get; set; }
        public string AddictCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GenderID { get; set; }
        public Guid? PlaceOfBirthID { get; set; }
        public DateTime? DateOfBirth { get; set; }       
        public string PemanentAddress { get; set; }
        public string CurrentAddress { get; set; }
        public string Profession { get; set; }
        public string PhoneNumber { get; set; }
        public string SocialNetworkAccount { get; set; }
        public Guid? EducationLevelID { get; set; }
        public string CitizenID { get; set; }
        public string CriminalConviction { get; set; }
        public string CriminalRecord { get; set; }       
        public string FartherName { get; set; }
        public string MotherName { get; set; }
        public string PartnerName { get; set; }
        public string Characteristics { get; set; }
        public string ImgLink { get; set; }
        public double CorrectRatio { get; set; }
    }
}
