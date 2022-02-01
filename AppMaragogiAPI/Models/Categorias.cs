namespace AppMaragogiAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Categorias
    {
        [Key]
        public int CategoriaId { get; set; }

        [Required]
        [StringLength(100)]
        public string MainCategoria { get; set; }

        [Required]
        [StringLength(100)]
        public string SubCategoria { get; set; }

        [Column(TypeName = "image")]
        public byte[] Icone { get; set; }

        public string OldName { get; set; }
        public string Token { get; set; }
    }
}
