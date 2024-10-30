using DataAccess.Context;
using DataService.Interfaces;
using Domain.Entities;
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

        public Task<Project> CreateProject(Project project)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteProject(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Project>> GetAllProjects()
        {
            throw new NotImplementedException();
        }

        public Task<Project> GetProjectById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Project> UpdateProject(int id, Project updatedProject)
        {
            throw new NotImplementedException();
        }
    }
}
