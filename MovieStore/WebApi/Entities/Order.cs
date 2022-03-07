using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public DateTime BuyingDate { get; set; }
        public int Price { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Movie Movie { get; set; }
        public bool IsPassive { get; set; } = false;
    }
}