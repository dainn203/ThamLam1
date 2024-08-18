namespace balo
{
    struct DoVat
    {
        public string Ten;
        public int TrongLuong;
        public int GiaTri;
        public int SoLuongChon;
    }

    class Program
        {
            static void TaoBang(DoVat[] dsVat, int soLuong, int W, int[,] F, int[,] X)
            {
                for (int v = 0; v <= W; v++)
                {
                    X[1, v] = v / dsVat[1].TrongLuong;
                    F[1, v] = X[1, v] * dsVat[1].GiaTri;
                }

                for (int i = 2; i <= soLuong; i++)
                {
                    for (int v = 0; v <= W; v++)
                    {
                        int maxGiaTri = F[i - 1, v];
                        int maxSoLuong = 0;
                        int yk = v / dsVat[i].TrongLuong;

                        for (int xk = 1; xk <= yk; xk++)
                        {
                            int giaTri = F[i - 1, v - xk * dsVat[i].TrongLuong] + xk * dsVat[i].GiaTri;
                            if (giaTri > maxGiaTri)
                            {
                                maxGiaTri = giaTri;
                                maxSoLuong = xk;
                            }
                        }

                        F[i, v] = maxGiaTri;
                        X[i, v] = maxSoLuong;
                    }
                }
            }

            static void TraBang(DoVat[] dsVat, int soLuong, int W, int[,] F, int[,] X)
            {
                int v = W;
                for (int i = soLuong; i >= 1; i--)
                {
                    dsVat[i].SoLuongChon = X[i, v];
                    v -= X[i, v] * dsVat[i].TrongLuong;
                }
            }

            static void Main()
            {
                DoVat[] dsVat = new DoVat[]
                {
                new DoVat(),
                new DoVat { Ten = "X", TrongLuong = 15, GiaTri = 250 },
                new DoVat { Ten = "Y", TrongLuong = 25, GiaTri = 150 },
                new DoVat { Ten = "Z", TrongLuong = 10, GiaTri = 100 },
                new DoVat { Ten = "W", TrongLuong = 20, GiaTri = 200 },
                new DoVat { Ten = "V", TrongLuong = 30, GiaTri = 300 }
                };

                int soLuong = 5; // Số lượng đồ vật
                int W = 60; // Trọng lượng tối đa của balo
                 int tongGiaTri = 0;
            int[,] F = new int[soLuong + 1, W + 1];
                int[,] X = new int[soLuong + 1, W + 1];

                TaoBang(dsVat, soLuong, W, F, X);
                TraBang(dsVat, soLuong, W, F, X);

                Console.WriteLine("Phuong an chon do vat:");
                for (int i = 1; i <= soLuong; i++)
                {
                    Console.WriteLine($"{dsVat[i].Ten}: {dsVat[i].SoLuongChon}");
                 tongGiaTri += dsVat[i].SoLuongChon * dsVat[i].GiaTri;
                 }
            Console.WriteLine($"Tong gia tri cua balo: {tongGiaTri}");
        }
    }
        }
    

