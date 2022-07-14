using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SocomTrainingPlatform.Data;
using RavenSiteSurvey.Models;
using RavenSiteSurvey.Models.VIewModels;

namespace RavenSiteSurvey.Models.VIewModels
{
    public class FilterOption
    {

        public List<SelectListItem> targetFields { get; } = new List<SelectListItem>
            {
                new SelectListItem {Value = "Da/Raid", Text = "DA/Raid"},
                new SelectListItem {Value = "Rs", Text = "R&S"},
                new SelectListItem {Value = "VehicleIntrediction", Text = "Vehicle Intrediction"},
                new SelectListItem {Value = "Ambush", Text = "Ambush"},
                new SelectListItem {Value = "RAA", Text = "RAA"},
                new SelectListItem {Value = "Virtual/Synthetic", Text = "Virtual/Synthetic"},

            };

        public List<SelectListItem> insertPointFields { get; } = new List<SelectListItem>
            {
                new SelectListItem {Value = "AirfieldRunway", Text = "AirField/Runway"},
                new SelectListItem {Value = "Dz", Text = "DZ"},
                new SelectListItem {Value = "Hlz", Text = "HLZ"},
                new SelectListItem {Value = "Bls", Text = "BLS"},
                new SelectListItem {Value = "SplashPoint", Text = "Splash Point"},
                new SelectListItem {Value = "VdoLagger", Text = "VDO/Lagger"},

            };

        public List<SelectListItem> trainingTypeFields { get; } = new List<SelectListItem>
            {
                new SelectListItem {Value = "Private", Text = "Private"},
                new SelectListItem {Value = "MilFed", Text = "MIL/FED"},
                new SelectListItem {Value = "Lea", Text = "LEA"},
                new SelectListItem {Value = "Commerical", Text = "Commercial"},
                new SelectListItem {Value = "Fire/Medical", Text = "Fire/Medical"},

            };

        public List<SelectListItem> supportField { get; } = new List<SelectListItem>
            {
                new SelectListItem {Value = "FuelFarm", Text = "Fuel Farm"},
                new SelectListItem {Value = "MotorPool", Text = "MotorPool"},
                new SelectListItem {Value = "Contractor", Text = "Contractor"},
                new SelectListItem {Value = "MedicalFacility", Text = "Medical Facility"},


            };

        public List<SelectListItem> berthingWorkField { get; } = new List<SelectListItem>
            {
                new SelectListItem {Value = "Ecg", Text = "ECG"},
                new SelectListItem {Value = "SotfHhq", Text = "SOTF/HHQ"},
                new SelectListItem {Value = "Company", Text = "Company Site"},
                new SelectListItem {Value = "TeamSite", Text = "TeamSite"},


            };

        public List<SelectListItem> meeting { get; } = new List<SelectListItem>
            {
                new SelectListItem {Value = "Sa", Text = "S/A"},
                new SelectListItem {Value = "Kle", Text = "KLE"},
            };



    }
}