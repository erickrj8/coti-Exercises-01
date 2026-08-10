using System;
using System.Collections.Generic;
using System.Text;

namespace FuncionariosApp.Controllers
{
    public class MenuController
    {
        public void Executar()
        {
            Console.WriteLine("\nPROJETO ENTITY FRAMEWORK\n");

            Console.WriteLine("(1) CADASTRAR EMPRESA");
            Console.WriteLine("(2) CONSULTAR EMPRESAS");
            Console.WriteLine("(3) CADASTRAR fUNCIONARIO");

            Console.Write("\nINFORME A OPÇÃO DESEJADA: ");
            var opcao = Console.ReadLine() ?? string.Empty;

            var empresaController = new EmpresaController();
            var funcionarioController = new FuncionarioController();

            switch (opcao)
            {
                case "1":
                    empresaController.CadastrarEmpresa();
                    break;
                case "2":
                    empresaController.ConsultarEmpresas();
                    break;
                case "3":
                    funcionarioController.CadastrarFuncionario();
                    break;
                default:
                    Console.WriteLine("\nOPÇÃO INVÁLIDA!");
                    break;
            }

            Console.WriteLine("Deseja fazer outra Operação? (S,N): ");
            var continuar = Console.ReadLine() ?? string.Empty;

            if (continuar.ToUpper().Equals("S"))
            {
                Console.Clear();
                Executar();
            }
            else
            {
                Console.WriteLine("FIM DO PROGRAMA.");
            }
        }
    }
}
