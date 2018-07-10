using System;
using System.Collections.Generic;
using ToDoList.Data;

namespace ToDoList.DataManager.Implementation
{
    internal class ToDoTaskManager : IToDoTaskManager
    {
        private List<IToDoTask> _tasks;

        internal ToDoTaskManager()
        {
            _tasks = new List<IToDoTask>();
        }

        public IEnumerable<IToDoTask> AllTasks
        {
            get { return _tasks; }
        }

        public bool Add(IToDoTask task)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IToDoTask> FindTasksByLocation(string location, bool matchExactLocation)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IToDoTask> FindTasksByTitle(string title, bool matchExactTitle)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IToDoTask> GetAllInvalidTasks()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IToDoTask> GetAllValidTasks()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IToDoTask> GetTasksByStatus(TaskStatus status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IToDoTask> GetTasksPerDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IToDoTask> GetTasksPerDateRange(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IToDoTask task)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
