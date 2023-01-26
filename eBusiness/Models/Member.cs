using System.ComponentModel.DataAnnotations.Schema;

namespace eBusiness.Models
{
    public class Member
    {
        public Member()
        {
            Icons = new List<Icon>();
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? FormFile { get; set; }
        public List<Icon> Icons { get; set; }
    }
}
