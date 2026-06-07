using System;
using OrbitOps.Net.Domain.ValueObjects;

namespace OrbitOps.Net.Domain.Entities
{
    public abstract class SateliteBase
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public CoordenadasOrbitais Posicao { get; set; }
        public DateTime UltimaComunicacao { get; set; }

        protected SateliteBase(int id, string nome, CoordenadasOrbitais posicao)
        {
            Id = id;
            Nome = nome;
            Posicao = posicao;
            UltimaComunicacao = DateTime.Now; // Manipulação de DateTime exigida
        }

        // Método abstrato que força polimorfismo nas classes filhas
        public abstract bool ValidarSubsistemas(double temperaturaBateria, double nivelEnergia);
    }
}