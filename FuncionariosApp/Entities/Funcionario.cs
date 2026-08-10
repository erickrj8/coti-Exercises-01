using FuncionariosApp.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FuncionariosApp.Entities
{
    [Table(name: "Funcionarios")] //Nome da tabela
    [Index(nameof(Cpf), IsUnique = true)] //Cpf como campo de valor unico
    public class Funcionario
    {
        #region Propriedades

        [Key] //Chave primária
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required] //Not null (obrigatório)
        [MaxLength(150)] //Máximo 150 caracteres
        public string Nome { get; set; } = string.Empty;

        [Required] //Not null (obrigatório)
        [StringLength(11)] //Exatamente 11 caracteres
        public string Cpf { get; set; } = string.Empty;

        [Required] //Not null (obrigatório)
        public DateOnly DataAdmissao { get; set; }

        [Required] //Not null (obrigatório)
        [MaxLength(50)] //Máximo 50 caracteres
        public string Cargo { get; set; } = string.Empty;

        [Required] //Not null (obrigatório)
        [Precision(10, 2)] //10 dígitos / 2 casas decimais
        public decimal Salario { get; set; }

        [Required] //Not null (obrigatório)
        public TipoContratacao Tipo { get; set; }

        [Required] //Not null (obrigatório)
        public Guid EmpresaId { get; set; }

        #endregion

        #region Relacionamentos

        [ForeignKey(nameof(EmpresaId))] //Chave estrangeira do relacionamento
        public Empresa? Empresa { get; set; } = null;

        #endregion
    }
}

