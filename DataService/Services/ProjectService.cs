using DataAccess.Context;
using DataService.Interfaces;
using Domain.DTOs;
using Domain.Entities;
using Domain.Enums;
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

        public async Task<Project> CreateProject(ProjectDTO projectDto)
        {
            // get the owner from the database by id
            var owner = await _context.Users.FindAsync(projectDto.OwnerId);
            if (owner == null)
            {
                throw new Exception("User Not Found");
            }
      
            var projectEntity = new Project
            {
                ProjectName = projectDto.ProjectName,
                Description = projectDto.Description,
                StartDate = projectDto.StartDate,
                EndDate = projectDto.EndDate,
                Budget = projectDto.Budget,
                Owner =owner,
                Status = projectDto.Status
            };
            
            _context.Projects.Add(projectEntity);
            await _context.SaveChangesAsync();

            
            return projectEntity;
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

        public async Task<IEnumerable<IdNameDTO>> GetAllProjects()
        {
            return await _context.Projects.Select(x => new IdNameDTO { Id = x.Id, Name = x.ProjectName }).ToListAsync();
        }
        public async Task<ProjectDetalisDTO> GetProjectDetalisById(int id)
        {

            var project = await _context.Projects.Where(x => x.Id == id).Select(p => new ProjectDetalisDTO
            {
                Budget = p.Budget,
                Description = p.Description,
                Name = p.ProjectName,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                Status = p.Status,
                OwnerName = p.Owner.FullName,
                Tasks = p.Tasks.Select(t => new TaskDTO
                {
                    Title = t.TaskName,
                    Priority= t.Priority,
                    Status= t.Status,
                    AssignedToName=t.AssignedTo.FullName,
                    Id = t.Id
                }).ToList()
            }).FirstOrDefaultAsync();

            return project;
        }

        public async Task<ProjectDTO> UpdateProject(int id, ProjectDTO updatedProject)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return null;
            }
            else if (project.Owner.Id != updatedProject.OwnerId)
            {
                var owner = await _context.Users.FindAsync(updatedProject.OwnerId);
                if (owner == null)
                {
                    throw new Exception("User Not Found");
                }
                project.Owner = owner;
            }


            project.ProjectName = updatedProject.ProjectName;
            project.Description = updatedProject.Description;
            project.StartDate = updatedProject.StartDate;
            project.EndDate = updatedProject.EndDate;
            project.Budget = updatedProject.Budget;
            project.Status = updatedProject.Status;

            await _context.SaveChangesAsync();

            updatedProject.Id = project.Id;
            return updatedProject;
        }
    }





}
