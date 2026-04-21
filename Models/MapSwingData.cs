using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatLeader_Server.Models {
    public class MapSwingData {

        public int Id { get; set; }
        public double BpmTime { get; set; } = 0;
        public double Direction { get; set; } = 0;
        public bool Forehand { get; set; } = true;
        public bool ParityErrors { get; set; } = false;
        public bool BombAvoidance { get; set; } = false;
        public bool IsLinear { get; set; } = false;
        public double AngleStrain { get; set; } = 0;
        public double RepositioningDistance { get; set; } = 0;
        public double RotationAmount { get; set; } = 0;
        public double SwingFrequency { get; set; } = 0;
        public double DistanceDiff { get; set; } = 0;
        public double SwingSpeed { get; set; } = 0;
        public double HitDistance { get; set; } = 0;
        public double Stress { get; set; } = 0;
        public double LowSpeedFalloff { get; set; } = 0;
        public double StressMultiplier { get; set; } = 0;
        public double NjsBuff { get; set; } = 1.0;
        public double WallBuff { get; set; } = 1.0;
        public bool IsStream { get; set; } = false;
        public double SwingDiff { get; set; } = 0;
        public double SwingTech { get; set; } = 0;
    }
}
