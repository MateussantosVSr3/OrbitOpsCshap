using System;
using OrbitOps.Net.Application.Interfaces;
using OrbitOps.Net.Application.Services;
using OrbitOps.Net.Domain.Entities;
using OrbitOps.Net.Domain.ValueObjects;
using OrbitOps.Net.Domain.Exceptions;
using OrbitOps.Net.Infrastructure.Utils;

namespace OrbitOps.Net
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("================================================================");
            Console.WriteLine("           ORBITOPS NET - ENGINE DE AUDITORIA ORBITAL           ");
            Console.WriteLine("================================================================");

            // Uso correto de Interfaces para desacoplamento
            IGovernancaEngine motorGovernanca = new GovernancaEngine();

            // Instanciação usando Struct para alocação eficiente de memória
            var coordenadasSatelite = new CoordenadasOrbitais(-23.5631, -46.6544, 420.0);

            // Instanciação da entidade de domínio (POO / Herança)
            SateliteBase nanoSatelite = new SateliteCubeSat(101, "FIAP-CUBESAT-1", coordenadasSatelite, 3.0);

            // -------------------------------------------------------------------------
            // CASO DE TESTE 1: Operação Padrão Nominal (Sucesso)
            // -------------------------------------------------------------------------
            string assinaturaSegura = CriptografiaUtil.GerarHashSeguro("ID=101;STATUS=NOMINAL");
            Console.WriteLine($"[Cyber Security] Pacote verificado por assinatura: {assinaturaSegura}");

            motorGovernanca.AuditarDadosOperacionais(nanoSatelite, 24.5, 92.0, true);

            // -------------------------------------------------------------------------
            // CASO DE TESTE 2: Telemetria Degradada (Gera Alerta sem quebrar a aplicação)
            // -------------------------------------------------------------------------
            motorGovernanca.AuditarDadosOperacionais(nanoSatelite, 62.0, 12.0, true);

            // -------------------------------------------------------------------------
            // CASO DE TESTE 3: Falha Crítica com Tratamento e Captura de Erro Específico
            // -------------------------------------------------------------------------
            Console.WriteLine("\n[Simulação de Anomalia] Cortando sinal de comunicação do satélite...");
            try
            {
                motorGovernanca.AuditarDadosOperacionais(nanoSatelite, 20.0, 50.0, false);
            }
            catch (FalhaSinalSateliteException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[CATCH - EXCEÇÃO CAPTURADA]");
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }

            Console.WriteLine("\n================================================================");
            Console.WriteLine("        FIM DA EXECUÇÃO DE TESTES - OPERAÇÃO CONCLUÍDA          ");
            Console.WriteLine("================================================================");
        }
    }
}