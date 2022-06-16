using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using b1.Data;
using b1.DTO;
using b1.Services.Interfaces;
using Modal;

namespace b1.Services
{
    public class TaskService : ITaskService
    {
        public TaskModel Create(string title, bool isCompleted)
        {
            TaskModel newTask = new TaskModel(title, isCompleted);
            TaskContext.TaskModels.Add(newTask);

            return newTask;
        }

        public List<TaskModel> GetAll()
        {
            return TaskContext.TaskModels;
        }

        public TaskModel? GetById(Guid id)
        {
            return TaskContext.TaskModels.Find(t => t.Id == id);
        }

        public bool DeleteById(Guid id)
        {
            var item = TaskContext.TaskModels.Find(t => t.Id == id);
            if (item != null)
            {
                TaskContext.TaskModels.Remove(item);

                return true;
            }

            return false;
        }

        public TaskModel? Edit(TaskModelDTO model)
        {
            var item = TaskContext.TaskModels.Find(t => t.Id == model.Id);
            if (item != null)
            {
                item.Title = model.Title;
                item.IsCompleted = model.IsCompleted;

                return item;
            }

            return null;
        }

        public bool DeleteByIds(List<Guid> ids)
        {
            try
            {
                TaskContext.TaskModels.RemoveAll(item => ids.Contains(item.Id));
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<TaskModel> AddTasks(List<TaskModelDTO> models)
        {
            var newTasks = new List<TaskModel>();

            foreach (var task in models)
            {
                newTasks.Add(new TaskModel(task.Title, task.IsCompleted));
            }
            TaskContext.TaskModels.AddRange(newTasks);

            return newTasks;
        }
    }
}