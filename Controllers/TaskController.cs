using b1.DTO;
using b1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Modal;

namespace b1.Controllers;

[Route("[controller]")]
public class TaskController : ControllerBase
{
    private ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet("/get-all")]
    public List<TaskModel> GetAll()
    {
        return _taskService.GetAll();
    }

    [HttpPost]
    public TaskModel CreateTask(string title, bool isCompleted)
    {
        return _taskService.Create(title, isCompleted);
    }

    [HttpGet("/get-by-id")]
    public TaskModel? GetById(Guid id)
    {
        return _taskService.GetById(id);
    }

    [HttpDelete]
    public bool DeleteById(Guid id)
    {
        return _taskService.DeleteById(id);
    }

    [HttpPut]
    public TaskModel? Edit([FromBody] TaskModelDTO model)
    {
        return _taskService.Edit(model);
    }

    [HttpPost("/multiple-delete")]
    public bool DeleteByIds([FromBody] List<Guid> ids)
    {
        return _taskService.DeleteByIds(ids);
    }

    [HttpPost("/add-tasks")]
    public List<TaskModel> AddTasks([FromBody] List<TaskModelDTO> models)
    {
        return _taskService.AddTasks(models);
    }
}