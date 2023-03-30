using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicChronology
{
    internal class Series
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PeriodicityTypeId { get; set; }

        public Series(int id, string title, int periodicityTypeId)
        {
            Id = id;
            Title = title;
            PeriodicityTypeId = periodicityTypeId;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
