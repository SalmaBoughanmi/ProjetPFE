﻿using ProjetPFE.Entities;

namespace ProjetPFE.Dto
{
    public class EmployeForCreationDto
    {
        public string? nom { get; set; }
        public string? prenom { get; set; }
        public string? matricule { get; set; }
        public string? matricule_resp { get; set; }
        public string? fonction { get; set; }
        public string? role { get; set; }
        public string? date_recrutement { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? compte_winds { get; set; }
        public ICollection<diplome>? diplomes { get; set; }
        public ICollection<experience>? experiences { get; set; }
        public ICollection<certification>? certifications { get; set; }
        public ICollection<technologie>? technologies { get; set; }
    }
}
