using SwaggerLoggerProject.Models;
using System;
using System.Collections.Generic;

namespace SwaggerLoggerProject.ViewModels
{
    public class ReservationViewModel
    {
        public string Name { set; get; }
        public DateTime Date { set; get; }
        public List<MenuItem> MenuItems { set; get; }
    }
}
