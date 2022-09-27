using System;
using System.Collections.Generic;

#nullable disable

namespace Компьютерный клуб сайт.Server
{
    public partial class Аренда
    {
        public Аренда()
        {
            РасположениеКлубаs = new HashSet<РасположениеКлуба>();
        }

        public int ArendaId { get; set; }
        public bool? НомерКомпьютера { get; set; }
        public DateTime? ВремяИДатаАренды { get; set; }
        public byte? ВремяАренды { get; set; }
        public int? UslugaId { get; set; }

        public virtual Услуга Usluga { get; set; }
        public virtual ICollection<РасположениеКлуба> РасположениеКлубаs { get; set; }
    }
}
