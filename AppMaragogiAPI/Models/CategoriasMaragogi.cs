namespace AppMaragogiAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CategoriasMaragogi")]
    public partial class CategoriasMaragogi
    {
        [Key]
        public int CategoriaMaragogiId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public byte[] Icone { get; set; }

        [StringLength(255)]
        public string UrlVideo { get; set; }

        [Column(TypeName = "text")]
        public string Descricao { get; set; }

        [StringLength(255)]
        public string Localizacao { get; set; }

        public byte[] IconeCategoria { get; set; }

        public string Categoria { get; set; }

        public string OldName { get; set; }
        public string Token { get; set; }
    }
}