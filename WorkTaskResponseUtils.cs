using BeatLeader_Server.Models;
using static BeatLeader_Server.Utils.ResponseUtils;

namespace BeatLeader_Server.Utils {
    public class WorkTaskResponseUtils {
        
        // ============== Player Reference Response ==============
        public class WorkTaskPlayerResponse {
            public string Id { get; set; } = "";
            public string Name { get; set; } = "";
            public string Avatar { get; set; } = "";
            public string? Alias { get; set; }
            public string Country { get; set; } = "";
            public string Role { get; set; } = "";
        }

        // ============== Status Response ==============
        public class WorkTaskStatusResponse {
            public int Id { get; set; }
            public string Title { get; set; } = "";
            public string? Description { get; set; }
            public string? Icon { get; set; }
            public string? Color { get; set; }
            public int Order { get; set; }
            public bool IsClosedStatus { get; set; }
            public bool IsDefault { get; set; }
        }

        // ============== Tag Response ==============
        public class WorkTaskTagResponse {
            public int Id { get; set; }
            public string Title { get; set; } = "";
            public string? Description { get; set; }
            public string? Icon { get; set; }
            public string? Link { get; set; }
            public string? Color { get; set; }
            public bool AdminOnly { get; set; }
        }

        public class WorkTaskTagAssignmentResponse {
            public int Id { get; set; }
            public WorkTaskTagResponse? Tag { get; set; }
            public WorkTaskPlayerResponse? AddedBy { get; set; }
            public int AddedAt { get; set; }
        }

        // ============== Attachment Response ==============
        public class WorkTaskAttachmentResponse {
            public int Id { get; set; }
            public WorkTaskAttachmentType Type { get; set; }
            public string FileName { get; set; } = "";
            public string Url { get; set; } = "";
            public string? MimeType { get; set; }
            public long? FileSize { get; set; }
            public WorkTaskPlayerResponse? UploadedBy { get; set; }
            public int UploadedAt { get; set; }
        }

        // ============== Comment Response ==============
        public class WorkTaskCommentResponse {
            public int Id { get; set; }
            public string Content { get; set; } = "";
            public WorkTaskPlayerResponse? Author { get; set; }
            public int CreatedAt { get; set; }
            public int? EditedAt { get; set; }
            public bool IsEdited { get; set; }
            public int VoteScore { get; set; }
            public bool IsDeleted { get; set; }
            public int? ParentCommentId { get; set; }
            public int ReplyCount { get; set; }
            public ICollection<WorkTaskCommentAttachmentResponse>? Attachments { get; set; }
            public int? CurrentUserVote { get; set; } // +1, -1, or null if not voted
        }

        public class WorkTaskCommentAttachmentResponse {
            public int Id { get; set; }
            public WorkTaskAttachmentType Type { get; set; }
            public string FileName { get; set; } = "";
            public string Url { get; set; } = "";
        }

        // ============== Assignment Response ==============
        public class WorkTaskAssignmentResponse {
            public int Id { get; set; }
            public WorkTaskPlayerResponse? Player { get; set; }
            public WorkTaskPlayerResponse? AssignedBy { get; set; }
            public int AssignedAt { get; set; }
            public string? Role { get; set; }
            public bool IsPrimary { get; set; }
        }

        // ============== Vote Response ==============
        public class WorkTaskVoteResponse {
            public int Id { get; set; }
            public WorkTaskPlayerResponse? Player { get; set; }
            public int Value { get; set; }
            public int VotedAt { get; set; }
        }

        // ============== History Response ==============
        public class WorkTaskHistoryResponse {
            public int Id { get; set; }
            public WorkTaskHistoryAction Action { get; set; }
            public WorkTaskPlayerResponse? Player { get; set; }
            public int Timestamp { get; set; }
            public string? FieldName { get; set; }
            public string? OldValue { get; set; }
            public string? NewValue { get; set; }
            public string? Details { get; set; }
        }

        // ============== Task Responses ==============
        public class WorkTaskResponseBase {
            public int Id { get; set; }
            public WorkTaskType Type { get; set; }
            public string Title { get; set; } = "";
            public string? Description { get; set; }
            public WorkTaskPlayerResponse? Creator { get; set; }
            public int CreatedAt { get; set; }
            public int? LastEditedAt { get; set; }
            public WorkTaskPlayerResponse? LastEditedBy { get; set; }
            public WorkTaskStatusResponse? Status { get; set; }
            public int Priority { get; set; }
            public int VoteScore { get; set; }
            public int CommentCount { get; set; }
            public bool IsPublic { get; set; }
            public bool IsArchived { get; set; }
            public bool IsLocked { get; set; }
            public int? DueDate { get; set; }
            public int? ResolvedAt { get; set; }
            public WorkTaskPlayerResponse? ResolvedBy { get; set; }
            public int? CurrentUserVote { get; set; } // +1, -1, or null if not voted
        }

        // List item response (lighter for list views)
        public class WorkTaskListResponse : WorkTaskResponseBase {
            public ICollection<WorkTaskTagResponse>? Tags { get; set; }
            public ICollection<WorkTaskPlayerResponse>? Assignees { get; set; }
            public int AttachmentCount { get; set; }
        }

        // Full detail response
        public class WorkTaskDetailResponse : WorkTaskResponseBase {
            public ICollection<WorkTaskTagAssignmentResponse>? TagAssignments { get; set; }
            public ICollection<WorkTaskAttachmentResponse>? Attachments { get; set; }
            public ICollection<WorkTaskAssignmentResponse>? Assignments { get; set; }
        }

        // ============== Bug Report Response ==============
        public class BugReportResponse : WorkTaskDetailResponse {
            public BugSeverity Severity { get; set; }
            public string? StepsToReproduce { get; set; }
            public string? ExpectedBehavior { get; set; }
            public string? ActualBehavior { get; set; }
            public string? Version { get; set; }
            public string? Platform { get; set; }
            public bool? IsReproducible { get; set; }
            public string? LogContent { get; set; }
        }

        // ============== Suggestion Response ==============
        public class SuggestionResponse : WorkTaskDetailResponse {
            public SuggestionCategory Category { get; set; }
            public string? UseCase { get; set; }
            public string? ProposedSolution { get; set; }
            public string? Alternatives { get; set; }
            public string? Impact { get; set; }
            public string? TargetArea { get; set; }
        }

        // ============== Help Request Response ==============
        public class HelpRequestResponse : WorkTaskDetailResponse {
            public HelpCategory Category { get; set; }
            public HelpUrgency Urgency { get; set; }
            public string? AlreadyTried { get; set; }
            public string? ErrorMessage { get; set; }
            public string? Version { get; set; }
            public string? Platform { get; set; }
            public string? Resolution { get; set; }
            public bool IsResolved { get; set; }
            public int? UserResolvedAt { get; set; }
        }

        // ============== Mapping Helpers ==============
        public static WorkTaskPlayerResponse? MapPlayer(Player? player) {
            if (player == null) return null;
            return new WorkTaskPlayerResponse {
                Id = player.Id,
                Name = player.Name,
                Avatar = player.Avatar,
                Alias = player.Alias,
                Country = player.Country,
                Role = player.Role
            };
        }

        public static WorkTaskStatusResponse? MapStatus(WorkTaskStatus? status) {
            if (status == null) return null;
            return new WorkTaskStatusResponse {
                Id = status.Id,
                Title = status.Title,
                Description = status.Description,
                Icon = status.Icon,
                Color = status.Color,
                Order = status.Order,
                IsClosedStatus = status.IsClosedStatus,
                IsDefault = status.IsDefault
            };
        }

        public static WorkTaskTagResponse? MapTag(WorkTaskTag? tag) {
            if (tag == null) return null;
            return new WorkTaskTagResponse {
                Id = tag.Id,
                Title = tag.Title,
                Description = tag.Description,
                Icon = tag.Icon,
                Link = tag.Link,
                Color = tag.Color,
                AdminOnly = tag.AdminOnly
            };
        }
    }
}
