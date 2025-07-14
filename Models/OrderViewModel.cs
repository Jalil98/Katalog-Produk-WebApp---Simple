// File: Models/OrderViewModel.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace KatalogProduk.Models
{
    public class OrderViewModel
    {
        public int ProductId { get; set; }

        [Display(Name = "Nama Produk")]
        public string ProductName { get; set; }

        [Display(Name = "Tanggal Pesanan")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Jumlah Produk")]
        [Range(1, int.MaxValue, ErrorMessage = "Jumlah harus minimal 1")]
        public int Quantity { get; set; }

        [Display(Name = "Lokasi Pengiriman")]
        [Required(ErrorMessage = "Lokasi wajib diisi")]
        public string ShippingLocation { get; set; }

        [Display(Name = "Total Harga")]
        public decimal TotalPrice { get; set; }
    }
}
