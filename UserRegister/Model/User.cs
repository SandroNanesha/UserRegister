using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace UserRegister.Model
{
    [Table(name: "Profile")]
    public class User : IdentityUser
    {
        public string address { get; set; } = "";
        [Column(TypeName = "varchar(500)")]

        public string monthlyIncome { get; set; } = "";
        [Column(TypeName = "varchar(500)")]

        public bool hasFamily { get; set; } = false;
        [Column(TypeName = "bit")]

        public bool hasJob { get; set; } = false;
        //[Column(TypeName = "bit")]
    }
}
