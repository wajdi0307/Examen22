using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Trophee
    {
        [DataType(DataType.Date)]
        public DateTime DateTrophee { get; set; }
        [DataType(DataType.Currency)]
        public Double Recompense { get; set; }
        public int TropheeId { get; set; }
        public String TypeTrophee { get; set; }
        public virtual Equipe Equipe { get; set; }
        [ForeignKey("Equipe")]
        public  int EquipeFK { get; set; }
    }
}
