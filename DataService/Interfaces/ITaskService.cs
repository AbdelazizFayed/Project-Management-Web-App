using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<Task>> GetAllTasksForProject(int projectId);
        Task<IEnumerable<Task>> GetOverdueTasks();
        Task<Task> CreateTask(Task task);
        Task<Task> UpdateTask(int id, Task updatedTask);
        Task DeleteTask(int id);
    }
}
