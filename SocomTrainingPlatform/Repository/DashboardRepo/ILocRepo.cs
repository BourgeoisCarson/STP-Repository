using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SocomTrainingPlatform.Data;
using RavenSiteSurvey.Models;
using RavenSiteSurvey.Models.VIewModels;
using SocomTrainingPlatform.Models;

namespace RavenSiteSurvey.Repositories
{
    public interface ILocRepo : IDisposable
    {

       IEnumerable<Target> GetTargetResults(string result);
        //IEnumerable<TrainingAreaType> GetTrainingArea(string trainingTypes);
        //IEnumerable<Meeting> getMeetingResults(string result);
        //IEnumerable<InsertPoint> getInsertPointResults(string result);
        //IEnumerable<BerthingWork> GetBerthingWorks(string result);
        //IEnumerable<Support> getSupportResults(string result);



    }
}
