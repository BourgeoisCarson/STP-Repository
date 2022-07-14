using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Models.SiteModels
{
    public class TargetModel
    {
        public Target Target { get; set; }

        public List<TargetImage> Images { get; set; }
    }

    public class InsertModel
    {
        public InsertPoint InsertPoint { get; set; }
        public List<InsertImage> Images { get; set; }
    }

    public class BerthingModel
    {
        public BerthingWork Berthing { get; set; }
        public List<BerthingImage> Images { get; set; }
    }

    public class SupportModel
    {
        public Support Support { get; set; }
        public List<SupportImage> Image { get; set;}
    }

    public class MeetingModel
    {
        public Meeting Meeting { get; set; }
        public List<MeetingImage> Images { get; set; }
    }


}
