using Domain.Enums;

namespace Domain.DTOs
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AssignedToName { get; set; }
        public TaskStatus Status { get; set; }
        public TaskPriority Priority { get; set;     }
    }
}
