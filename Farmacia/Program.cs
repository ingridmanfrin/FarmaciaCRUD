using Farmacia.Controller;
using Farmacia.Model;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Farmacia;
    internal class Program
{
    private static ConsoleKeyInfo consoleKeyInfo;
    static void Main(string[] args)
    {
        int opcao = -1, tipo, id;
        string? nome, fragancia, generico; 
        decimal preco;
        string nomeFarmacia = "Saúde";

        ProdutoController produtoController = new ProdutoController();    

        while (opcao != 6)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("*****************************************************");
            Console.WriteLine("                                                     ");
            Console.WriteLine($"                DROGRARIA {nomeFarmacia.ToUpper()}                      ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("*****************************************************");
            Console.WriteLine("                                                     ");
            Console.WriteLine("            1 - Criar Produto                          ");
            Console.WriteLine("            2 - Listar todos os Produtos               ");
            Console.WriteLine("            3 - Consultar Produto                     ");
            Console.WriteLine("            4 - Atualizar Produto                     ");
            Console.WriteLine("            5 - Deletar Produto                       ");
            Console.WriteLine("            6 - Sair                                 ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("*****************************************************");
            Console.WriteLine("Entre com a opção desejada:                          ");
            Console.WriteLine("                                                     ");
            Console.ResetColor();

            //tratamento de Exceção para impedir a digitação de strings:
            try
            {
                opcao = Convert.ToInt32(Console.ReadLine());

            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Digite um valor interio entre 1 e 6");
                opcao = 0;
                Console.ResetColor();
            }

            switch (opcao)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Criar Produto\n\n");
                    Console.ResetColor();
                    
                    do
                    {
                        Console.WriteLine("Digite o Tipo do Produto: ");
                        tipo = Convert.ToInt32(Console.ReadLine());

                    } while (tipo != 1 && tipo != 2);

                    Console.WriteLine("Digite o Nome do Produto: ");
                    nome = Console.ReadLine();

                    nome ??= string.Empty;

                    Console.WriteLine("Digite o Preço do Produto: ");
                    preco = Convert.ToDecimal(Console.ReadLine());

                    switch (tipo)
                    {
                        case 1:
                            Console.WriteLine("Digite a Fragância do Produto: ");
                            fragancia = Console.ReadLine();

                            produtoController.CriarProduto(new Cosmetico(produtoController.GerarId(), tipo, nome, preco, fragancia));
                            break;
                        case 2:
                            Console.WriteLine("Digite o Nome Genérico do Produto: ");
                            generico = Console.ReadLine();

                            produtoController.CriarProduto(new Medicamento(produtoController.GerarId(), tipo, nome, preco, generico));

                            break;
                    }

                    KeyPress();
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Listar Produtos\n\n");
                    Console.ResetColor();

                    produtoController.ListarProdutos();

                    KeyPress();
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Consultar Produto - por Id\n\n");
                    Console.ResetColor();

                    Console.WriteLine("Digite o Id da conta: ");
                    id = Convert.ToInt32(Console.ReadLine());

                    produtoController.ConsultarProdutoPorId(id);

                    KeyPress();
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Atualizar Produto\n\n");
                    Console.ResetColor();

                    Console.WriteLine("Digite o Id do Produto: ");
                    id = Convert.ToInt32(Console.ReadLine());

                    var produto = produtoController.BuscarNaCollection(id);

                    if (produto != null)
                    {
                        Console.WriteLine("Digite o Nome do Produto: ");
                        nome = Console.ReadLine();
                        
                        nome ??= string.Empty;

                        Console.WriteLine("Digite o Preço do Produto: ");
                        preco = Convert.ToDecimal(Console.ReadLine());

                        tipo = produto.GetTipo();

                        switch (tipo)
                        {
                            case 1:
                                Console.WriteLine("Digite a Fragância do Produto: ");
                                fragancia = Console.ReadLine();

                                produtoController.AtualizarProduto(new Cosmetico(id, tipo, nome, preco, fragancia));
                                break;
                            case 2:
                                Console.WriteLine("Digite o Nome Genérico do Produto: ");
                                generico = Console.ReadLine();

                                produtoController.AtualizarProduto(new Medicamento(id, tipo, nome, preco, generico));
                                break;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"O Produto de Id {id} não foi encontrado!");
                        Console.ResetColor();
                    }

                    KeyPress();
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Apagar o Produto\n\n");

                    Console.WriteLine("Digite o Id Produto: ");
                    id = Convert.ToInt32(Console.ReadLine());

                    produtoController.DeletarProduto(id);

                    Console.ResetColor();
                    KeyPress();
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nFarmácia - Pela sua Saúde!");
                    Sobre();
                    Console.ResetColor();
                    KeyPress();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nOpção Inválida!\n");
                    Console.ResetColor();

                    KeyPress();
                    break;
            }
        }
    }

    static void Sobre()
    {
        Console.WriteLine("\n*********************************************************");
        Console.WriteLine("Projeto Desenvolvido por: ");
        Console.WriteLine("Ingrid Manfrin - ingridevelyn.manfrin@gmail.com");
        Console.WriteLine("github.com/ingridmanfrin");  //não esquecer de por o link do git certo!
        Console.WriteLine("*********************************************************");

    }

    static void KeyPress()
    {
        do
        {
            Console.Write("\nPressione Enter para Continuar...");
            consoleKeyInfo = Console.ReadKey();
        } while (consoleKeyInfo.Key != ConsoleKey.Enter);
    }

}



