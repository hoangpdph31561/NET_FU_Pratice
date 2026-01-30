using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation
{
    public abstract class Human : IHuman
    {
        private string mysId;
        private string mysName;
        private int myiBirthYear;
        protected Human()
        {
            
        }

        protected Human(string mysId, string mysName, int myiBirthYear)
        {
            this.mysId = mysId;
            this.mysName = mysName;
            this.myiBirthYear = myiBirthYear;
        }

        public string Id { get => mysId; set => mysId = value; }
        public string Name { get => mysName; set => mysName = value; }
        public int BirthYear { get => myiBirthYear; set => myiBirthYear = value; }

        public int CalculateAge(int theiBirthYear)
        {
            int aiCurrentYear = DateTime.Now.Year;
            return aiCurrentYear - theiBirthYear;
        }
        public virtual void PrintInformation()
        {
            Console.WriteLine($"{myiBirthYear} {mysId} {mysName} {CalculateAge(myiBirthYear)}");
        }
    }
}
