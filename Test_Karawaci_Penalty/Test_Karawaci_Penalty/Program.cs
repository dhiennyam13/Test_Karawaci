using System;
using System.Collections.Generic;
using System.Globalization;

public class Tagihan
{
    public string NoTagihan { get; set; }
    public DateTime DueDate { get; set; }
    public decimal TotalTagihan { get; set; }
}

public class Pembayaran
{
    public string NoPayment { get; set; }
    public string NoTagihan { get; set; }
    public DateTime PmtDate { get; set; }
    public decimal PmtAmount { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Inisialisasi data tagihan dan pembayaran
        List<Tagihan> tagihanList = new List<Tagihan>
        {
            new Tagihan { NoTagihan = "Tagihan#1", DueDate = DateTime.ParseExact("10 Jan 23", "dd MMM yy", CultureInfo.InvariantCulture), TotalTagihan = 165000 },
            new Tagihan { NoTagihan = "Tagihan#3", DueDate = DateTime.ParseExact("20 Jan 23", "dd MMM yy", CultureInfo.InvariantCulture), TotalTagihan = 130000 },
            new Tagihan { NoTagihan = "Tagihan#5", DueDate = DateTime.ParseExact("10 Feb 23", "dd MMM yy", CultureInfo.InvariantCulture), TotalTagihan = 95500 },
            new Tagihan { NoTagihan = "Tagihan#2", DueDate = DateTime.ParseExact("15 Feb 23", "dd MMM yy", CultureInfo.InvariantCulture), TotalTagihan = 80000 },
            new Tagihan { NoTagihan = "Tagihan#4", DueDate = DateTime.ParseExact("30 Mar 23", "dd MMM yy", CultureInfo.InvariantCulture), TotalTagihan = 416000 }
        };

        List<Pembayaran> pembayaranList = new List<Pembayaran>
        {
            new Pembayaran { NoPayment = "Payment#1", NoTagihan = "Tagihan#1", PmtDate = DateTime.ParseExact("10 Jan 23", "dd MMM yy", CultureInfo.InvariantCulture), PmtAmount = 165000 },
            new Pembayaran { NoPayment = "Payment#2", NoTagihan = "Tagihan#3", PmtDate = DateTime.ParseExact("20 Feb 23", "dd MMM yy", CultureInfo.InvariantCulture), PmtAmount = 130000 },
            new Pembayaran { NoPayment = "Payment#2", NoTagihan = "Tagihan#5", PmtDate = DateTime.ParseExact("20 Feb 23", "dd MMM yy", CultureInfo.InvariantCulture), PmtAmount = 95500 },
            new Pembayaran { NoPayment = "Payment#3", NoTagihan = "Tagihan#2", PmtDate = DateTime.ParseExact("25 Feb 23", "dd MMM yy", CultureInfo.InvariantCulture), PmtAmount = 30000 },
            new Pembayaran { NoPayment = "Payment#4", NoTagihan = "Tagihan#2", PmtDate = DateTime.ParseExact("30 Mar 23", "dd MMM yy", CultureInfo.InvariantCulture), PmtAmount = 50000 },
            new Pembayaran { NoPayment = "Payment#4", NoTagihan = "Tagihan#4", PmtDate = DateTime.ParseExact("30 Mar 23", "dd MMM yy", CultureInfo.InvariantCulture), PmtAmount = 50000 }
        };

        // Tanggal hari ini
        DateTime today = DateTime.ParseExact("29 Apr 22", "dd MMM yy", CultureInfo.InvariantCulture);

        // Menghitung penalty
        foreach (var tagihan in tagihanList)
        {
            decimal totalTagihanTerlambat = 0;
            int hariKeterlambatan = 0;

            foreach (var pembayaran in pembayaranList)
            {
                if (pembayaran.NoTagihan == tagihan.NoTagihan && pembayaran.PmtDate > tagihan.DueDate)
                {
                    totalTagihanTerlambat += pembayaran.PmtAmount;
                    hariKeterlambatan = (int)(pembayaran.PmtDate - tagihan.DueDate).TotalDays;
                }
            }

            int jumlahPembayaranTerlambat = totalTagihanTerlambat == 0 ? 0 : 1;
            decimal amountPenalty = totalTagihanTerlambat * (decimal)0.002 * hariKeterlambatan;

            Console.WriteLine($"{tagihan.NoTagihan}\t{jumlahPembayaranTerlambat}\t{totalTagihanTerlambat}\t{hariKeterlambatan}\t{amountPenalty}");
        }
    }
}
