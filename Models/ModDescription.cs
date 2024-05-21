using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatLeader_Server.Models {
    public class ModDescription {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cover { get; set; }
        public string GithubLink { get; set; }
        public int Downloads { get; set; }
        public int Timeset { get; set; }
    }
}
