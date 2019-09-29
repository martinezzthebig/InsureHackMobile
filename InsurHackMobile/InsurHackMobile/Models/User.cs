using System;
using System.Collections.Generic;
using System.Text;

namespace InsurHackMobile.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public bool IsMarried { get; set; }
        public string ProfessionId { get; set; }
        public List<Drive> Drives { get; set; } = new List<Drive>();
        public int YearOfDriversLicense { get; set; }
        public double TotalRiskFactor { get; set; }
    }
}
