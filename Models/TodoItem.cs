﻿namespace KatalogProduk.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public int UserId {  get; set; }
        public string Task { get; set; }
        public bool IsCompleted { get; set; }
    }
}
