using System;

namespace TerminalSuporte.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string comando = "";

            while (comando.ToLower() != "sair")
            {
                Console.Clear();
                ExibirMenuPrincipal();
                Console.Write("\nDigite um comando: ");
                comando = Console.ReadLine()?.ToLower() ?? "";

                switch (comando)
                {
                    case "ping":
                        ExecutarPing();
                        break;
                    case "reset":
                        ExecutarReset();
                        break;
                    case "help":
                    case "?":
                        ExibirAjuda();
                        break;
                    case "sair":
                        Console.WriteLine("Encerrando terminal...");
                        break;
                    default:
                        NotificarErro($"ERRO: Comando '{comando}' não reconhecido. Digite 'HELP' para ver a lista.");
                        break;
                }
            }
        }

        static void ExibirMenuPrincipal()
        {
            Console.WriteLine("Terminal de Diagnóstico v2.0");
            Console.WriteLine("----------------------------------");
            Console.Write("STATUS DO SISTEMA: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[OPERACIONAL]");
            Console.ResetColor();

            // Heurística #6: Reconhecimento em vez de Recordação (Legenda fixa)
            Console.WriteLine("\nCOMANDOS DISPONÍVEIS:");
            Console.WriteLine("> [PING]  - Testar conexão");
            Console.WriteLine("> [RESET] - Reiniciar servidor (Crítico)");
            Console.WriteLine("> [HELP]  - Ajuda");
            Console.WriteLine("> [SAIR]  - Fechar terminal");
        }

        static void ExecutarPing()
        {
            Console.Clear();
            Console.WriteLine("=== DIAGNÓSTICO DE REDE ===");
            
            // Heurística #10: Ajuda contextual (Formato esperado)
            Console.WriteLine("Formato esperado: 192.168.0.1 (Somente números e pontos)");
            Console.Write("Digite o IP de destino: ");
            string ip = Console.ReadLine() ?? "";

            // Heurística #5: Prevenção de Erros (Validação de entrada)
            if (string.IsNullOrEmpty(ip) || !ip.Contains("."))
            {
                NotificarErro("IP Inválido! Certifique-se de usar o formato correto (ex: 127.0.0.1).");
                return;
            }

            Console.WriteLine($"\n[IHC] Enviando pacotes para {ip}...");
            System.Threading.Thread.Sleep(1500);
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Resposta recebida com sucesso! Latência: 15ms.");
            Console.ResetColor();
            Console.ReadKey();
        }

        static void ExecutarReset()
        {
            // Heurística #5: Confirmação extra para ação crítica
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" !!! AVISO DE SEGURANÇA !!! ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nVocê solicitou o REBOOT do servidor central.");
            Console.WriteLine("Isso desconectará todos os usuários ativos.");
            Console.ResetColor();

            Console.Write("\nTem certeza que deseja continuar? (S/N): ");
            string confirma = Console.ReadLine()?.ToUpper() ?? "";

            if (confirma == "S")
            {
                Console.WriteLine("\nReiniciando sistema...");
                System.Threading.Thread.Sleep(2000);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Servidor Online.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("\nOperação cancelada pelo usuário.");
            }
            Console.ReadKey();
        }

        static void ExibirAjuda()
        {
            // Heurística #10: Ajuda e Documentação
            Console.Clear();
            Console.WriteLine("=== CENTRAL DE AJUDA ===");
            Console.WriteLine("PING:  Verifica se um servidor está respondendo.");
            Console.WriteLine("RESET: Desliga e liga o servidor (Uso restrito).");
            Console.WriteLine("SAIR:  Encerra a sessão atual com segurança.");
            Console.WriteLine("\nPressione qualquer tecla para retornar.");
            Console.ReadKey();
        }

        static void NotificarErro(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{mensagem}");
            Console.ResetColor();
            Console.WriteLine("Pressione uma tecla para continuar...");
            Console.ReadKey();
        }
    }
}