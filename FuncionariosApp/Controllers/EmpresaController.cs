using FuncionariosApp.Contexts;
using FuncionariosApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuncionariosApp.Controllers
{
    public class EmpresaController
    {
        public void CadastrarEmpresa()
        {
        
            Console.WriteLine("\nCADASTRO DE EMPRESA:\n");

            var empresa = new Empresa();

            Console.Write("INFORME A RAZÃO SOCIAL....: ");
            empresa.RazaoSocial = Console.ReadLine() ?? string.Empty;

            Console.Write("INFORME O CNPJ............: ");
            empresa.Cnpj = Console.ReadLine() ?? string.Empty;

            var dataContext = new DataContext();

            //Verificar se já existe alguma empresa com o CNPJ cadastrado
            if (dataContext.Empresas.Count(e => e.Cnpj.Equals(empresa.Cnpj)) > 0)
            {
                Console.WriteLine("\nERRO: ESTE CNPJ JÁ FOI CADASTRADO. TENTE OUTRO.");
                return; //Encerrar o método 'CadastrarEmpresa()'
            }

            //Salvar a empresa na tabela do banco de dados
            dataContext.Empresas.Add(empresa);
            dataContext.SaveChanges();

            Console.WriteLine("\nEMPRESA CADASTRADA COM SUCESSO!");
        }

        public void ConsultarEmpresas()
        {
            Console.WriteLine("\nCONSULTA DE EMPRESAS:\n");

            var dataContext = new DataContext();

            //Consultando todas as empresas em ordem alfabetica
            var empresas = dataContext.Empresas.OrderBy(e => e.RazaoSocial).ToList();

            //Exibindo as empresas:
            foreach (var item in empresas)
            {
                Console.WriteLine($"ID...........: {item.Id}");
                Console.WriteLine($"RAZAO SOCIAL.: {item.RazaoSocial}");
                Console.WriteLine($"CNPJ.........: {item.Cnpj}");
                Console.WriteLine("...");
            }
        }
    }
}