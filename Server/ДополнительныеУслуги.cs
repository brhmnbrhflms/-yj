using System;
using System.Collections.Generic;

#nullable disable

namespace Компьютерный клуб сайт.Server
{
    public partial class ДополнительныеУслуги
    {
        public int ExtraId { get; set; }
        public byte? СколькоМониторовНужно { get; set; }
        public int? UslugaId { get; set; }
        public string ВыделятьОтдельнуюКомнату { get; set; }

        public virtual Услуга Usluga { get; set; }
    }
}
