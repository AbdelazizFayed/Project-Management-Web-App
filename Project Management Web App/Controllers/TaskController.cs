using DataService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Project_Management_Web_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public TaskController(IProjectService projectService)
        {
            _projectService = projectService;
        }


    }
}
