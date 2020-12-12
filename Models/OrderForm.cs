using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

using Debie.Models.DB;

namespace Debie.Models {
    public class OrderForm {
        [MaxLength(256)]
        public string Email { get; set; }
        public bool Updates { get; set; } = false;
        [MaxLength(256)]
        public string FirstName { get; set; }
        [MaxLength(256)]
        public string LastName { get; set; }
        [MaxLength(128)]
        public string ShippingMethod { get; set; }
        public decimal ShippingPrice { get; set; }
        [MaxLength(128)]
        public string PaymentMethod { get; set; }
        [MaxLength(256)]
        public string BillingStreet { get; set; }
        [MaxLength(256)]
        public string BillingApartment { get; set; }
        [MaxLength(256)]
        public string BillingCity { get; set; }
        [MaxLength(256)]
        public string BillingCountry { get; set; }
        [MaxLength(256)]
        public string BillingZip { get; set; }
        [MaxLength(256)]
        public string ShippingStreet { get; set; }
        [MaxLength(256)]
        public string ShippingApartment { get; set; }
        [MaxLength(256)]
        public string ShippingCity { get; set; }
        [MaxLength(256)]
        public string ShippingCountry { get; set; }
        [MaxLength(256)]
        public string ShippingZip { get; set; }
        public decimal VAT { get; set; } = .21M;
        public List<OrderProductForm> OrderProducts { get; set; }

        public decimal Sum { get { return OrderProducts.Select(op => op.UnitPrice * op.Count * (1 - op.Discount) * (1 + VAT) + ShippingPrice).Sum(); } }

        public OrderForm() {
            OrderProducts = new List<OrderProductForm>();
        }
    }
}