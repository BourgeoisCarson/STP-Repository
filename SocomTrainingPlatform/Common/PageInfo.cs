using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Models
{
    public class PageInfo
    {

        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public PageInfo()
        {
            CurrentPage = 1;
        }
        //starting item number in the page
        public int PageStart
        {
            get { return ((CurrentPage - 1) * ItemsPerPage + 1); }
        }
        //last item number in the page
        public int PageEnd
        {
            get
            {
                int currentTotal = (CurrentPage - 1) * ItemsPerPage + ItemsPerPage;
                return (currentTotal < TotalItems ? currentTotal : TotalItems);
            }
        }
        public int LastPage
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
    }
        
}
