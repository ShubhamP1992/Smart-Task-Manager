namespace SmartTaskManager.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";

        public int AssignedUserId { get; set; }
        public User? AssignedUser { get; set; }

        public int WorkspaceId { get; set; }
        public Workspace? Workspace { get; set; }
    }

}
