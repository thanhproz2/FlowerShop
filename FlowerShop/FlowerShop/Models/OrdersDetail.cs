namespace FlowerShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrdersDetail")]
    public partial class OrdersDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ordersId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int productId { get; set; }

        [Column(TypeName = "money")]
        public decimal? price { get; set; }

        public int? quantity { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
