using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CampusRetreat.ViewModels
{
    public class InputHelpers
    {
        public static List<SelectListItem> Genders = new List<SelectListItem>
        {
            new SelectListItem { Value = "male", Text = "Male" },
            new SelectListItem { Value = "female", Text = "Female" }
        };

        public static List<SelectListItem> AgeGroups = new List<SelectListItem>
        {
            new SelectListItem { Value = "<= 15", Text = "15 and Below" },
            new SelectListItem { Value = "15-20", Text = "15 to 20" },
            new SelectListItem { Value = "21-25", Text = "21 to 25" },
            new SelectListItem { Value = "26-30", Text = "26 to 30" },
            new SelectListItem { Value = ">= 30", Text = "31 and Above"}
        };

        public static List<SelectListItem> YearsOfStudy = new List<SelectListItem>
        {
            new SelectListItem { Value = "first", Text = "First"},
            new SelectListItem { Value = "second", Text = "Second"},
            new SelectListItem { Value = "third", Text = "Third"},
            new SelectListItem { Value = "fourth", Text = "Fourth"},
            new SelectListItem { Value = "fifth", Text = "Fifth"},
            new SelectListItem { Value = "sixth", Text = "Sixth"},
            new SelectListItem { Value = "seventh", Text = "Seventh"},
            new SelectListItem { Value = "graduated", Text = "Graduated"}
        };

        public static List<SelectListItem> Memberships = new List<SelectListItem>
        {
            new SelectListItem { Value = "visitor", Text = "Vistor"},
            new SelectListItem { Value = "member", Text = "Member" },
            new SelectListItem { Value = "worker", Text = "Worker" }
        };

        public static List<SelectListItem> MaritalStatuses = new List<SelectListItem>
        {
            new SelectListItem { Value = "single", Text = "Single" },
            new SelectListItem { Value = "married", Text = "Married" },
            new SelectListItem { Value = "other", Text = "Other" }
        };
    }
}
