using System;

namespace Presentation
{
    public class SinhVien : Human
    {
        private double mydAverageScore;
        private string mysAcademicPerformance;

        public double AverageScore 
        { 
            get => mydAverageScore; 
            set => mydAverageScore = value; 
        }
        
        public string AcademicPerformance 
        { 
            get => mysAcademicPerformance; 
            set => mysAcademicPerformance = value; 
        }

        public SinhVien()
        {
        }

        public SinhVien(string mysId, string mysName, int myiBirthYear, double mydAverageScore, string mysAcademicPerformance) 
            : base(mysId, mysName, myiBirthYear)
        {
            this.mydAverageScore = mydAverageScore;
            this.mysAcademicPerformance = mysAcademicPerformance;
        }

        public override void PrintInformation()
        {
            base.PrintInformation();
            Console.WriteLine($"Average Score: {mydAverageScore}");
            Console.WriteLine($"Academic Performance: {mysAcademicPerformance}");
        }

        // Phương thức đa hình - Tính học lực dựa trên điểm trung bình
        public virtual string CalculateAcademicPerformance()
        {
            if (mydAverageScore >= 9.0)
                return "Xuất sắc";
            else if (mydAverageScore >= 8.0)
                return "Giỏi";
            else if (mydAverageScore >= 6.5)
                return "Khá";
            else if (mydAverageScore >= 5.0)
                return "Trung bình";
            else
                return "Yếu";
        }
    }
}
