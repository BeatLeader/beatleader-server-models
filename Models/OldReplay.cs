using System.Text;

namespace BeatLeader.Models.Old;

internal class Replay {
    public List<Frame> frames = new();
    public List<AutomaticHeight> heights = new();
    public ReplayInfo info = new();

    public List<NoteEvent> notes = new();
    public List<Pause> pauses = new();
    public List<WallEvent> walls = new();
}

internal class ReplayInfo {
    public string controller = null!;
    public string difficulty = null!;
    public string environment = null!;
    public float failTime;
    public string gameVersion = null!;

    public string hash = null!;
    public float height;
    public string hmd = null!;
    public float jumpDistance;
    public bool leftHanded;
    public string mapper = null!;
    public string mode = null!;
    public string modifiers = null!;
    public string platform = null!;

    public string playerID = null!;
    public string playerName = null!;

    public int score;
    public string songName = null!;
    public float speed;

    public float startTime;
    public string timestamp = null!;

    public string trackingSytem = null!;
    public string version = null!;
}

internal class Frame {
    public int fps;
    public Transform head = null!;
    public Transform leftHand = null!;
    public Transform rightHand = null!;
    public float time;
}

internal enum NoteEventType {
    good = 0,
    bad = 1,
    miss = 2,
    bomb = 3
}

internal class NoteEvent {
    public float eventTime;
    public NoteEventType eventType;
    public NoteCutInfo noteCutInfo = null!;
    public int noteID;
    public float spawnTime;
}

internal class WallEvent {
    public float energy;
    public float spawnTime;
    public float time;
    public int wallID;
}

internal class AutomaticHeight {
    public float height;
    public float time;
}

internal class Pause {
    public long duration;
    public float time;
}

internal class NoteCutInfo {
    public float afterCutRating;
    public float beforeCutRating;
    public float cutAngle;
    public float cutDirDeviation;
    public float cutDistanceToCenter;
    public Vector3 cutNormal;
    public Vector3 cutPoint;
    public bool directionOK;
    public Vector3 saberDir;
    public float saberSpeed;
    public int saberType;
    public bool saberTypeOK;
    public bool speedOK;
    public float timeDeviation;
    public bool wasCutTooSoon;
}

internal enum StructType {
    info = 0,
    frames = 1,
    notes = 2,
    walls = 3,
    heights = 4,
    pauses = 5
}

internal struct Vector3 {
    public float x;
    public float y;
    public float z;
}

internal struct Quaternion {
    public float x;
    public float y;
    public float z;
    public float w;
}

internal class Transform {
    public Vector3 position;
    public Quaternion rotation;
}

internal static class ReplayEncoder {
    public static void Encode(Replay replay, BinaryWriter stream) {
        stream.Write(0x442d3d69);
        stream.Write((byte)1);

        for (var a = 0; a < (int)StructType.pauses + 1; a++) {
            var type = (StructType)a;
            stream.Write((byte)a);

            switch (type) {
                case StructType.info:
                    EncodeInfo(replay.info, stream);
                    break;
                case StructType.frames:
                    EncodeFrames(replay.frames, stream);
                    break;
                case StructType.notes:
                    EncodeNotes(replay.notes, stream);
                    break;
                case StructType.walls:
                    EncodeWalls(replay.walls, stream);
                    break;
                case StructType.heights:
                    EncodeHeights(replay.heights, stream);
                    break;
                case StructType.pauses:
                    EncodePauses(replay.pauses, stream);
                    break;
            }
        }
    }

    private static void EncodeInfo(ReplayInfo info, BinaryWriter stream) {
        EncodeString(info.version, stream);
        EncodeString(info.gameVersion, stream);
        EncodeString(info.timestamp, stream);

        EncodeString(info.playerID, stream);
        EncodeString(info.playerName, stream);
        EncodeString(info.platform, stream);

        EncodeString(info.trackingSytem, stream);
        EncodeString(info.hmd, stream);
        EncodeString(info.controller, stream);

        EncodeString(info.hash, stream);
        EncodeString(info.songName, stream);
        EncodeString(info.mapper, stream);
        EncodeString(info.difficulty, stream);

        stream.Write(info.score);
        EncodeString(info.mode, stream);
        EncodeString(info.environment, stream);
        EncodeString(info.modifiers, stream);
        stream.Write(info.jumpDistance);
        stream.Write(info.leftHanded);
        stream.Write(info.height);

        stream.Write(info.startTime);
        stream.Write(info.failTime);
        stream.Write(info.speed);
    }

    private static void EncodeFrames(List<Frame> frames, BinaryWriter stream) {
        stream.Write((uint)frames.Count);

        foreach (var frame in frames) {
            stream.Write(frame.time);
            stream.Write(frame.fps);
            EncodeVector(frame.head.position, stream);
            EncodeQuaternion(frame.head.rotation, stream);
            EncodeVector(frame.leftHand.position, stream);
            EncodeQuaternion(frame.leftHand.rotation, stream);
            EncodeVector(frame.rightHand.position, stream);
            EncodeQuaternion(frame.rightHand.rotation, stream);
        }
    }

    private static void EncodeNotes(List<NoteEvent> notes, BinaryWriter stream) {
        stream.Write((uint)notes.Count);

        foreach (var note in notes) {
            stream.Write(note.noteID);
            stream.Write(note.eventTime);
            stream.Write(note.spawnTime);
            stream.Write((int)note.eventType);

            if (note.eventType == NoteEventType.good || note.eventType == NoteEventType.bad) {
                EncodeNoteInfo(note.noteCutInfo, stream);
            }
        }
    }

    private static void EncodeWalls(List<WallEvent> walls, BinaryWriter stream) {
        stream.Write((uint)walls.Count);

        foreach (var wall in walls) {
            stream.Write(wall.wallID);
            stream.Write(wall.energy);
            stream.Write(wall.time);
            stream.Write(wall.spawnTime);
        }
    }

    private static void EncodeHeights(List<AutomaticHeight> heights, BinaryWriter stream) {
        stream.Write((uint)heights.Count);

        foreach (var height in heights) {
            stream.Write(height.height);
            stream.Write(height.time);
        }
    }

    private static void EncodePauses(List<Pause> pauses, BinaryWriter stream) {
        stream.Write((uint)pauses.Count);

        foreach (var pause in pauses) {
            stream.Write(pause.duration);
            stream.Write(pause.time);
        }
    }

    private static void EncodeNoteInfo(NoteCutInfo info, BinaryWriter stream) {
        stream.Write(info.speedOK);
        stream.Write(info.directionOK);
        stream.Write(info.saberTypeOK);
        stream.Write(info.wasCutTooSoon);
        stream.Write(info.saberSpeed);
        EncodeVector(info.saberDir, stream);
        stream.Write(info.saberType);
        stream.Write(info.timeDeviation);
        stream.Write(info.cutDirDeviation);
        EncodeVector(info.cutPoint, stream);
        EncodeVector(info.cutNormal, stream);
        stream.Write(info.cutDistanceToCenter);
        stream.Write(info.cutAngle);
        stream.Write(info.beforeCutRating);
        stream.Write(info.afterCutRating);
    }

    private static void EncodeString(string value, BinaryWriter stream) {
        var toEncode = value != null ? value : "";
        stream.Write(toEncode.Length);
        stream.Write(Encoding.UTF8.GetBytes(toEncode));
    }

    private static void EncodeVector(Vector3 vector, BinaryWriter stream) {
        stream.Write(vector.x);
        stream.Write(vector.y);
        stream.Write(vector.z);
    }

    private static void EncodeQuaternion(Quaternion quaternion, BinaryWriter stream) {
        stream.Write(quaternion.x);
        stream.Write(quaternion.y);
        stream.Write(quaternion.z);
        stream.Write(quaternion.w);
    }
}

internal static class ReplayDecoder {
    public static Replay? Decode(byte[] buffer) {
        var arrayLength = buffer.Length;

        var pointer = 0;

        var magic = DecodeInt(buffer, ref pointer);
        var version = buffer[pointer++];

        if (magic == 0x442d3d69 && version == 1) {
            var replay = new Replay();

            for (var a = 0; a < (int)StructType.pauses + 1 && pointer < arrayLength; a++) {
                var type = (StructType)buffer[pointer++];

                switch (type) {
                    case StructType.info:
                        replay.info = DecodeInfo(buffer, ref pointer);
                        break;
                    case StructType.frames:
                        replay.frames = DecodeFrames(buffer, ref pointer);
                        break;
                    case StructType.notes:
                        replay.notes = DecodeNotes(buffer, ref pointer);
                        break;
                    case StructType.walls:
                        replay.walls = DecodeWalls(buffer, ref pointer);
                        break;
                    case StructType.heights:
                        replay.heights = DecodeHeight(buffer, ref pointer);
                        break;
                    case StructType.pauses:
                        replay.pauses = DecodePauses(buffer, ref pointer);
                        break;
                }
            }

            return replay;
        }

        return null;
    }

    private static ReplayInfo DecodeInfo(byte[] buffer, ref int pointer) {
        var result = new ReplayInfo();

        result.version = DecodeString(buffer, ref pointer);
        result.gameVersion = DecodeString(buffer, ref pointer);
        result.timestamp = DecodeString(buffer, ref pointer);

        result.playerID = DecodeString(buffer, ref pointer);
        result.playerName = DecodeString(buffer, ref pointer);
        result.platform = DecodeString(buffer, ref pointer);

        result.trackingSytem = DecodeString(buffer, ref pointer);
        result.hmd = DecodeString(buffer, ref pointer);
        result.controller = DecodeString(buffer, ref pointer);

        result.hash = DecodeString(buffer, ref pointer);
        result.songName = DecodeString(buffer, ref pointer);
        result.mapper = DecodeString(buffer, ref pointer);
        result.difficulty = DecodeString(buffer, ref pointer);

        result.score = DecodeInt(buffer, ref pointer);
        result.mode = DecodeString(buffer, ref pointer);
        result.environment = DecodeString(buffer, ref pointer);
        result.modifiers = DecodeString(buffer, ref pointer);
        result.jumpDistance = DecodeFloat(buffer, ref pointer);
        result.leftHanded = DecodeBool(buffer, ref pointer);
        result.height = DecodeFloat(buffer, ref pointer);

        result.startTime = DecodeFloat(buffer, ref pointer);
        result.failTime = DecodeFloat(buffer, ref pointer);
        result.speed = DecodeFloat(buffer, ref pointer);

        return result;
    }

    private static List<Frame> DecodeFrames(byte[] buffer, ref int pointer) {
        var length = DecodeInt(buffer, ref pointer);
        var result = new List<Frame>();

        for (var i = 0; i < length; i++) {
            result.Add(DecodeFrame(buffer, ref pointer));
        }

        return result;
    }

    private static Frame DecodeFrame(byte[] buffer, ref int pointer) {
        var result = new Frame();
        result.time = DecodeFloat(buffer, ref pointer);
        result.fps = DecodeInt(buffer, ref pointer);
        result.head = DecodeEuler(buffer, ref pointer);
        result.leftHand = DecodeEuler(buffer, ref pointer);
        result.rightHand = DecodeEuler(buffer, ref pointer);

        return result;
    }

    private static List<NoteEvent> DecodeNotes(byte[] buffer, ref int pointer) {
        var length = DecodeInt(buffer, ref pointer);
        var result = new List<NoteEvent>();

        for (var i = 0; i < length; i++) {
            result.Add(DecodeNote(buffer, ref pointer));
        }

        return result;
    }

    private static List<WallEvent> DecodeWalls(byte[] buffer, ref int pointer) {
        var length = DecodeInt(buffer, ref pointer);
        var result = new List<WallEvent>();

        for (var i = 0; i < length; i++) {
            var wall = new WallEvent();
            wall.wallID = DecodeInt(buffer, ref pointer);
            wall.energy = DecodeFloat(buffer, ref pointer);
            wall.time = DecodeFloat(buffer, ref pointer);
            wall.spawnTime = DecodeFloat(buffer, ref pointer);
            result.Add(wall);
        }

        return result;
    }

    private static List<AutomaticHeight> DecodeHeight(byte[] buffer, ref int pointer) {
        var length = DecodeInt(buffer, ref pointer);
        var result = new List<AutomaticHeight>();

        for (var i = 0; i < length; i++) {
            var height = new AutomaticHeight();
            height.height = DecodeFloat(buffer, ref pointer);
            height.time = DecodeFloat(buffer, ref pointer);
            result.Add(height);
        }

        return result;
    }

    private static List<Pause> DecodePauses(byte[] buffer, ref int pointer) {
        var length = DecodeInt(buffer, ref pointer);
        var result = new List<Pause>();

        for (var i = 0; i < length; i++) {
            var pause = new Pause();
            pause.duration = DecodeLong(buffer, ref pointer);
            pause.time = DecodeFloat(buffer, ref pointer);
            result.Add(pause);
        }

        return result;
    }

    private static NoteEvent DecodeNote(byte[] buffer, ref int pointer) {
        var result = new NoteEvent();
        result.noteID = DecodeInt(buffer, ref pointer);
        result.eventTime = DecodeFloat(buffer, ref pointer);
        result.spawnTime = DecodeFloat(buffer, ref pointer);
        result.eventType = (NoteEventType)DecodeInt(buffer, ref pointer);

        if (result.eventType == NoteEventType.good || result.eventType == NoteEventType.bad) {
            result.noteCutInfo = DecodeCutInfo(buffer, ref pointer);
        }

        return result;
    }

    private static NoteCutInfo DecodeCutInfo(byte[] buffer, ref int pointer) {
        var result = new NoteCutInfo();
        result.speedOK = DecodeBool(buffer, ref pointer);
        result.directionOK = DecodeBool(buffer, ref pointer);
        result.saberTypeOK = DecodeBool(buffer, ref pointer);
        result.wasCutTooSoon = DecodeBool(buffer, ref pointer);
        result.saberSpeed = DecodeFloat(buffer, ref pointer);
        result.saberDir = DecodeVector3(buffer, ref pointer);
        result.saberType = DecodeInt(buffer, ref pointer);
        result.timeDeviation = DecodeFloat(buffer, ref pointer);
        result.cutDirDeviation = DecodeFloat(buffer, ref pointer);
        result.cutPoint = DecodeVector3(buffer, ref pointer);
        result.cutNormal = DecodeVector3(buffer, ref pointer);
        result.cutDistanceToCenter = DecodeFloat(buffer, ref pointer);
        result.cutAngle = DecodeFloat(buffer, ref pointer);
        result.beforeCutRating = DecodeFloat(buffer, ref pointer);
        result.afterCutRating = DecodeFloat(buffer, ref pointer);
        return result;
    }

    private static Transform DecodeEuler(byte[] buffer, ref int pointer) {
        var result = new Transform();
        result.position = DecodeVector3(buffer, ref pointer);
        result.rotation = DecodeQuaternion(buffer, ref pointer);

        return result;
    }

    private static Vector3 DecodeVector3(byte[] buffer, ref int pointer) {
        var result = new Vector3();
        result.x = DecodeFloat(buffer, ref pointer);
        result.y = DecodeFloat(buffer, ref pointer);
        result.z = DecodeFloat(buffer, ref pointer);

        return result;
    }

    private static Quaternion DecodeQuaternion(byte[] buffer, ref int pointer) {
        var result = new Quaternion();
        result.x = DecodeFloat(buffer, ref pointer);
        result.y = DecodeFloat(buffer, ref pointer);
        result.z = DecodeFloat(buffer, ref pointer);
        result.w = DecodeFloat(buffer, ref pointer);

        return result;
    }

    private static long DecodeLong(byte[] buffer, ref int pointer) {
        var result = BitConverter.ToInt64(buffer, pointer);
        pointer += 8;
        return result;
    }

    private static int DecodeInt(byte[] buffer, ref int pointer) {
        var result = BitConverter.ToInt32(buffer, pointer);
        pointer += 4;
        return result;
    }

    private static string DecodeString(byte[] buffer, ref int pointer) {
        var length = BitConverter.ToInt32(buffer, pointer);
        var @string = Encoding.Unicode.GetString(buffer, pointer + 4, length * 2);
        pointer += length * 2 + 4;
        return @string;
    }

    private static float DecodeFloat(byte[] buffer, ref int pointer) {
        var result = BitConverter.ToSingle(buffer, pointer);
        pointer += 4;
        return result;
    }

    private static bool DecodeBool(byte[] buffer, ref int pointer) {
        var result = BitConverter.ToBoolean(buffer, pointer);
        pointer++;
        return result;
    }
}