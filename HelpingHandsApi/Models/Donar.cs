using System;
using System.ComponentModel.DataAnnotations;

namespace HelpingHandsApi.Models
{
    public class Donar
    {
        [Key]
        public int DonorId { get; set; }
        public string  DonorName { get; set; }

        public DateTime DateOfDonation { get; set; }
        public double  Amount { get; set; }

        public int Id { get; set; }
        public Organization Organization { get; set; }

    }
}
