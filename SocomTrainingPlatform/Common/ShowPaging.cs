using SocomTrainingPlatform.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Common
{
    public class ShowPaging
    {
        //validation for required, only numbers, allowed range-1 to 500
        [Required(ErrorMessage = "Value is Required!.Please enter value between 1 and 500.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Only positive numbers are allowed.Please enter value between 1 and 500.")]
        [Range(1, 500, ErrorMessage = "Please enter value between 1 and 500.")]
        public int InputNumber { get; set; }

        public List<string> DisplayResult { get; set; }

        public PageInfo PageInfo;
    }
}
