using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public enum Gender { Man, Woman }
    public class Patient
    {
        public Guid Id { get; set; }
        public string FIO { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
