using b1.DTO;
using Modal;

namespace b1.Services.Interfaces
{
    public interface ITaskService
    {
        TaskModel Create(string title, bool isCompleted);
        List<TaskModel> GetAll();
        TaskModel? GetById(Guid id);
        bool DeleteById(Guid id);
        TaskModel? Edit(TaskModelDTO model);
        bool DeleteByIds(List<Guid> ids);
        List<TaskModel> AddTasks(List<TaskModelDTO> models);
    }
}