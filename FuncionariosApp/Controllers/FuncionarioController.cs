using FuncionariosApp.Contexts;
using FuncionariosApp.Entities;
using FuncionariosApp.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using static System.Globalization.CultureInfo;

namespace FuncionariosApp.Controllers
{
    public class FuncionarioController
    {
        public void CadastrarFuncionario()
        {
            try
            {
                var dataContext = new DataContext();
                //valid~ção para verificar se existe empresa cadastrads
                var empresas = dataContext.Empresas.OrderBy(e => e.RazaoSocial).ToList();
                if (!empresas.Any())
                {
                    Console.WriteLine("\nERRO: NÃO HÁ EMPRESAS CADASTRADAS. CADASTRE UMA EMPRESA PRIMEIRO.");
                    return;
                }

                Console.WriteLine("\nCADASTRO DE FUNCIONARIO:\n");
                var funcionario = new Funcionario();

                Console.Write("INFORME o Nome do funcionário....: ");
                funcionario.Nome = Console.ReadLine() ?? string.Empty;

                Console.Write("INFORME o Cpf do funcionário....: ");
                string cpfDigitado = Console.ReadLine() ?? string.Empty;

                funcionario.Cpf = new string(cpfDigitado.Where(char.IsDigit).ToArray());

                if (funcionario.Cpf.Length != 11)
                {
                    Console.WriteLine("ERRO: O CPF deve ter exatamente 11 dígitos numéricos.");
                    return;
                }

                Console.Write("INFORME a DataAdmissao do funcionário (dd/mm/aaaa)....: ");
                string dataAdmissão = Console.ReadLine() ?? string.Empty;

                //TODO - Verificar para aprendizado
                funcionario.DataAdmissao = DateOnly.ParseExact(dataAdmissão, "dd/MM/yyyy",InvariantCulture);

                Console.Write("INFORME o Cargo do funcionário....: ");
                funcionario.Cargo = Console.ReadLine() ?? string.Empty;

                Console.Write("INFORME o Salario do funcionário....: ");
                string salarioFuncionario = Console.ReadLine() ?? "0";

                funcionario.Salario = decimal.Parse(salarioFuncionario,InvariantCulture);

                foreach (var item in Enum.GetValues(typeof(TipoContratacao)))
                {
                    Console.WriteLine($"\t{(int)item} - {item}");
                }

                Console.Write("Informe o  tipo de contratação do funcionário....: ");
                funcionario.Tipo = (TipoContratacao) int.Parse(Console.ReadLine() ?? string.Empty);

                // 2. RELACIONAMENTO: Selecionar a Empresa
                Console.WriteLine("\nSELECIONE A EMPRESA DO FUNCIONÁRIO:");
                for (int i = 0; i < empresas.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {empresas[i].RazaoSocial} (CNPJ: {empresas[i].Cnpj})");
                }

                Console.Write("ESCOLHA A OPÇÃO........: ");
                int escolha;
                do
                {
                    Console.Write($"ESCOLHA UMA OPÇÃO (1 a {empresas.Count}): ");
                } while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > empresas.Count);

                //// COmo Associamos o ID da empresa selecionada ao EmpresaId do funcionário?
                funcionario.EmpresaId = empresas[escolha - 1].Id;

                dataContext.Funcionarios.Add(funcionario);
                dataContext.SaveChanges();

                Console.WriteLine("Funcionario CADASTRADo COM SUCESSO!");

            }
            catch (Exception ex)
            {
                throw new Exception($"Falha Ao cadastrar o funcionario {ex.Message } ");
 
            }
        }
    }
}
