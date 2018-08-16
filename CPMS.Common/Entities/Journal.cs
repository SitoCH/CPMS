namespace CPMS.Common.Entities
{
    public class Journal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int InterventionId { get; set; }
        public virtual Intervention Intervention { get; set; }
    }
}
