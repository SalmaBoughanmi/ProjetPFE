namespace ProjetPFE.Dto
{
    public class OffreForUpdateDto
    {
       // public int offre_id { get; set; }
        public int demande_id { get; set; }
        public int nb_poste { get; set; }

        public string? fonction { get; set; }
        public string? description { get; set; }
        public string? mission { get; set; }
    }
}
