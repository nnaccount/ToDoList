using System;

namespace ToDoList.Data.Implementation
{
    internal class ToDoTask : IToDoTask
    {
        internal ToDoTask() : this(Guid.NewGuid())
        {

        }

        internal ToDoTask(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public TaskStatus Status { get; set; }

        public bool IsValild
        {
            get {
                return Status == TaskStatus.Canceled
                       || Status == TaskStatus.Active && Date.Date >= DateTime.Now.Date
                       || Status == TaskStatus.Done && Date.Date <= DateTime.Now.Date;
            }
        }

        public IToDoTask DeepCopy()
        {
            return new ToDoTask
            {
                Title = Title,
                Description = Description,
                Location = Location,
                Date = DateTime.Now,
                Status = TaskStatus.Active
            };
        }

        public override string ToString()
        {
            return string.Format($"Title: {Title}{0}Description: {Description}{0}Location: {Location}{0}Date: {Date.Date.ToShortDateString()}{0}Status: {Status}", Environment.NewLine);
        }
    }
}
