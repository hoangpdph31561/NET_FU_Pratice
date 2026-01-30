using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation
{
    public class GiangVien : Human
    {
        private int myiYearOfExperience;
        private string mysSpecialization;

        public int YearOfExperience { get => myiYearOfExperience; set => myiYearOfExperience = value; }
        public string Specialization { get => mysSpecialization; set => mysSpecialization = value; }
        public GiangVien()
        {
            
        }

        public GiangVien(string mysId, string mysName, int myiBirthYear, int myiYearOfExperience, string mysSpecialization) : base(mysId, mysName, myiBirthYear)
        {
            this.myiYearOfExperience = myiYearOfExperience;
            this.mysSpecialization = mysSpecialization;
        }

        public override void PrintInformation()
        {
            base.PrintInformation();
            Console.WriteLine($"{myiYearOfExperience} {mysSpecialization}");
        }
    }
}
