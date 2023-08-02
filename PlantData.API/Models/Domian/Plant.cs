namespace PlantData.API.Models.Domian
{
    public class Plant
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String? PlantImageUrl { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid FamilyId { get; set; }

        // Navigation Properties
        public Difficulty Difficulty { get; set; }
        public Family Family { get; set; }
    }
}
