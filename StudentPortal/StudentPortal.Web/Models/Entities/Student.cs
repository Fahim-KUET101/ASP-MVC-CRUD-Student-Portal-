namespace StudentPortal.Web.Models.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public bool Subscribes { get; set; }
    }
}
