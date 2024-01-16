using System.ComponentModel.DataAnnotations;

namespace BulkyWebRazorCore.Model
{
   
        public class Category
        {
            [Key]
            public int Id { get; set; }
            [Required(ErrorMessage = "Please Enter the name")]
            [MaxLength(30)]
            public string Name { get; set; }
            [Range(1, 30)]
            public int DisplayOrder { get; set; }

        }
  
}
