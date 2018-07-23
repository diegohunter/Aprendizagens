using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Angular.Models
{
    [Table("TRA_TRANSACOES")]
    public class Transacao
    {
        public Transacao()
        {
            TransacoesDetalhamento = new HashSet<TransacaoDetalhamento>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tra_transacao_id")]
        public int? TransacaoID { get; set; }

        [Column("tra_descricao", TypeName = "VARCHAR(150)")]
        public string Descricao { get; set; }

        [Column("tra_sigla", TypeName = "VARCHAR(2)")]
        public string Sigla { get; set; }

        public ICollection<TransacaoDetalhamento> TransacoesDetalhamento { get; set; }
    }
}
