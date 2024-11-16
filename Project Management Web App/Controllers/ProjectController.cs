using DataService.Interfaces;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project_Management_Web_App.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("GetallProjects")]
        public async Task<ActionResult<IEnumerable<Project>>> GetAllProjects()
        {
            var projects = await _projectService.GetAllProjects();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProjectById(int id)
        {
                var project = await _projectService.GetProjectDetalisById(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<ActionResult<Project>> CreateProject(ProjectDTO project)
        {
            var createdProject = await _projectService.CreateProject(project);
            return CreatedAtAction(nameof(GetProjectById), new { id = createdProject.Id }, createdProject);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Project>> UpdateProject(int id, ProjectDTO updatedProject)
        {
            var project = await _projectService.UpdateProject(id, updatedProject);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [Authorize(Roles ="Manager")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteProject(int id)
        {
            var result = await _projectService.DeleteProject(id);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
