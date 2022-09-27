using System;
using System.Collections.Generic;

#nullable disable

namespace Компьютерный клуб сайт.Server
{
    public partial class РасположениеКлуба
    {
        public int ClubId { get; set; }
        public string Адрес { get; set; }
        public int? ArendaId { get; set; }

        public virtual Аренда Arenda { get; set; }
    }
}
