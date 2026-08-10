using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FuncionariosApp.Entities
{
    [Table(name: "Empresas")] //Nome da tabela
    [Index(nameof(Cnpj), IsUnique = true)] //Cnpj campo de valor único
    public class Empresa
    {
        #region Propriedades

        [Key] //Chave primária
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required] //Not null (obrigtório)
        [MaxLength(100)] //Máximo 100 caracteres
        public string RazaoSocial { get; set; } = string.Empty;

        [Required] //Not null (obrigatório)
        [StringLength(14)] //Tamanho exato de 14 caracteres
        public string Cnpj { get; set; } = string.Empty;

        #endregion

        #region Relacionamentos

        public List<Funcionario> Funcionarios { get; set; } = [];

        #endregion
    }
}
