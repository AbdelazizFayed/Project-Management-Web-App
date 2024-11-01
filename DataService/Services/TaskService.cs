using DataAccess.Context;
using DataService.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<TaskEntity> CreateTask(TaskEntity task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TaskEntity>> GetAllTasksForProject(int projectId)
        {
            return await _context.Tasks.Where(t => t.ProjectId == projectId).ToListAsync();
        }

        public async Task<IEnumerable<TaskEntity>> GetOverdueTasks()
        {
            var currentDate = DateTime.Now;
            return await _context.Tasks.Where(t => t.EndDate < currentDate).ToListAsync();
        }

        public async Task<TaskEntity> GetTaskById(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<TaskEntity> UpdateTask(int id, TaskEntity updatedTask)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                task.TaskName = updatedTask.TaskName;
                task.Description = updatedTask.Description;
                task.AssignedTo = updatedTask.AssignedTo;
                task.StartDate = updatedTask.StartDate;
                task.EndDate = updatedTask.EndDate;
                task.Priority = updatedTask.Priority;
                task.Status = updatedTask.Status;

                await _context.SaveChangesAsync();
            }
            return task;
        }
    }
}
