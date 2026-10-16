using BusinessEntities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Users
{
    public class UserModel
    {
        [Required]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public UserTypes Type { get; set; }
        [Required, Range(0, int.MaxValue)]
        public int? Age { get; set; }
        [Required, Range(0, double.MaxValue)]
        public decimal? AnnualSalary { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}