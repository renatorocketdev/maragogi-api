namespace AppMaragogiAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FotoComentario")]
    public partial class FotoComentario
    {
        public int FotoComentarioId { get; set; }

        [Column(TypeName = "text")]
        public string Comentario { get; set; }

        [StringLength(64)]
        public string DataComentario { get; set; }

        [StringLength(100)]
        public string Empresa { get; set; }

        public byte[] Foto { get; set; }

        [StringLength(64)]
        public string Usuario { get; set; }

        [StringLength(64)]
        public string Email { get; set; }
    }
}
