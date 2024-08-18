public class DiaDiem
{
    public string Ten { get; set; }
    public double ViDo { get; set; }
    public double KinhDo { get; set; }
}

public class Program
{
    static void Main()
    {
        // Định nghĩa các địa điểm
        List<DiaDiem> dsDiaDiem = new List<DiaDiem>
        {
            new DiaDiem { Ten = "A", ViDo = 5.0, KinhDo = 10.0 },
            new DiaDiem { Ten = "B", ViDo = 8.0, KinhDo = 26.0 },
            new DiaDiem { Ten = "C", ViDo = 15.0, KinhDo = 20.0 },
            new DiaDiem { Ten = "D", ViDo = 18.0, KinhDo = 20.0 }
        };

        // Ma trận khoảng cách
        double[,] maTranKhoangCach = new double[,]
        {
            { 0, 8.0, 12.0, 15.0 },
            { 8.0, 0, 10.0, 20.0 },
            { 12.0, 10.0, 0, 25.0 },
            { 15.0, 20.0, 25.0, 0 }

        };

        // Tìm đường đi tối ưu
        double khoangCachToiThieu = double.MaxValue;
        List<string> tuyenDuongToiUu = new List<string>();
        TimTuyenDuong(dsDiaDiem, maTranKhoangCach, new List<string>(), 0, ref khoangCachToiThieu, ref tuyenDuongToiUu);

        // In kết quả
        Console.WriteLine("Tuyen đuong toi uu:");
        foreach (string diaDiem in tuyenDuongToiUu)
        {
            Console.Write(diaDiem + " -> ");
        }
        Console.WriteLine("Tong khoang cach: " + khoangCachToiThieu);
    }

    static void TimTuyenDuong(List<DiaDiem> dsDiaDiem, double[,] maTranKhoangCach, List<string> tuyenDuongHienTai, int chiSoHienTai, ref double khoangCachToiThieu, ref List<string> tuyenDuongToiUu)
    {
        if (tuyenDuongHienTai.Count == dsDiaDiem.Count)
        {
            double tongKhoangCach = 0;
            for (int i = 0; i < tuyenDuongHienTai.Count - 1; i++)
            {
                int tu = dsDiaDiem.FindIndex(d => d.Ten == tuyenDuongHienTai[i]);
                int den = dsDiaDiem.FindIndex(d => d.Ten == tuyenDuongHienTai[i + 1]);
                tongKhoangCach += maTranKhoangCach[tu, den];
            }
            if (tongKhoangCach < khoangCachToiThieu)
            {
                khoangCachToiThieu = tongKhoangCach;
                tuyenDuongToiUu = new List<string>(tuyenDuongHienTai);
            }
            return;
        }

        for (int i = 0; i < dsDiaDiem.Count; i++)
        {
            if (!tuyenDuongHienTai.Contains(dsDiaDiem[i].Ten))
            {
                tuyenDuongHienTai.Add(dsDiaDiem[i].Ten);
                TimTuyenDuong(dsDiaDiem, maTranKhoangCach, tuyenDuongHienTai, i, ref khoangCachToiThieu, ref tuyenDuongToiUu);
                tuyenDuongHienTai.RemoveAt(tuyenDuongHienTai.Count - 1);
            }
        }
    }
}
