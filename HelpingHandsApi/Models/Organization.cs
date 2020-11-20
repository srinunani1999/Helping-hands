using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpingHandsApi.Models
{
    public class Organization
    {
        [Key]
        public int Id { get; set; }

        public string OrganizationName { get; set; }

        public string TotalDonations { get; set; }


    }
}
