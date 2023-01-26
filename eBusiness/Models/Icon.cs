namespace eBusiness.Models
{
    public class Icon
    {
        public int Id { get; set; }
        public string? IconName { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
