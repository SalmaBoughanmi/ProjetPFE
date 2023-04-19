namespace ProjetPFE.Entities
{
    public class experience
    {
        public int experience_id { get; set; }
        public string? poste { get; set; }
        public string? entreprise { get; set; }
        public string? date_debut { get; set; }
        public string? date_fin { get; set; }
        public int? employe_id { get; set; }
    }
}
