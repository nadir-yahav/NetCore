namespace SpringItUp
{
    public class Lid : IValid
    {
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerMsg { get; set; }

        public bool IsValid()
        {
            return OwnerId > 0
            && !string.IsNullOrEmpty(CustomerName)
            && !string.IsNullOrEmpty(CustomerPhone);
        }
    }
}