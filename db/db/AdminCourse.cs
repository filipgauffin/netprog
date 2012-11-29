using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace db
{
    public class AdminCourse
    {
        public String CourseName { get; set; }
        public int Period { get; set; } // HT eller VT
        public int Year { get; set; }
        public ArrayList Students { get; set; }
        public ArrayList Assistents { get; set; }
        public ArrayList CourseParts { get; set; } // Kursmoment
        public ArrayList PartResults { get; set; } // Delresultat
        public String EndGradeScript { get; set; }
        public int EndGradeMethod { get; set; }

        //public ArrayList PartGrades { get; set; } // replace with array of partGrade class instead of array of String
        public AdminCourse(String cName, int period, int year)
        {
            this.CourseName = cName;
            this.Period = period;
            this.Year = year;
            this.EndGradeScript = "";
            this.CourseParts = new ArrayList();
            this.Students = new ArrayList();
            this.Assistents = new ArrayList();
            this.PartResults = new ArrayList();
        }
        public String getFullName()
        {
            String period = "VT";
            if (Period == 1)
                period = "HT";
            return CourseName + period + Year;
        }
    }
}