using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class TaskEntoty
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public string AssignedTo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TaskPriority Priority { get; set; }
        public TasksStatus Status { get; set; }
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
    }
}
