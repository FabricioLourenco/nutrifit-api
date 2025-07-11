﻿using Nutrifit.Domain.Enuns;

namespace Nutrifit.Domain.DTos
{
    public class ItemRefeicaoDTo
    {
        public long Id { get; set; }
        public string? Nome { get; set; }
        public decimal Quantidade { get; set; }
        public UnidadeMedidaEnum UnidadeMedida { get; set; }
        public long AlimentoId { get; set; }
    }
}
