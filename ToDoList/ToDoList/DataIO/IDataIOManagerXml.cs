using System.Collections.Generic;
using ToDoList.Data;
using ToDoList.DataManager;

namespace ToDoList.DataIO
{
    public interface IDataIOManagerXml
    {
        IToDoTaskManager TaskManager { get; }
        IEnumerable<IToDoTask> ReadAllTasks();
        bool SaveAllTasks();
    }
}
