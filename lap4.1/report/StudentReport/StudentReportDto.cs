using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lap4._1.report.StudentReport
{
    internal class StudentReportDto
    {
        public string StudentID { get; set; }
        public string FullName { get; set; }

        public double AverageScore { get; set; }

        public string FacultyName { get; set; }
    }
}
