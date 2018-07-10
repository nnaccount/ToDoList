using System;
using System.Collections.Generic;
using ToDoList.Data;

namespace ToDoList.DataManager
{
    public interface IToDoTaskManager
    {
        IEnumerable<IToDoTask> AllTasks { get; }
        bool Add(IToDoTask task);
        bool Remove(IToDoTask task);
        bool Remove(Guid id);
        IEnumerable<IToDoTask> FindTasksByTitle(string title, bool matchExactTitle);
        IEnumerable<IToDoTask> FindTasksByLocation(string location, bool matchExactLocation);
        IEnumerable<IToDoTask> GetTasksPerDate(DateTime date);
        IEnumerable<IToDoTask> GetTasksPerDateRange(DateTime startDate, DateTime endDate);
        IEnumerable<IToDoTask> GetTasksByStatus(TaskStatus status);
        IEnumerable<IToDoTask> GetAllValidTasks();
        IEnumerable<IToDoTask> GetAllInvalidTasks();
    }
}
