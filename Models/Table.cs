﻿using System.ComponentModel.DataAnnotations;

namespace Restaurant_API.Models
{
	public class Table
	{
        [Key]
        public int TableId { get; set; }

        [Required]
        public int TableNumber { get; set; }

        [Required]
        public int Seats { get; set; }

        public ICollection<Reservation>? Reservations { get; set; } = new List<Reservation>();
    }
}
