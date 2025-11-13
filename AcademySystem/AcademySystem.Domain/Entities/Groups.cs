using AcademySystem.Domain.Common;


namespace AcademySystem.Domain.Entities
{
    public class Groups : BaseEntity
    {
        public string Name { get; set; }
        public string Teacher { get; set; }
        public int Room { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
