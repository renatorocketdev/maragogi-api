namespace AppMaragogiAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comentario")]
    public partial class Comentario
    {
        public int ComentarioId { get; set; }

        [Required]
        [StringLength(100)]
        public string NomeUsuario { get; set; }

        [Required]
        public string TextoComentario { get; set; }

        [Required]
        [StringLength(100)]
        public string Empresa { get; set; }

        [Required]
        [StringLength(100)]
        public string Categoria { get; set; }

        public decimal? Nota { get; set; }
    }
}
