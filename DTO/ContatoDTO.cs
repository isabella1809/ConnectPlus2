using System.ComponentModel.DataAnnotations;

namespace ConnectPlus.DTO
{
    public class ContatoDTO
    {

        [Required(ErrorMessage = "O nome é obrigatorio")]
        public string? Nome { get; set; }


        [Required(ErrorMessage = "O numero não é obrigatorio")]
        public string? SMS { get; set; }

        [Required(ErrorMessage = "O numero não é obrigatorio")]
        public string? Email { get; set; }

        public Guid IdTipoContato { get; set; }
        public Guid IdContato { get; set; }
        public object Numero { get; internal set; }
    }
}
