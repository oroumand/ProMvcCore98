using Microsoft.AspNetCore.Mvc;
using Session14.Validations.Infrastructures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Session14.Validations.Models
{
    public class Appointment
    {
        [Remote("ValidateUserName","Home")]
        public string UserName { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string ClientName { get; set; }
        [UIHint("Date")]
        public DateTime Date { get; set; }
        [MustBeTrue(ErrorMessage = "asdfsadfsdf",IsRequired =true)]
        public bool TermsAccepted { get; set; }
    }
}
