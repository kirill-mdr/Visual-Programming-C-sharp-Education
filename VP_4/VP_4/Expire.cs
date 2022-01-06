using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_4
{
    class Expire : IExpired
    {
        DateTime lifeDate;

        public Expire(DateTime date)
        {
            lifeDate = date;
        }
        public DateTime LifeDate { get => lifeDate; set => lifeDate = value; }

        public int GetExpireDays()
        {
            return (LifeDate - DateTime.Now).Days;
        }

    }
}
