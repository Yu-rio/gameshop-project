using ClassLibraryGameShop;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace gameshop_project.Server.Models
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class CustomerModel
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string patronymicName { get; set; }
        public string email { get; set; }
        public DateTime birthday { get; set; }

        public string address { get; set; }
        public string passwordHash { get; set; }
    }

    public class ProductModel
    {
        public string productId { get; set; }
        public string title { get; set; }
        public string trailerLink { get; set; }
        public int quantity { get; set; }
        public float price { get; set; }
        public string content { get; set; }
        public string categoryId { get; set; }
        public string publisherId { get; set; }
        public string genreId { get; set; }
        public string platformId { get; set; }
    }

    public class CartModel
    {
        public string id { get; set; }
        public string createdAt { get; set; }
        public string customerId { get; set; }

    }

    public class CartItemModel
    {
        public float price { get; set; }
        public int quantity { get; set; }
        public string productId { get; set; }
        public string cartId { get; set; }
    }

    public class OrderModel
    {
        public string orderId { get; set; }

         public DateTime orderDate { get; set; }

         public float sum { get; set; }

        public string status { get; set; }

        public string deliveryId { get; set; }

        public string customerId { get; set; }

        public string transactionId { get; set; }

    }
    public class OrderItemModel
    {
         public float? price { get; set; }

         public int? quantity { get; set; }

         public string productId { get; set; }

        public string orderId { get; set; }
    }
}
