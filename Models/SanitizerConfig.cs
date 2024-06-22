namespace BeatLeader_Server.Models {
    public enum SanitizerElement {
        Unknown,
        Attribute,
        Tag,
        Scheme,
        CssProperty,
        IframeUrl
    }

    public class SanitizerConfig {
        public int Id { get; set; }
        public SanitizerElement Type { get; set; }
        public string Value { get; set; }
    }
}
