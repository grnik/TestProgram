using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class Visit
    {
        public Guid Id { get; set; }
        public VisitType Type { get; set; }
        public DateTime Date { get; set; }
        public string Diagnosis { get; set; }
    }
}
