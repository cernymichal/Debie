using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Debie.Models.DB;

namespace Debie.Models {
    public class ProductForm {
        [Key]
        public int ID { get; set; }
        [MaxLength(256), Required]
        public string Name { get; set; }
        [MaxLength(4096)]
        public string Description { get; set; }
        [MaxLength(64)]
        public string Color { get; set; }
        public string Price { get; set; }
        public string Discount { get; set; }
        [Display(Name = "Discount from")]
        public DateTime DiscountFrom { get; set; }
        [Display(Name = "Discount until")]
        public DateTime DiscountUntil { get; set; }
        [Display(Name = "Vendor")]
        public int VendorID { get; set; }
        public ICollection<ImageForm> Images { get; set; }
        [Display(Name = "Main")]
        public int MainImageID { get; set; }


        public static ProductForm FromModel(Product model) {
            return new ProductForm {
                ID = model.ID,
                Name = model.Name,
                Description = model.Description,
                Color = model.Color,
                Price = model.Price.ToString(),
                Discount = model.Discount.ToString(),
                DiscountFrom = model.DiscountFrom,
                DiscountUntil = model.DiscountUntil,
                VendorID = model.VendorID,
                Images = model.ProductImages.Select(i => ImageForm.FromModel(i.Image)).ToList(),
                MainImageID = model.MainImage.ID
            };
        }

        public Product ToModel(Product model) {
            model.Name = Name;
            model.Description = Description;
            model.Color = Color;
            model.Price = decimal.Parse(Price);
            model.Discount = decimal.Parse(Discount);
            model.DiscountFrom = DiscountFrom;
            model.DiscountUntil = DiscountUntil;
            model.VendorID = VendorID;
            model.MainImage = model.ProductImages.First(pi => pi.ImageID == MainImageID).Image;
            return model;
        }
    }
}