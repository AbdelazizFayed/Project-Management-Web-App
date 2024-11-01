using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Interfaces
{
    public interface ITaskService
    {
        Task<TaskEntity> GetTaskById(int id);
        Task<IEnumerable<TaskEntity>> GetAllTasksForProject(int projectId);
        Task<IEnumerable<TaskEntity>> GetOverdueTasks();
        Task<TaskEntity> CreateTask(TaskEntity task);
        Task<TaskEntity> UpdateTask(int id, TaskEntity updatedTask);
        Task DeleteTask(int id);
    }
}
