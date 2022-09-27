using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SearchingSYS
{
    public class CV
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int MinimumSalary { get; set; }
        public string Number { get; set; }
        public Sex Sex { get; set; }
        public Education Education { get; set; }
        public WorkExperience WorkExperience { get; set; }
        public Category Category { get; set; }
        public City City { get; set; }
    }

    public enum Sex
    {
        Male = 1,
        Female
    }
    public enum Education
    {
        Secondary = 1,
        IncompleteHigher,
        Higher
    }
    public enum WorkExperience
    {
        LessThan1Year = 1,
        Form1To3Year,
        Form3To5Year,
        MoreThan5Year
    }
    public enum Category
    {
        Programmer = 1,
        ItSpecialist,
        Doctor,
        Teacher,
        Journalist,
        Translator
    }
    public enum City
    {
        Baku = 1,
        Shamaxi,
        Quba,
        Xizi
    }
}