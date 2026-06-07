using System;
using OrbitOps.Net.Application.Interfaces;
using OrbitOps.Net.Domain.Entities;
using OrbitOps.Net.Domain.Exceptions;

namespace OrbitOps.Net.Application.Services
{
    public class GovernancaEngine : IGovernancaEngine
    {
        public void AuditarDadosOperacionais(SateliteBase satelite, double temperatura, double energia, bool sinalAtivo)
        {
            Console.WriteLine($"\n[Auditoria Terrestre - {DateTime.Now:dd/MM/yyyy HH:mm:ss}]");
            Console.WriteLine($"Varrendo Ativo: {satelite.Nome} | Localização Atual: {satelite.Posicao.ObterLocalizacaoFormatada()}");

            // Validação de segurança crítica (Dispara exceção e impede colapso silencioso)
            if (!sinalAtivo)
            {
                throw new FalhaSinalSateliteException(satelite.Id, satelite.Nome);
            }

            bool statusValido = satelite.ValidarSubsistemas(temperatura, energia);

            if (!statusValido)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[⚠️ ALERTA OPERACIONAL] {satelite.Nome} operando fora das métricas ideais! Modo de Segurança Ativado.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[✔️ STATUS NOMINAL] {satelite.Nome} está operando com estabilidade.");
                Console.ResetColor();
            }
        }
    }
}