using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllProjects();
        Task<Project> GetProjectById(int id);
        Task<Project> CreateProject(Project project);
        Task<Project> UpdateProject(int id, Project updatedProject);
        Task<int> DeleteProject(int id);
    }
}
