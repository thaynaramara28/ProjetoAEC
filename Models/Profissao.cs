using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjetoAEC.Models
{
    [Table("profissoes")]
    public class Profissao
    {
        [Key]
        [Column("id")]
        public int Id {get; set;}

        [Column("descricao", TypeName ="varchar")]
        [MaxLength(45)]
        [Required]

        public string Descricao{get; set;}
        
        [JsonIgnore]
        public ICollection <Candidato> candidatos {get; set;} 
        
    }
}