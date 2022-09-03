using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Models.ExerciseEventModels
{
    public class EventDetailsModel
    {
        public int ExerciseId { get; set; }
        public int EventId { get; set; }
        public Excercise Exercise { get; set; }
        public ExerciseEvent Event { get; set; }
        public List<CheckListModel> AllCheckLists { get; set; }
        public List<EventDocument> Documents { get; set; }
        public List<EventLocation> Locations { get; set; }

        //Modal Fields for adding LOCATION
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LocationName { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }

        //Modal Fields for adding DOCUMENTS
        public string DocumentName { get; set; }
        public byte[] Data { get; set; }
        public string FileType { get; set; }
        public DateTime UploadDate { get; set; }

        //Modal Fields for adding CheckLists
        public int ChecklistId { get; set; }
        public string ChecklistName { get; set; }

        //Modal Fields for ChecklistItems
        public string ChecklistItemName { get; set; }
        public bool Completed { get; set; }

    }

    public class CheckListModel
    {
        public EventChecklist Checklist { get; set; }
        public List<ChecklistItem> Items { get; set; }
    }
}
