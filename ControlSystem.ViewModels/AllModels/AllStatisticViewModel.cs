using ProjectDavomat.BL.Interface;
using ProjectDavomat.Data.DataLayer;
using ProjectDavomat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDavomat.ViewModels
{
    public class AllStatisticViewModel
    {
        public List<Course> Courses { get; set; }
        public Leader Leader { get; set; }
        public Service Service { get; set; }
        public Staff Staff { get; set; }
        public Teacher Teacher { get; set; }

    }
}
