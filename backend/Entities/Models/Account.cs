using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities.Models;

[Table("account")]
    public class Account
    {
        public Guid AccountId { get; set; }

        [Required]
        public DateTime DataCreated { get; set; }

        [Required]
        public string? AccountType { get; set; }

        [ForeignKey(nameof(Owner))]
        public Guid OwnerId { get; set; }
        public Owner? Owner { get; set; }
    }