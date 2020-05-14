using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace CoffeeMachine.Data.Models
{
    [Table("Order")]
    public class Order
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Badge ID used to buy drink
        /// </summary>
        public int BadgeId { get; set; }

        /// <summary>
        /// Drink ID attached to Order
        /// </summary>
        public int DrinkId { get; set; }
        
        /// <summary>
        /// True if Mug choosen at start
        /// </summary>
        public bool WithMug { get; set; }

        /// <summary>
        /// Selected amount of sugar in drink
        /// </summary>
        [Range(0, 4)]
        public int SugarAmount { get; set; }

        /// <summary>
        /// Order Time
        /// </summary>
        /// 
        public DateTime OrderTime { get; set; }


    }
}
