using System.Threading;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Service.Interfaces;
using TaskManager.Share.Models;

namespace TaskManager.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyTasksController : ControllerBase
    {
        private readonly IMyTaskService _myTaskService;

        public MyTasksController(IMyTaskService myTaskService)
        {
            _myTaskService = myTaskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            return Ok(await _myTaskService.GetMyTasksAll(asNoTracking: true, cancellationToken).ConfigureAwait(false));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var task = await _myTaskService.GetMyTaskByIdAsync(id, cancellationToken).ConfigureAwait(false);

            if (task.Id == 0)
                return NotFound();

            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(MyTaskDto myTaskDto, CancellationToken cancellationToken)
        {
            await _myTaskService.CreateMyTaskAsync(myTaskDto, cancellationToken).ConfigureAwait(false);

            return Ok(myTaskDto);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(MyTaskDto myTaskDto, CancellationToken cancellationToken)
        {
            
            var result = await _myTaskService.EditMyTaskAsync(myTaskDto, cancellationToken).ConfigureAwait(false);

            if (!result)
                return NotFound();

            return Ok(myTaskDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var result = await _myTaskService.DeleteMyTaskByIdAsync(id, cancellationToken).ConfigureAwait(false);

            if (!result)
                return NotFound();

            return NoContent();

        }

    }
}
