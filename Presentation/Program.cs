using System;
using Presentation;

// ========== HƯỚNG DẪN DEBUG ==========
// 1. Đặt breakpoint tại các dòng đánh dấu [BREAKPOINT] để quan sát
// 2. Sử dụng F10 (Step Over) để chạy từng dòng
// 3. Sử dụng F11 (Step Into) để đi vào bên trong method
// 4. Quan sát giá trị biến trong Debug > Locals window
// 5. Thêm Watch để theo dõi biến cụ thể (Debug > Watch)

Console.OutputEncoding = System.Text.Encoding.UTF8;
var service = new Service();

Console.WriteLine("╔════════════════════════════════════════════════════════╗");
Console.WriteLine("║     CHƯƠNG TRÌNH QUẢN LÝ SINH VIÊN VÀ GIẢNG VIÊN      ║");
Console.WriteLine("╚════════════════════════════════════════════════════════╝\n");

// ==================== PHẦN 1: CREATE - TẠO DỮ LIỆU ====================
Console.WriteLine("\n【1】 DEMO: TẠO SINH VIÊN VÀ GIẢNG VIÊN");
Console.WriteLine("═══════════════════════════════════════════════════════\n");

// [BREAKPOINT] Đặt breakpoint ở đây để xem quá trình tạo sinh viên
Console.WriteLine("→ Tạo sinh viên đơn lẻ...");
var sinhVien1 = new SinhVien("SV001", "Nguyễn Văn An", 2003, 8.5, "Giỏi");
service.Create(sinhVien1);

var sinhVien2 = new SinhVien("SV002", "Trần Thị Bình", 2004, 9.2, "Xuất sắc");
service.Create(sinhVien2);

var sinhVien3 = new SinhVien("SV003", "Lê Văn Cường", 2003, 6.8, "Khá");
service.Create(sinhVien3);

// [BREAKPOINT] Đặt breakpoint ở đây để xem CreateMultiple hoạt động
Console.WriteLine("\n→ Tạo nhiều sinh viên cùng lúc...");
var danhSachSinhVien = new List<SinhVien>
{
    new SinhVien("SV004", "Phạm Thị Dung", 2004, 7.5, "Khá"),
    new SinhVien("SV005", "Hoàng Văn Em", 2003, 5.2, "Trung bình"),
    new SinhVien("SV006", "Đặng Thị Phương", 2004, 8.9, "Giỏi")
};
service.CreateMultiple(danhSachSinhVien);

// [BREAKPOINT] Tạo giảng viên
Console.WriteLine("\n→ Tạo giảng viên...");
var giangVien1 = new GiangVien("GV001", "TS. Nguyễn Văn Giáo", 1975, 15, "Cơ sở dữ liệu");
service.Create(giangVien1);

var giangVien2 = new GiangVien("GV002", "PGS. Trần Thị Huệ", 1980, 10, "Lập trình OOP");
service.Create(giangVien2);

var danhSachGiangVien = new List<GiangVien>
{
    new GiangVien("GV003", "ThS. Lê Văn Ích", 1985, 8, "Mạng máy tính"),
    new GiangVien("GV004", "TS. Phạm Thị Kiều", 1978, 12, "Trí tuệ nhân tạo")
};
service.CreateMultiple(danhSachGiangVien);

Console.WriteLine("\n✓ Đã tạo xong dữ liệu mẫu!");
Console.WriteLine("\n[Nhấn phím bất kỳ để tiếp tục...]");
Console.ReadKey();

// ==================== PHẦN 2: READ - ĐỌC VÀ HIỂN THỊ ====================
Console.WriteLine("\n\n【2】 DEMO: HIỂN THỊ DANH SÁCH");
Console.WriteLine("═══════════════════════════════════════════════════════");

// [BREAKPOINT] Debug: Xem danh sách sinh viên
service.PrintAll<SinhVien>();

// [BREAKPOINT] Debug: Xem danh sách giảng viên
service.PrintAll<GiangVien>();

Console.WriteLine("[Nhấn phím bất kỳ để tiếp tục...]");
Console.ReadKey();

// ==================== PHẦN 3: QUERY - TÌM KIẾM ====================
Console.WriteLine("\n\n【3】 DEMO: TÌM KIẾM THEO TÊN");
Console.WriteLine("═══════════════════════════════════════════════════════\n");

// [BREAKPOINT] Debug: Xem kết quả tìm kiếm
Console.WriteLine("→ Tìm sinh viên có tên chứa 'Văn':");
var ketQuaTimKiem1 = service.FindByName<SinhVien>("Văn");
foreach (var sv in ketQuaTimKiem1)
{
    Console.WriteLine($"  • {sv.Id} - {sv.Name} - Điểm: {sv.AverageScore}");
}

Console.WriteLine("\n→ Tìm giảng viên có tên chứa 'Thị':");
var ketQuaTimKiem2 = service.FindByName<GiangVien>("Thị");
foreach (var gv in ketQuaTimKiem2)
{
    Console.WriteLine($"  • {gv.Id} - {gv.Name} - Kinh nghiệm: {gv.YearOfExperience} năm");
}

Console.WriteLine("\n[Nhấn phím bất kỳ để tiếp tục...]");
Console.ReadKey();

// ==================== PHẦN 4: SORT - SẮP XẾP ====================
Console.WriteLine("\n\n【4】 DEMO: SẮP XẾP");
Console.WriteLine("═══════════════════════════════════════════════════════\n");

// [BREAKPOINT] Debug: Xem danh sách sau khi sắp xếp
Console.WriteLine("→ Sắp xếp sinh viên theo điểm số (cao xuống thấp):");
var danhSachSapXep1 = service.SortSinhVienByScore(true);
foreach (var sv in danhSachSapXep1)
{
    Console.WriteLine($"  {sv.Name,-25} - Điểm: {sv.AverageScore:F1} - {sv.AcademicPerformance}");
}

Console.WriteLine("\n→ Sắp xếp giảng viên theo năm kinh nghiệm (nhiều xuống ít):");
var danhSachSapXep2 = service.SortGiangVienByExperience(true);
foreach (var gv in danhSachSapXep2)
{
    Console.WriteLine($"  {gv.Name,-25} - Kinh nghiệm: {gv.YearOfExperience} năm - {gv.Specialization}");
}

Console.WriteLine("\n[Nhấn phím bất kỳ để tiếp tục...]");
Console.ReadKey();

// ==================== PHẦN 5: UPDATE - CẬP NHẬT ====================
Console.WriteLine("\n\n【5】 DEMO: CẬP NHẬT THÔNG TIN");
Console.WriteLine("═══════════════════════════════════════════════════════\n");

Console.WriteLine("→ Trước khi cập nhật:");
var svTruocUpdate = service.GetAll<SinhVien>().FirstOrDefault(sv => sv.Id == "SV001");
Console.WriteLine($"  {svTruocUpdate?.Id} - {svTruocUpdate?.Name} - Điểm: {svTruocUpdate?.AverageScore}");

// [BREAKPOINT] Debug: Xem quá trình update
Console.WriteLine("\n→ Đang cập nhật sinh viên SV001...");
var sinhVienCapNhat = new SinhVien("SV001", "Nguyễn Văn An", 2003, 9.5, "Xuất sắc");
bool ketQuaUpdate1 = service.Update("SV001", sinhVienCapNhat);

Console.WriteLine($"\n→ Sau khi cập nhật (Kết quả: {(ketQuaUpdate1 ? "Thành công ✓" : "Thất bại ✗")}):");
var svSauUpdate = service.GetAll<SinhVien>().FirstOrDefault(sv => sv.Id == "SV001");
Console.WriteLine($"  {svSauUpdate?.Id} - {svSauUpdate?.Name} - Điểm: {svSauUpdate?.AverageScore}");

// Update giảng viên
Console.WriteLine("\n→ Cập nhật giảng viên GV002...");
var giangVienCapNhat = new GiangVien("GV002", "PGS.TS. Trần Thị Huệ", 1980, 11, "Lập trình OOP & Design Pattern");
bool ketQuaUpdate2 = service.Update("GV002", giangVienCapNhat);
Console.WriteLine($"  Kết quả: {(ketQuaUpdate2 ? "Thành công ✓" : "Thất bại ✗")}");

Console.WriteLine("\n[Nhấn phím bất kỳ để tiếp tục...]");
Console.ReadKey();

// ==================== PHẦN 6: DELETE - XÓA ====================
Console.WriteLine("\n\n【6】 DEMO: XÓA DỮ LIỆU");
Console.WriteLine("═══════════════════════════════════════════════════════\n");

Console.WriteLine($"→ Số sinh viên trước khi xóa: {service.GetAll<SinhVien>().Count}");

// [BREAKPOINT] Debug: Xem quá trình delete
Console.WriteLine("\n→ Xóa sinh viên SV005...");
bool ketQuaXoa1 = service.Delete<SinhVien>("SV005");
Console.WriteLine($"  Kết quả: {(ketQuaXoa1 ? "Thành công ✓" : "Thất bại ✗")}");

Console.WriteLine($"\n→ Số sinh viên sau khi xóa: {service.GetAll<SinhVien>().Count}");

// Thử xóa ID không tồn tại
Console.WriteLine("\n→ Thử xóa sinh viên không tồn tại (SV999)...");
bool ketQuaXoa2 = service.Delete<SinhVien>("SV999");
Console.WriteLine($"  Kết quả: {(ketQuaXoa2 ? "Thành công ✓" : "Thất bại ✗")}");

Console.WriteLine("\n[Nhấn phím bất kỳ để tiếp tục...]");
Console.ReadKey();

// ==================== PHẦN 7: DEMO PHƯƠNG THỨC ĐA HÌNH ====================
Console.WriteLine("\n\n【7】 DEMO: PHƯƠNG THỨC ĐA HÌNH");
Console.WriteLine("═══════════════════════════════════════════════════════\n");

Console.WriteLine("→ Tính học lực tự động cho sinh viên:");
var danhSachSinhVienHienTai = service.GetAll<SinhVien>();
foreach (var sv in danhSachSinhVienHienTai)
{
    // [BREAKPOINT] Debug: Xem phương thức CalculateAcademicPerformance hoạt động
    string hocLucTinhToan = sv.CalculateAcademicPerformance();
    Console.WriteLine($"  {sv.Name,-25} - Điểm: {sv.AverageScore:F1} → Học lực: {hocLucTinhToan}");
}

Console.WriteLine("\n[Nhấn phím bất kỳ để tiếp tục...]");
Console.ReadKey();

// ==================== PHẦN 8: KIỂM TRA CUỐI CÙNG ====================
Console.WriteLine("\n\n【8】 TỔNG KẾT");
Console.WriteLine("═══════════════════════════════════════════════════════\n");

int tongSinhVien = service.GetAll<SinhVien>().Count;
int tongGiangVien = service.GetAll<GiangVien>().Count;

Console.WriteLine($"📊 Tổng số sinh viên: {tongSinhVien}");
Console.WriteLine($"📊 Tổng số giảng viên: {tongGiangVien}");

// Tính điểm trung bình của tất cả sinh viên
var diemTrungBinh = service.GetAll<SinhVien>().Average(sv => sv.AverageScore);
Console.WriteLine($"📊 Điểm trung bình chung: {diemTrungBinh:F2}");

// Sinh viên có điểm cao nhất
var svDiemCaoNhat = service.SortSinhVienByScore(true).FirstOrDefault();
Console.WriteLine($"🏆 Sinh viên xuất sắc nhất: {svDiemCaoNhat?.Name} ({svDiemCaoNhat?.AverageScore:F1} điểm)");

// Giảng viên có kinh nghiệm nhất
var gvKinhNghiemNhat = service.SortGiangVienByExperience(true).FirstOrDefault();
Console.WriteLine($"🏆 Giảng viên kỳ cựu nhất: {gvKinhNghiemNhat?.Name} ({gvKinhNghiemNhat?.YearOfExperience} năm)");

Console.WriteLine("\n\n╔════════════════════════════════════════════════════════╗");
Console.WriteLine("║              HOÀN THÀNH CHƯƠNG TRÌNH DEMO             ║");
Console.WriteLine("╚════════════════════════════════════════════════════════╝");

Console.WriteLine("\n[Nhấn phím bất kỳ để kết thúc...]");
Console.ReadKey();

static int CalculateAge(int theiBirthYear)
{
    int aiCurrentYear = DateTime.Now.Year;
    return aiCurrentYear - theiBirthYear;
}
