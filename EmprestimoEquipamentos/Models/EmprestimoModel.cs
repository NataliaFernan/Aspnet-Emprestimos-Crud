using System.ComponentModel.DataAnnotations;

namespace EmprestimoEquipamentos.Models
{
    public class EmprestimoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Digite o nome do recebedor!")]
        public string Recebedor { get; set; }

        [Required(ErrorMessage ="Digite o nome do fornecedor!")]
        public string Fornecedor { get; set; }

        [Required(ErrorMessage ="Digite o equipamento que foi emprestado!")]
        public string Equipamento { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; } = DateTime.Now;
   
    }
}
