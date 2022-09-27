using System;
using System.Collections.Generic;

#nullable disable

namespace Компьютерный клуб сайт.Server
{
    public partial class Покупатель
    {
        public Покупатель()
        {
            Услугаs = new HashSet<Услуга>();
        }

        public int Id { get; set; }
        public string Имя { get; set; }
        public string Фамилия { get; set; }
        public byte? Возраст { get; set; }
        public string ДеньРожденияСегодня { get; set; }

        public virtual ICollection<Услуга> Услугаs { get; set; }
    }
}
