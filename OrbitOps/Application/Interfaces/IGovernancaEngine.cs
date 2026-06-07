using OrbitOps.Net.Domain.Entities;

namespace OrbitOps.Net.Application.Interfaces
{
    public interface IGovernancaEngine
    {
        void AuditarDadosOperacionais(SateliteBase satelite, double temperatura, double energia, bool sinalAtivo);
    }
}