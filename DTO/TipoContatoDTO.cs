using System.ComponentModel.DataAnnotations;

namespace ConnectPlus.DTO
{
    public class TipoContatoDTO
    {
        [Required(ErrorMessage = "O nome é obrigatorio")]
        public string? Nome { get; set; }


        [Required(ErrorMessage = "O sms não é obrigatorio")]
        public string? SMS { get; set; }

        public Guid IdContato { get; set; }
    }
}
