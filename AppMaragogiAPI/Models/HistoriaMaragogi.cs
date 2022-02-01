namespace AppMaragogiAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HistoriaMaragogi")]
    public partial class HistoriaMaragogi
    {
        public int HistoriaMaragogiId { get; set; }

        [Required]
        public string UrlVideo { get; set; }

        [Required]
        [StringLength(50)]
        public string Titulo { get; set; }

        [Column(TypeName = "text")]
        public string Descricao { get; set; }

        [Required]
        [StringLength(10)]
        public string Area { get; set; }

        [Required]
        [StringLength(100)]
        public string Populacao { get; set; }

        [Required]
        [StringLength(50)]
        public string Clima { get; set; }

        [Required]
        [StringLength(10)]
        public string DistanciaMaceio { get; set; }

        [Required]
        [StringLength(10)]
        public string DistanciaRecife { get; set; }

        [Required]
        [StringLength(200)]
        public string Acesso { get; set; }

        [Required]
        [StringLength(200)]
        public string Localizacao { get; set; }
        public string Token { get; set; }
    }
}
