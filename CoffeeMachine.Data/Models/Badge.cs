using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoffeeMachine.Data.Models
{
    [Table("Badge")]
    public class Badge
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Last Name of badge's owner
        /// </summary>
        [Required]
        public string OwnerLastName { get; set; }

        /// <summary>
        /// First name of badge's owner
        /// </summary>
        [Required]
        public string OwnerFirstName { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
