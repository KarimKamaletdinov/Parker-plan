using ParkerPlan.Abstractions.Enums;

namespace ParkerPlan.Models
{
    public class Good
    {
        public int ParkerId { get; set; }
        public string Name { get; set; }
        public string Collection { get; set; }
        public bool AbleForMan { get; set; }
        public bool AbleForWoman { get; set; }
        public bool GoldDetails { get; set; }
        public bool GoldPen { get; set; }
        public WritingNodeType WritingNodeType { get; set; }
        public int Price { get; set; }
        public bool AbleToEngraving { get; set; }
        public string Description { get; set; }
        public int InSpb { get; set; }
        public int InMsk { get; set; }
        public int InUfa { get; set; }
        public int InEkt { get; set; }
        public int SelfPrice { get; set; }
    }
}