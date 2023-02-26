using System.ComponentModel.DataAnnotations;

namespace AngularEcommerce.Entity
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
