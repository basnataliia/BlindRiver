using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindRiver.Models
{
    public class Surveys
    {
        //creating an instance of the LINQ object
        SurveysDataContext objSurvey = new SurveysDataContext();

        public IQueryable<Survey> getSurvey()
        {
            var allSurvey = objSurvey.Surveys.Select(x => x);
            return allSurvey;
        }

        public Survey getSurveyByID(int _id)
        {
            var allSurveys = objSurvey.Surveys.SingleOrDefault(x => x.id == _id);
            return allSurveys;
        }

        public bool commitInsert(Survey survey)
        {
            using (objSurvey)
            {
                objSurvey.Surveys.InsertOnSubmit(survey);
                objSurvey.SubmitChanges();
                return true;
            }
        }

        //public bool commitUpdate (int _id, string _questions, string _answers)
        //{
        //    using (objSurvey)
        //    {
        //        var ObjUpSurvey = objSurvey.Surveys.Single(x => x.id == _id);
        //        ObjUpSurvey.Questions = _questions;
        //        ObjUpSurvey.Answers = _answers;
        //        objSurvey.SubmitChanges();
        //        return true;
        //    }
        //}

        public bool commitDelete(int _id)
        {
            using (objSurvey)
            {
                var objDelSurvey = objSurvey.Surveys.Single(x => x.id == _id);
                objSurvey.Surveys.DeleteOnSubmit(objDelSurvey);
                objSurvey.SubmitChanges();
                return true;
            }
        }
    }
}