using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presentation
{
    public class Service
    {
        private Dictionary<Type, List<Human>> mydicData;

        public Service()
        {
            mydicData = new Dictionary<Type, List<Human>>
            {
                { typeof(SinhVien), new List<Human>() },
                { typeof(GiangVien), new List<Human>() }
            };
        }

        #region Generic CRUD Methods

        // Create một đối tượng
        public void Create<T>(T theoEntity) where T : Human
        {
            var aType = typeof(T);
            mydicData[aType].Add(theoEntity);
            Console.WriteLine($"Đã thêm {aType.Name}: {theoEntity.Name}");
        }

        // Create nhiều đối tượng
        public void CreateMultiple<T>(List<T> theolstEntities) where T : Human
        {
            var aType = typeof(T);
            mydicData[aType].AddRange(theolstEntities.Cast<Human>());
            Console.WriteLine($"Đã thêm {theolstEntities.Count} {aType.Name}");
        }

        // Update đối tượng
        public bool Update<T>(string thesId, T theoUpdatedEntity) where T : Human
        {
            var aType = typeof(T);
            var aoEntity = mydicData[aType].FirstOrDefault(e => e.Id == thesId) as T;
            
            if (aoEntity != null)
            {
                aoEntity.Name = theoUpdatedEntity.Name;
                aoEntity.BirthYear = theoUpdatedEntity.BirthYear;

                // Cập nhật thuộc tính riêng của từng loại
                if (aoEntity is SinhVien aoSinhVien && theoUpdatedEntity is SinhVien aoUpdatedSinhVien)
                {
                    aoSinhVien.AverageScore = aoUpdatedSinhVien.AverageScore;
                    aoSinhVien.AcademicPerformance = aoUpdatedSinhVien.AcademicPerformance;
                }
                else if (aoEntity is GiangVien aoGiangVien && theoUpdatedEntity is GiangVien aoUpdatedGiangVien)
                {
                    aoGiangVien.YearOfExperience = aoUpdatedGiangVien.YearOfExperience;
                    aoGiangVien.Specialization = aoUpdatedGiangVien.Specialization;
                }

                Console.WriteLine($"Đã cập nhật {aType.Name}: {aoEntity.Name}");
                return true;
            }
            
            Console.WriteLine($"Không tìm thấy {aType.Name} với ID: {thesId}");
            return false;
        }

        // Delete đối tượng
        public bool Delete<T>(string thesId) where T : Human
        {
            var aType = typeof(T);
            var aoEntity = mydicData[aType].FirstOrDefault(e => e.Id == thesId);
            
            if (aoEntity != null)
            {
                mydicData[aType].Remove(aoEntity);
                Console.WriteLine($"Đã xóa {aType.Name}: {aoEntity.Name}");
                return true;
            }
            
            Console.WriteLine($"Không tìm thấy {aType.Name} với ID: {thesId}");
            return false;
        }

        // Lấy tất cả đối tượng
        public List<T> GetAll<T>() where T : Human
        {
            var aType = typeof(T);
            return mydicData[aType].Cast<T>().ToList();
        }

        #endregion

        #region Generic Query Methods

        // Tìm theo tên
        public List<T> FindByName<T>(string thesName) where T : Human
        {
            var aType = typeof(T);
            var alstResult = mydicData[aType]
                .Cast<T>()
                .Where(e => e.Name.Contains(thesName, StringComparison.OrdinalIgnoreCase))
                .ToList();
            
            Console.WriteLine($"Tìm thấy {alstResult.Count} {aType.Name} với tên chứa '{thesName}'");
            return alstResult;
        }

        // Sắp xếp sinh viên theo điểm số
        public List<SinhVien> SortSinhVienByScore(bool thebDescending = true)
        {
            var alstSinhVien = mydicData[typeof(SinhVien)].Cast<SinhVien>();
            
            if (thebDescending)
                return alstSinhVien.OrderByDescending(sv => sv.AverageScore).ToList();
            else
                return alstSinhVien.OrderBy(sv => sv.AverageScore).ToList();
        }

        // Sắp xếp giảng viên theo năm kinh nghiệm
        public List<GiangVien> SortGiangVienByExperience(bool thebDescending = true)
        {
            var alstGiangVien = mydicData[typeof(GiangVien)].Cast<GiangVien>();
            
            if (thebDescending)
                return alstGiangVien.OrderByDescending(gv => gv.YearOfExperience).ToList();
            else
                return alstGiangVien.OrderBy(gv => gv.YearOfExperience).ToList();
        }

        // In danh sách generic
        public void PrintAll<T>() where T : Human
        {
            var aType = typeof(T);
            Console.WriteLine($"\n=== DANH SÁCH {aType.Name.ToUpper()} ===");
            
            foreach (var aoEntity in mydicData[aType])
            {
                aoEntity.PrintInformation();
                Console.WriteLine();
            }
        }

        #endregion
    }
}
