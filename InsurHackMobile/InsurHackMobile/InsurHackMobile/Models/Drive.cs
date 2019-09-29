using System;
using System.Collections.Generic;
using System.Text;

namespace InsurHackMobile.Models
{
    public class Drive
    {
        public double AvgSpeedOfDrive { get; set; }
        public int DriveTime { get; set; }
        public double TotalDistance { get; set; }
        public int NumberOfSpeedings { get; set; }
        public int TimeSpentInDenseTraffic { get; set; }
        public int TimeSpentSpeeding { get; set; }
        public double RiskFactor { get; set; }
    }
}
