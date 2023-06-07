using System.ComponentModel.DataAnnotations.Schema;

namespace VBInterfacing.Models
{
    [Table("tblUsers")]
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}