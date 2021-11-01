using OZ.Interfaces;
using OZ.Models;
using OZ.Models.Context;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace OZ.Repositories
{
    public class AddictRepository : RepositoryBase<Addict>, IAddictRepository
    {
        public AddictRepository(ApplicationContext context) : base(context)
        { }

        public Addict Save(Addict domain)
        {
            try
            {
                var us = Create(domain);
                return us;
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }

        public new bool Update(Addict domain)
        {
            try
            {
                //domain.Updated = DateTime.Now;
                base.Update(domain);
                return true;
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return false;
            }
        }
        public bool Delete(Guid id)
        {
            try
            {
                Addict user = RepositoryContext.Addicts.Where(x => x.OID.Equals(id)).FirstOrDefault();
                if (user != null)
                {
                    base.Delete(user);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return false;
            }
        }
        public IEnumerable<Addict> GetAll()
        {
            try
            {
                return FindAll();//.Where(c => c.Active == true);//.Take(100);//.OrderBy(x => x.TenGoi);
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="top">0: nam; 1: nu</param>
        /// <returns></returns>
        public IEnumerable<Addict> GetLimit(int top)
        {
            try
            {
                if (top == 0)
                {
                    string[] lstCodeMale = { "2410","2411","2412", "2413", "2414" };
                    var lst1 = (from a in FindAll() where a.GenderID == 0 && lstCodeMale.Contains(a.AddictCode) select a);
                    return lst1;
                }                        
                else
                {
                    string[] lstCodeFeMale = { "0971", "0972", "0975", "0977", "0979" };
                    var lst = (from a in FindAll() where a.GenderID == 1 && lstCodeFeMale.Contains(a.AddictCode) select a);
                    return lst;
                }    
                   
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }

        public IEnumerable<AddictBaseDto> GetBaseFields()
        {
            try
            {
                var result = (from a in RepositoryContext.Addicts
                              where a.Complete == false || a.Complete == null
                              select new AddictBaseDto
                              {
                                  OID = a.OID,
                                  AddictCode = a.AddictCode,
                                  FullName = a.LastName + " " + a.FirstName
                              });

                return result;
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }

        public IEnumerable<Addict2Dto> SearchByFace(Image faceimg)
        {
            try
            {
                var lstAddict = new List<Addict2Dto>();
                //var fr = new Commons.TFaceRecord();                
                //fr.FacePosition = new Luxand.FSDK.TFacePosition();
                //fr.FacialFeatures = new Luxand.FSDK.TPoint[Luxand.FSDK.FSDK_FACIAL_FEATURE_COUNT];
                //fr.Template = new byte[Luxand.FSDK.TemplateSize];

                //fr.image = new Luxand.FSDK.CImage(faceimg);

                //fr.FacePosition = fr.image.DetectFace();
                //if (0 == fr.FacePosition.w)
                //{
                //    //no face found
                //    return lstAddict;
                //}
                //else
                //{
                //    fr.faceImage = fr.image.CopyRect((int)(fr.FacePosition.xc - Math.Round(fr.FacePosition.w * 0.5)), (int)(fr.FacePosition.yc - Math.Round(fr.FacePosition.w * 0.5)), (int)(fr.FacePosition.xc + Math.Round(fr.FacePosition.w * 0.5)), (int)(fr.FacePosition.yc + Math.Round(fr.FacePosition.w * 0.5)));
                //    fr.FacialFeatures = fr.image.DetectEyesInRegion(ref fr.FacePosition);
                //    fr.Template = fr.image.GetFaceTemplateInRegion(ref fr.FacePosition);

                //    // so sanh voi source
                //    foreach (var item in RepositoryContext.FaceLists)
                //    {
                //        var faceImgSource = CreateFaceImg(item);
                //        var ratio = Commons.FaceClass.Compare(fr, faceImgSource);
                //        if (ratio > 80)
                //        {
                //            var objAddict = (from a in RepositoryContext.Addicts
                //                             where a.OID == item.AddictID
                //                             select new Addict2Dto
                //                             {
                //                                 OID = a.OID,
                //                                 AddictCode = a.AddictCode,
                //                                 FirstName = a.FirstName,
                //                                 LastName = a.LastName,
                //                                 GenderID = a.GenderID,
                //                                 PlaceOfBirthID = a.PlaceOfBirthID,
                //                                 DateOfBirth = a.DateOfBirth,
                //                                 PemanentAddress = a.PemanentAddress,
                //                                 CurrentAddress = a.CurrentAddress,
                //                                 Profession = a.Profession,
                //                                 PhoneNumber = a.PhoneNumber,
                //                                 SocialNetworkAccount = a.SocialNetworkAccount,
                //                                 EducationLevelID = a.EducationLevelID,
                //                                 CitizenID = a.CitizenID,
                //                                 CriminalConviction = a.CriminalConviction,
                //                                 CriminalRecord = a.CriminalRecord,
                //                                 FartherName = a.FartherName,
                //                                 MotherName = a.MotherName,
                //                                 PartnerName = a.PartnerName,
                //                                 Characteristics = a.Characteristics,
                //                                 ImgLink = a.ImgLink,
                //                                 CorrectRatio = ratio
                //                             }).FirstOrDefault();
                //            lstAddict.Add(objAddict);
                //        }                        
                //    }
                //    return lstAddict;
                //}
                return lstAddict;
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }

        private Commons.TFaceRecord CreateFaceImg(FaceList obj)
        {
            var fr = new Commons.TFaceRecord();

            //fr.FacePosition = new Luxand.FSDK.TFacePosition();
            //fr.FacePosition.xc = obj.FacePositionXc;
            //fr.FacePosition.yc = obj.FacePositionYc;
            //fr.FacePosition.w = obj.FacePositionW;
            //fr.FacePosition.angle = obj.FacePositionAngle;

            //fr.FacialFeatures = new Luxand.FSDK.TPoint[2];
            //fr.FacialFeatures[0] = new Luxand.FSDK.TPoint();
            //fr.FacialFeatures[0].x = obj.Eye1X;
            //fr.FacialFeatures[0].y = obj.Eye1Y;
            //fr.FacialFeatures[1] = new Luxand.FSDK.TPoint();
            //fr.FacialFeatures[1].x = obj.Eye2X;
            //fr.FacialFeatures[1].y = obj.Eye2Y;

            //fr.Template = obj.Template;

            //Image img = Image.FromStream(new System.IO.MemoryStream(obj.Image));
            //Image img_face = Image.FromStream(new System.IO.MemoryStream(obj.FaceImage));
            //fr.image = new Luxand.FSDK.CImage(img);
            //fr.faceImage = new Luxand.FSDK.CImage(img_face);

            return fr;
        }
        public Addict GetByID(Guid id)
        {
            Addict user = RepositoryContext.Addicts.Where(x => x.OID.Equals(id)).FirstOrDefault();
            if (user != null)
            {                
                return user;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Addict> Search(string sname, int genderID, int fromAge, int toAge, string SocialNetwork, string CitizenID, Guid? ManagePlaceID)
        {
            int fromyear = 0, toyear = 0;
            IEnumerable<Addict> result;
            if (toAge > 0)
            {
                fromyear = DateTime.Now.Year - fromAge;
                toyear = DateTime.Now.Year - toyear;

                result = (from a in RepositoryContext.Addicts
                          where (a.FirstName.Contains(sname) || a.LastName.Contains(sname) || a.OtherName.Contains(sname))
                          && (a.GenderID == genderID || genderID == -1)
                          && a.SocialNetworkAccount.Contains(SocialNetwork)
                          && a.CitizenID.Contains(CitizenID)
                          && (a.ManagePlaceID == ManagePlaceID || ManagePlaceID == null)
                          && (a.YearOfBirth > fromyear - 1 && a.YearOfBirth < toyear + 1)
                          select a);
            }
            else
            {
                result = (from a in RepositoryContext.Addicts
                              where (a.FirstName.Contains(sname) || a.LastName.Contains(sname) || a.OtherName.Contains(sname))
                              && (a.GenderID == genderID || genderID == -1)
                              && a.SocialNetworkAccount.Contains(SocialNetwork)
                              && a.CitizenID.Contains(CitizenID)
                              && (a.ManagePlaceID == ManagePlaceID || ManagePlaceID == null)
                              select a);
            }
            return result;
        }

        public bool CheckExists(string CitizendID)
        {
            bool user = RepositoryContext.Addicts.Any(x => x.CitizenID.Equals(CitizendID));
            return user;
        }

        public IEnumerable<Addict> GetByPlaceID(Guid placeID)
        {
            try
            {
                return RepositoryContext.Addicts.Where(c => c.ManagePlaceID == placeID);//.Take(100);//.OrderBy(x => x.TenGoi);
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }

        public Addict Create(Addict domain, List<AddictDrugs> drugs, List<AddictManagePlace> places)
        {
            RepositoryContext.BeginTransaction();
            RepositoryContext.Entry(domain).State = Microsoft.EntityFrameworkCore.EntityState.Added;

            foreach (var item in drugs)
            {
                //item.AddictID = domain.OID;
                RepositoryContext.Entry(item).State= Microsoft.EntityFrameworkCore.EntityState.Added;
            }

            foreach (var item in places)
            {
                //item.AddictID = domain.OID;
                RepositoryContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            RepositoryContext.SaveChanges();
            RepositoryContext.CommitTransaction();
            return domain;
        }

        public Addict Create(Addict domain, List<AddictClassify> drugs, List<AddictManagePlace> places)
        {
            RepositoryContext.BeginTransaction();
            RepositoryContext.Entry(domain).State = Microsoft.EntityFrameworkCore.EntityState.Added;

            foreach (var item in drugs)
            {
                //item.AddictID = domain.OID;
                RepositoryContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }

            foreach (var item in places)
            {
                //item.AddictID = domain.OID;
                RepositoryContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            RepositoryContext.SaveChanges();
            RepositoryContext.CommitTransaction();
            return domain;
        }

        public bool Update(Addict domain, List<AddictDrugs> drugs, List<AddictManagePlace> places)
        {
            try
            {
                RepositoryContext.BeginTransaction();
                RepositoryContext.Entry(domain).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                foreach (var item in drugs)
                {
                    //item.AddictID = domain.OID;
                    if (RepositoryContext.AddictDrugss.Any(r => r.OID == item.OID))
                        RepositoryContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    else
                        RepositoryContext.AddictDrugss.Add(item);
                }

                foreach (var item in places)
                {
                    if (RepositoryContext.AddictManagePlaces.Any(r => r.OID == item.OID))
                        RepositoryContext.Set<AddictManagePlace>().Update(item);
                    else
                        RepositoryContext.Set<AddictManagePlace>().Add(item);
                }
                RepositoryContext.SaveChanges();
                RepositoryContext.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                RepositoryContext.RollbackTransaction();
                Commons.NLogAction.instance.logger.Error(ex);
                return false;
            }            
        }

        public bool Update(Addict domain, List<AddictClassify> drugs, List<AddictManagePlace> places)
        {
            try
            {
                RepositoryContext.BeginTransaction();
                RepositoryContext.Entry(domain).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                foreach (var item in drugs)
                {
                    //item.AddictID = domain.OID;
                    if (RepositoryContext.AddictClassifys.Any(r => r.OID == item.OID))
                        RepositoryContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    else
                        RepositoryContext.AddictClassifys.Add(item);
                }

                foreach (var item in places)
                {
                    if (RepositoryContext.AddictManagePlaces.Any(r => r.OID == item.OID))
                        RepositoryContext.Set<AddictManagePlace>().Update(item);
                    else
                        RepositoryContext.Set<AddictManagePlace>().Add(item);
                }
                RepositoryContext.SaveChanges();
                RepositoryContext.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                RepositoryContext.RollbackTransaction();
                Commons.NLogAction.instance.logger.Error(ex);
                return false;
            }
        }
    }
}
