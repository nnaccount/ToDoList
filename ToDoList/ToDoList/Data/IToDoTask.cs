using System;

namespace ToDoList.Data
{
    public interface IToDoTask
    {
        Guid Id { get; }
        string Title { get; set; }
        string Description { get; set; }
        string Location { get; set; }
        DateTime Date { get; set; }
        TaskStatus Status { get; set; }
        bool IsValild { get; }

        // Coppies the current task into a new task
        IToDoTask DeepCopy();
    }
}
