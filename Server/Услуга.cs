using System;
using System.Collections.Generic;

#nullable disable

namespace Компьютерный клуб сайт.Server
{
    public partial class Услуга
    {
        public Услуга()
        {
            Арендаs = new HashSet<Аренда>();
            ДополнительныеУслугиs = new HashSet<ДополнительныеУслуги>();
        }

        public int UslugaId { get; set; }
        public int? Стоимость { get; set; }
        public int? ArendaId { get; set; }
        public int? Id { get; set; }

        public virtual Покупатель IdNavigation { get; set; }
        public virtual ICollection<Аренда> Арендаs { get; set; }
        public virtual ICollection<ДополнительныеУслуги> ДополнительныеУслугиs { get; set; }
    }
}
