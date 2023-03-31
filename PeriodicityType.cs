using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicChronology
{
    enum PeriodicityTypeName
    {
        annually,
        monthly,
        twiceMonth,
        weekly
    }
    internal class PeriodicityType
    {
        public int Id { get; }
        public PeriodicityTypeName type { get; }
        public string typeName { get; }

        public PeriodicityType(int id, string name)
        {
            Id = id;
            type = name switch
            {
                "annually" => PeriodicityTypeName.annually,
                "monthly" => PeriodicityTypeName.monthly,
                "twice a month" => PeriodicityTypeName.twiceMonth,
                "weekly" => PeriodicityTypeName.weekly,
                _ => throw new Exception("Unknown type of periodicity"),
            };
            typeName = name;
        }

        public override string ToString()
        {
            return typeName;
        }
    }
}
