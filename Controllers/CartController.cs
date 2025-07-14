// File: Controllers/CartController.cs
using KatalogProduk.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using KatalogProduk.Extensions;
using System.Collections.Generic;
using System;

namespace KatalogProduk.Controllers
{
    public class CartController : Controller
    {
        public static List<CartItem> Cart = new List<CartItem>();

        // Tambahkan ke keranjang (via POST)
        [HttpPost]
        public IActionResult Add(int productId)
        {
            var product = ProductController.Products.Find(p => p.Id == productId);
            if (product == null)
                return NotFound();

            var item = Cart.Find(i => i.Product.Id == productId);
            if (item != null)
                item.Quantity++;
            else
                Cart.Add(new CartItem { Product = product, Quantity = 1 });

            return RedirectToAction("Index");
        }

        // Tampilkan form checkout
        [HttpPost]
        public IActionResult Checkout(int productId)
        {
            var product = ProductController.Products.Find(p => p.Id == productId);
            if (product == null)
                return NotFound();

            var order = new OrderViewModel
            {
                ProductId = product.Id,
                ProductName = product.Name,
                OrderDate = DateTime.Now,
                Quantity = 1,
                TotalPrice = product.Price,
                ShippingLocation = "" // ✅ BUKAN DeliveryLocation
            };


            return View("Checkout", order);
        }

        // Konfirmasi order (dari form)
        [HttpPost]
        public IActionResult ConfirmOrder(OrderViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Checkout", model);

            var user = HttpContext.Session.GetObject<User>("User");
            if (user != null)
            {
                if (user.OrderHistory == null)
                    user.OrderHistory = new List<CartItem>();

                var product = ProductController.Products.Find(p => p.Id == model.ProductId);
                if (product != null)
                {
                    user.OrderHistory.Add(new CartItem
                    {
                        Product = product,
                        Quantity = model.Quantity
                    });
                    HttpContext.Session.SetObject("User", user);
                }
            }

            Cart.Clear();
            return View("CheckoutSuccess", model);
        }

        // Lihat isi keranjang
        public IActionResult Index()
        {
            return View(Cart);
        }
    }
}
