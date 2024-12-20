﻿using System.ComponentModel.DataAnnotations;
using TestGen.ApplicationCore.Enumerated.DSM;

namespace WebApplication1.Models
{
    public class MatchViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Escribe el estado del match", Description = "Estado del match", Name = "Estado")]
        [Required]
        public EstadoMatchEnum Estado { get; set; }

        [Display(Prompt = "Escribe la ubicación del match", Description = "Ubicación del match", Name = "Ubicación")]
        public string? Ubicacion { get; set; }

        [ScaffoldColumn(false)]
        public string MascotaRecibeNombre { get; set; }

        [ScaffoldColumn(false)]
        public string MascotaEnviaNombre { get; set; }
    }
}