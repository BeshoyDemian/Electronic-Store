using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.DAL.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }

        public string productName { get; set; }
        public int qty { get; set; }
        public float Price { get; set; }
        public int DiscountPercentage { get; set; }


    }
}