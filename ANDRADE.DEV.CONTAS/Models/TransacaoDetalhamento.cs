using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Angular.Models
{
    [Table("TRD_TRANSACOES_DETALHAMENTO")]
    public class TransacaoDetalhamento
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("trd_transacao_detalhamento_id")]
        public int? TransacaoDetalhamentoID { get; set; }

        [Column("trd_valor_entrada", TypeName = "NUMERIC(11, 2)")]
        public decimal? ValorEntrada { get; set; }

        [Column("trd_valor_saida", TypeName = "NUMERIC(11, 2)")]
        public decimal? ValorSaida { get; set; }
        
        [Column("trd_ordem")]
        public int? Ordem { get; set; }

        [Column("tra_transacao_id")]
        public int? TransacaoID { get; set; }

        public Transacao Transacao { get; set; } 
    }
}
