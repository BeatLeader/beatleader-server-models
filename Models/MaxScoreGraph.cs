namespace BeatLeader_Server.Models {
    public class MaxScoreGraph {
        public int Id { get; set; }
        public byte[] Graph { get; set; }

        public void SaveList(List<(float, int)> list)
        {
            var bytes = new List<byte>();
            foreach (var (f, i) in list)
            {
                bytes.AddRange(BitConverter.GetBytes(f));
                bytes.AddRange(BitConverter.GetBytes(i));
            }
            Graph = bytes.ToArray();
        }

        public List<(float, int)> LoadList()
        {
            var list = new List<(float, int)>();
            for (int i = 0; i < Graph.Length; i += 8)
            {
                float floatPart = BitConverter.ToSingle(Graph, i);
                int intPart = BitConverter.ToInt32(Graph, i + 4);
                
                list.Add((floatPart, intPart));
            }
            return list;
        }
    }
}
