﻿using Domain.DTOs;
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
        Task<IEnumerable<IdNameDTO>> GetAllProjects();
        Task<Project> CreateProject(ProjectDTO projectDto); 
        Task<ProjectDTO> UpdateProject(int id, ProjectDTO updatedProject);
        Task<ProjectDetalisDTO> GetProjectDetalisById(int id);
        Task<int> DeleteProject(int id);
    }
}
