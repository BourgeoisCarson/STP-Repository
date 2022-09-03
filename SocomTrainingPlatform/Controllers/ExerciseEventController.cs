using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocomTrainingPlatform.BuisnessLogic;
using SocomTrainingPlatform.Models;
using SocomTrainingPlatform.Models.ExerciseEventModels;
using SocomTrainingPlatform.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Controllers
{
    public class ExerciseEventController : Controller
    {
        private readonly SocomTrainingPlatformContext _context;
        private readonly SiteSearchLogic searchLogic;

        public ExerciseEventController(SocomTrainingPlatformContext context)
        {
            _context = context;
            searchLogic = new SiteSearchLogic(context);
        }

        public async Task<ActionResult> Index(string message, int id)
        {
            var ViewBagMessage = message;
            var exEvent = await _context.ExerciseEvents.FirstOrDefaultAsync(e => e.Id == id);
            var exDocuments = new List<EventDocument>();
            var exLocations = new List<EventLocation>();
            var allChecklists = new List<CheckListModel>();
            var exExercise = new Excercise();
            
            if(exEvent != null)
            {
                exExercise = await _context.Excercises.FirstOrDefaultAsync(e => e.Id == exEvent.ExerciseId);
                exDocuments = await _context.EventDocuments.Where(e => e.EventId == exEvent.Id).ToListAsync();
                exLocations = await _context.EventLocations.Where(e => e.EventId == exEvent.Id).ToListAsync();               
                var checklist = await _context.EventChecklists.Where(e => e.EventId == exEvent.Id).ToListAsync();              
                foreach(var item in checklist)
                {
                    var checkItem = await _context.ChecklistItems.Where(e => e.ChecklistId == item.Id).ToListAsync();

                    allChecklists.Add(new CheckListModel { Items = checkItem, Checklist = item });
                }
            }

            var eventVm = new EventDetailsModel()
            {
                EventId = id,
                Event = exEvent,
                Exercise = exExercise,
                Locations = exLocations,
                Documents = exDocuments,
                AllCheckLists = allChecklists,
            };

            if (ViewBagMessage != null)
            {
                ViewBag.Alert = AlertService.ShowAlert(Enums.Alerts.Info, ViewBagMessage);
            }

            return View(eventVm);
        }

        public async Task<ActionResult> EditExerciseEvent()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> EditExerciseEvent(int id)
        {
            return View();
        }
        public async Task<ActionResult> DeleteExerciseEvent(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateEvent(ExerciseEvent exEvent)
        {
            string message = null;
            try
            {
                    if (ModelState.IsValid)
                    {
                        ExerciseEvent newEvent = new ExerciseEvent()
                        {
                            EventName = exEvent.EventName,
                            EventDescription = exEvent.EventDescription,
                            StartTime = exEvent.StartTime,
                            EndTime = exEvent.EndTime,
                            ExerciseId = exEvent.ExerciseId,
                            ShowOnCalendar = exEvent.ShowOnCalendar,
                            ShowOnTimeline = exEvent.ShowOnTimeline,
                        };

                    _context.Add(newEvent);
                    await _context.SaveChangesAsync();
                    message = $"Success: Event {newEvent.EventName} created";

                     return View("Excercise/Details", new { id= exEvent.ExerciseId });
                    }                              
            }
            catch
            {
                message = "Error: Could not create event";
            }
            return View("Exercise/Details", new { id = exEvent.ExerciseId });
        }

        public async Task<ActionResult> AddLocation(EventDetailsModel eventModel, int id)
        {
            string message = null;
            var eventLocation = new EventLocation();
            var location = await _context.Locations.FirstOrDefaultAsync(l => l.Name == eventModel.LocationName);
            var field = await _context.SiteFields.FirstOrDefaultAsync(s => s.Id == Convert.ToInt32(eventModel.FieldName));

            eventLocation = new()
            {
                LocationName = eventModel.LocationName,
                FieldName = field.Name,
                StartDate = eventModel.StartDate,
                EndDate = eventModel.EndDate,
                LocationId = location.Id,
                EventId = id,
                FieldType = field.Type,
                Description = eventModel.Description,
            };

            message = $"Success: Location Field {eventModel.FieldName} was added";
            _context.Add(eventLocation);
            await _context.SaveChangesAsync();
            //try
            //{
               
            //}
            //catch
            //{
            //    message = "Error: Location could not be added";
            //}

            return RedirectToAction("Index", new { message = message, id = id });
        }

        

    }
}
