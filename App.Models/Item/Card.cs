using Core.Domain.Models.Audit;
using System.ComponentModel.DataAnnotations;

namespace App.Models.Item
{
    public class Card : Audit
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
    }
}
