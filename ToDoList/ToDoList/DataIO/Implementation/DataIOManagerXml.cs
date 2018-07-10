using System.Collections.Generic;
using ToDoList.Data;
using ToDoList.DataManager;
using ToDoList.DataManager.Implementation;

namespace ToDoList.DataIO.Implementation
{
    internal class DataIOManagerXml : IDataIOManagerXml
    {
        const string FileName = @"c:\tasks.xml";
        internal DataIOManagerXml()
        {
            TaskManager = new ToDoTaskManager();
        }

        public IToDoTaskManager TaskManager { get; }

        public IEnumerable<IToDoTask> ReadAllTasks()
        {
            throw new System.NotImplementedException();
        }

        public bool SaveAllTasks()
        {
            throw new System.NotImplementedException();
        }
    }
}
