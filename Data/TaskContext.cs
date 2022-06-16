using Modal;

namespace b1.Data
{
    public static class TaskContext
    {
        public static List<TaskModel> TaskModels = new List<TaskModel>{
            new TaskModel("Hello1", true),
            new TaskModel("Hello2", false)
        };
    }
}