using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Model;

namespace WebApplication2.Data
{
    public class HolidayRepository
    {
        public IEnumerable<SelectListItem> GetHolidays()
        {         
                    var holidays = new List<HolidayCalendar>();
                    for (int i = 0; i < 50; i++)
                    {
                        holidays.Add(new HolidayCalendar()
                          {
                            Id=i,
                            HolidayDate = DateTime.Now.AddDays(new Random().Next(1, 3000))
                           }
                        );
                    }
           
                    var holidayItems = holidays
                        .OrderBy(n => n.HolidayDate)
                        .GroupBy(n=>n.HolidayDate.Year)
                        .Select(n =>
                           new SelectListItem
                           {
                               Value = n.FirstOrDefault()?.HolidayDate.Year.ToString(),
                               Text = n.FirstOrDefault()?.HolidayDate.Year.ToString()
                           }).ToList();

                        var countrytip = new SelectListItem()
                        {
                            Value = null,
                            Text = "--- select Holiday ---"
                        };
                     holidayItems.Insert(0, countrytip);
            return new SelectList(holidayItems, "Value", "Text");
               
        }

        public IEnumerable<HolidayCalendar> GetHolidays(string year)
        {
            if (!String.IsNullOrWhiteSpace(year))
            {
                var selectedYear = Convert.ToInt32(year);
               
                var holidays = new List<HolidayCalendar>();
                for (int i = 0; i < 50; i++)
                {
                    holidays.Add(new HolidayCalendar()
                    {
                        Id = i,
                        HolidayDate = DateTime.Now.AddDays(new Random().Next(1, 3000))
                    }
                    );
                }

                //using (var context = new ApplicationDbContext())
                {
                    var HolidayYears = holidays
                         .OrderBy(n => n.HolidayDate)
                         .Where(n => n.HolidayDate.Year == selectedYear)
                         .Select(n=>
                            new HolidayCalendar {
                                Id=n.Id,
                                HolidayDate=n.HolidayDate,
                                DisplayDate=n.HolidayDate.ToShortDateString()
                            });

                    return HolidayYears;
                }
            }
            return null;
        }
    }
}
