namespace AppMaragogiAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Empresa")]
    public partial class Empresa
    {
        [Key]
        public int IdEmpresa { get; set; }

        [Required]
        [StringLength(50)]
        public string NomeEmpresa { get; set; }

        [Required]
        [StringLength(200)]
        public string Endereco { get; set; }

        [Required]
        [StringLength(50)]
        public string Telefone1Empresa { get; set; }

        [StringLength(50)]
        public string Telefone2Empresa { get; set; }

        [StringLength(50)]
        public string Facebook { get; set; }

        [StringLength(50)]
        public string Instagram { get; set; }

        [StringLength(50)]
        public string Site { get; set; }

        [Required]
        [StringLength(1000)]
        public string SobreEmpresa { get; set; }

        [Required]
        [StringLength(50)]
        public string Carac1 { get; set; }

        [StringLength(50)]
        public string Carac2 { get; set; }

        [StringLength(50)]
        public string Carac3 { get; set; }

        [StringLength(50)]
        public string Carac4 { get; set; }

        [Required]
        [StringLength(50)]
        public string Serv1 { get; set; }

        [StringLength(50)]
        public string Serv2 { get; set; }

        [StringLength(50)]
        public string Serv3 { get; set; }

        [StringLength(50)]
        public string Serv4 { get; set; }

        public decimal Nota { get; set; }

        [Required]
        [StringLength(30)]
        public string MainCategoria { get; set; }

        [Required]
        [StringLength(30)]
        public string SubCategoria { get; set; }

        public byte[] Icone { get; set; }

        public int QtdVotos { get; set; }
        public string Video { get; set; }


        public string OldName { get; set; }
        public string OldSubCategoria { get; set; }
        public string Token { get; set; }
    }
}
