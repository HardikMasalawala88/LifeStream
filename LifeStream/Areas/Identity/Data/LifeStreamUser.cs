using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LifeStream.Models;
using Microsoft.AspNetCore.Identity;

namespace LifeStream.Areas.Identity.Data
{



    public enum UserRole
    {
        Admin,
        Doctor,
        Patient,
        Receptionist
    }

    // Add profile data for application users by adding properties to the LifeStreamUser class
    public class LifeStreamUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        public UserRole Role { get; set; }

        public Doctor? Doctors { get; set; }
        public Patient? Patients { get; set; }
        public Receptionist? Receptionist { get; set; }
       
    }
}

