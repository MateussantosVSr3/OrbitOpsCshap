using System;
using OrbitOps.Net.Domain.ValueObjects;

namespace OrbitOps.Net.Domain.Entities
{
    // Primeira parte da classe parcial focada em comportamentos/métodos
    public partial class SateliteCubeSat : SateliteBase
    {
        public SateliteCubeSat(int id, string nome, CoordenadasOrbitais posicao, double tamanhoU)
            : base(id, nome, posicao)
        {
            TamanhoU = tamanhoU;
            ModoSegurancaAtivo = false;
        }

        public override bool ValidarSubsistemas(double temperaturaBateria, double nivelEnergia)
        {
            // Regra de negócio: CubeSats operam em janelas estritas de energia e temperatura
            if (temperaturaBateria > 55.0 || nivelEnergia < 15.0)
            {
                ModoSegurancaAtivo = true;
                return false;
            }

            ModoSegurancaAtivo = false;
            UltimaComunicacao = DateTime.Now;
            return true;
        }
    }
}