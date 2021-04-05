namespace ParkerPlan.Abstractions.Dtos
{
    public class WorkerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string About { get; set; }
        public string Position { get; set; }
        public string Password { get; set; }
        public int[] MyLeadIds { get; set; }
    }
}