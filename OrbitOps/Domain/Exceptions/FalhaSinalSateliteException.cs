using System;

namespace OrbitOps.Net.Domain.Exceptions
{
    public class FalhaSinalSateliteException : Exception
    {
        public int SateliteId { get; }

        public FalhaSinalSateliteException(int sateliteId, string nomeSatelite)
            : base($"[FALHA CRÍTICA DE COMUNICAÇÃO] Perda total de telemetria do ativo espacial ID {sateliteId} ({nomeSatelite}). Sinal ausente ou corrompido.")
        {
            SateliteId = sateliteId;
        }
    }
}