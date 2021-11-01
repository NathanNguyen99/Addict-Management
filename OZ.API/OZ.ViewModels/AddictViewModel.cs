using System;
using System.Collections.Generic;
using System.Text;

namespace OZ.ViewModels
{
    public class AddictViewModel : IBaseViewModel
    {
        public Guid OID { get; set; }
        public string AddictCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string FullName { get; set; }
        public string FullName { get { return LastName + " " + FirstName; } }
        public DateTime? DateOfBirth { get; set; }
        public string OtherName { get; set; }
        public int GenderID { get; set; }
        public Guid? PlaceOfBirthID { get; set; }
        //public int? YearOfBirth { get; set; }
        //public int? MonthOfBirth { get; set; }
        //public int? DayOfBirth { get; set; }
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
        public Guid? ManagePlaceID { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }
        public bool? Complete { get; set; }
        public int? ManageType { get; set; }
        public DateTime? CompleteDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public Guid? CreateUser { get; set; }
        public string ImgLink { get; set; }
        //public byte[] EImage { get; set; }
        public int updCount { get; set; }
        public double CorrectRatio { get; set; }
        //public List<AddictDrugsViewModel> drugs { get; set; }
        public List<AddictClassifyViewModel> classifys { get; set; }
        public List<AddictManagePlaceViewModel> places { get; set; }
    }

    public class AddictBaseViewModel : IBaseViewModel
    {
        public Guid OID { get; set; }
        public string AddictCode { get; set; }        
        public string FullName { get; set; }
    }
}