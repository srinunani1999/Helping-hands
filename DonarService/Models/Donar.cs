using HelpingHandsApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DonarService.Models
{
    public class Donar
    {
        [Key]
        public int DonorId { get; set; }
        public string DonorName { get; set; }

        public DateTime DateOfDonation { get; set; }
        public double Amount { get; set; }

        public int organization_Id { get; set; }

    }
}
