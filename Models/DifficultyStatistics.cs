using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatLeader_Server.Models {
    public class DifficultyStatistics {
        public int Id { get; set; }
        public int Stacks { get; set; }
        public int Towers { get; set; }
        public int Sliders { get; set; }
        public int CurvedSliders { get; set; }
        public int Windows { get; set; }
        public int SlantedWindows { get; set; }
        public int DodgeWalls { get; set; }
        public int CrouchWalls { get; set; }
        public int ParityErrors { get; set; }
        public int BombAvoidances { get; set; }
        public int LinearSwings { get; set; }
        public List<MapSwingData> SwingData { get; set; }
    }
}
