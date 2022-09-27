using System;
using System.Collections.Generic;

#nullable disable

namespace Компьютерный клуб сайт.Server
{
    public partial class Оплата
    {
        public int? ExtraId { get; set; }
        public int? ClubId { get; set; }
        public long? НомерКарты { get; set; }
        public long? НомерТелефона { get; set; }

        public virtual РасположениеКлуба Club { get; set; }
        public virtual ДополнительныеУслуги Extra { get; set; }
    }
}
