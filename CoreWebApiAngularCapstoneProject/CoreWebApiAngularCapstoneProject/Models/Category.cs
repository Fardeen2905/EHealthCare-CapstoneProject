using System.ComponentModel.DataAnnotations;

namespace CoreWebApiAngularCapstoneProject.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public ICollection<Medicine>? Medicines { get; set; }
    }
}
