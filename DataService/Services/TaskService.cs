using DataAccess.Context;
using DataService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public Task<Task> CreateTask(Task task)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTask(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Task>> GetAllTasksForProject(int projectId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Task>> GetOverdueTasks()
        {
            throw new NotImplementedException();
        }

        public Task<Task> UpdateTask(int id, Task updatedTask)
        {
            throw new NotImplementedException();
        }
    }
}
