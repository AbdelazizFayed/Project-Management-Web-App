using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class TaskDetailesDTO
    {

        public int Id { get; set; }
        public string Titel { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TaskPriority Priority { get; set; }
        public TasksStatus Status { get; set; }
        public string AssignedToName{ get; set; }

    }
}
