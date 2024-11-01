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
    public class ProjectService : IProjectService
    {
        private readonly AppDbContext _context;

        public ProjectService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Project> CreateProject(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<int> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return 0;
            }

            _context.Projects.Remove(project);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetProjectById(int id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task<Project> UpdateProject(int id, Project updatedProject)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return null;
            }

            project.ProjectName = updatedProject.ProjectName;
            project.Description = updatedProject.Description;
            project.StartDate = updatedProject.StartDate;
            project.EndDate = updatedProject.EndDate;
            project.Budget = updatedProject.Budget;
            project.Owner = updatedProject.Owner;
            project.Status = updatedProject.Status;

            await _context.SaveChangesAsync();

            return project;
        }
    }
}
