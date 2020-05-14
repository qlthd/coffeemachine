using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoffeeMachine.Data.Models
{
    [Table("Drink")]
    public class Drink
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

       
    }
}
