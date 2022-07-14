using System;
using System.Collections.Generic;

#nullable disable

namespace SocomTrainingPlatform.Models
{
    public partial class ExcerciseType
    {
        public ExcerciseType()
        {
            Excercises = new HashSet<Excercise>();
        }

        public int Id { get; set; }
        public string ExcerciseName { get; set; }
        public string ExcerciseDescription { get; set; }
        public int? OrgId { get; set; }

        public virtual Organization Org { get; set; }
        public virtual ICollection<Excercise> Excercises { get; set; }
    }
}
