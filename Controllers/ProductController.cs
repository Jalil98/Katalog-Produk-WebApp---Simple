using KatalogProduk.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Xml.Linq;

namespace KatalogProduk.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> Products = new List<Product>
        {
            new Product { Id = 1, 
                Name = "Coding", 
                Category = "Coding", 
                Description = "Belajar coding menyenangkan", 
                Price = 50000, 
                ImageUrl = "/images/coding.png",
                SubProducts = new List<Product>
                {
                    new Product
                    {
                        Id =11,
                        Name = "Coding For Kids",
                        Description = "Coding dengan menggunakan blockly code",
                        Price = 70000,
                        ImageUrl = "/images/coding.png"
                    },
                    new Product
                    {
                        Id =11,
                        Name = "Coding For Junior",
                        Description = "Coding dengan menggunakan blockly code tingkat menengah",
                        Price = 85000,
                        ImageUrl = "/images/coding.png"
                    },
                    new Product
                    {
                        Id =11,
                        Name = "Coding For Kids",
                        Description = "Coding dengan menggunakan sintaksis",
                        Price = 100000,
                        ImageUrl = "/images/coding.png"
                    },

                }
            },
            new Product
            {
                Id = 2,
                Name = "Math Coding",
                Category = "Math",
                Description = "Paket lengkap pembelajaran matematika dengan coding",
                Price = 0,
                ImageUrl = "/images/math.png",
                SubProducts = new List<Product>
                {
                    new Product {
                        Id = 21,
                        Name = "Math Basic",
                        Description = "Basik-basik matematika",
                        Price = 40000,
                        ImageUrl = "/images/mathkinder.png"
                    },
                    new Product {
                        Id = 22,
                        Name = "Math Intermediate",
                        Description = "Pembahasan materi tingkat menengah",
                        Price = 60000,
                        ImageUrl = "/images/math junior.png"
                    },
                    new Product {
                        Id = 23,
                        Name = "Math Advanced",
                        Description = "Materi math lanjutan",
                        Price = 80000,
                        ImageUrl = "/images/math advanced.png"
                    }
                }
            },
            new Product { Id = 3,
                Name = "Python",
                Category = "Python",
                Description = "Belajar Python dari awal", 
                Price = 75000, 
                ImageUrl = "/images/python.png",
                SubProducts = new List<Product>
                {
                    new Product
                    {
                        Id =31,
                        Name = "Python Fundamental",
                        Description = "Coding dengan Python yang mudah",
                        Price = 100000,
                        ImageUrl = "/images/python.png"
                    },
                    new Product
                    {
                        Id =32,
                        Name = "Python Intermediate",
                        Description = "Coding dengan Python tingkat menengah",
                        Price = 150000,
                        ImageUrl = "/images/python.png"
                    },
                    new Product
                    {
                        Id =33,
                        Name = "Python Hard",
                        Description = "Coding dengan Python level lanjutan",
                        Price = 200000,
                        ImageUrl = "/images/python.png"
                    },
                }
            },
            new Product { 
                Id = 4, 
                Name = "Latihan Logika", 
                Category = "Logika", 
                Description = "Tantangan logika menyenangkan", 
                Price = 55000, 
                ImageUrl = "/images/logic.png",
                SubProducts = new List<Product>
                {
                    new Product
                    {
                        Id =41,
                        Name = "Logika Dasar",
                        Description = "Berlatih mengasah logika anak dengan aritmetika",
                        Price = 70000,
                        ImageUrl = "/images/logic.png"
                    },
                    new Product
                    {
                        Id =42,
                        Name = "Logika Menengah",
                        Description = "Berlatih mengasah logika anak dengan aritmetika tingkat menengah",
                        Price = 70000,
                        ImageUrl = "/images/logic.png"
                    },
                    new Product
                    {
                        Id =43,
                        Name = "Logika Lanjutan",
                        Description = "Berlatih mengasah logika anak dengan aritmetika tingkat lanjut",
                        Price = 70000,
                        ImageUrl = "/images/logic.png"
                    },
                }
            }
        };

        public IActionResult List(string category)
        {
            var filtered = string.IsNullOrEmpty(category) ? Products : Products.FindAll(p => p.Category == category);
            return View(filtered);
        }

        public IActionResult Detail(int id)
        {
            var product = Products.Find(p => p.Id == id);
            return View(product);
        }
    }
}
