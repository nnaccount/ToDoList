using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ToDoList.Data;
using ToDoList.Data.Implementation;

namespace ToDoList.Tests.DataTests
{
    [TestClass]
    public class ToDoTaskTests
    {
        [TestMethod]
        public void ToDoTaskEmptyCtorTest()
        {
            // Testing the creation of a new object with empty parameters constructor.
            var target = new ToDoTask();
            Assert.IsNotNull(target);
            Assert.IsTrue(target.Id != Guid.Empty);
        }
        
        [TestMethod]
        public void ToDoTaskCtorTest()
        {
            // Testing the creation of a new object with Guid parameters constructor.
            var expected = Guid.NewGuid();
            var target = new ToDoTask(expected);
            Assert.IsNotNull(target);

            var actual = target.Id;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToDoTaskTitleTest()
        {
            // Testing the setter and getter of the Title property.
            const string expected = "text";
            var target = new ToDoTask { Title = expected };
            var actual = target.Title;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToDoTaskDescriptionTest()
        {
            // Testing the setter and getter of the Description property.
            const string expected = "text";
            var target = new ToDoTask { Description = expected };
            var actual = target.Description;
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void ToDoTaskLocationTest()
        {
            // Testing the setter and getter of the Location property.
            const string expected = "text";
            var target = new ToDoTask { Location = expected };
            var actual = target.Location;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToDoTaskDateTest()
        {
            // Testing the setter and getter of the Date property.
            var expected = new DateTime(2015, 2, 3);
            var target = new ToDoTask { Date = expected };
            var actual = target.Date;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToDoTaskStatusTest()
        {
            // Testing the setter and getter of the Status property.
            const TaskStatus expected = TaskStatus.Canceled;
            var target = new ToDoTask { Status = expected };
            var actual = target.Status;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToDoTaskIsValidTrue1Test()
        {
            // It is true when it is Canceled (check first condition), regardless the date
            var target = new ToDoTask
            {
                Status = TaskStatus.Canceled
            };
            Assert.IsTrue(target.IsValild);
        }

        [TestMethod]
        public void ToDoTaskIsValidTrue2Test()
        {
            // It is true when it is Active on the same date (check second condition for ==)
            var target = new ToDoTask
            {
                Date = DateTime.Now,
                Status = TaskStatus.Active
            };
            Assert.IsTrue(target.IsValild);
        }

        [TestMethod]
        public void ToDoTaskIsValidTrue3Test()
        {
            // It is true when it is Active in the future (check second condition for >)
            var target = new ToDoTask
            {
                Date = DateTime.Now.AddDays(1),
                Status = TaskStatus.Active
            };
            Assert.IsTrue(target.IsValild);
        }

        [TestMethod]
        public void ToDoTaskIsValidTrue4Test()
        {
            // It is true when it is Done in the past (check second condition for <)
            var target = new ToDoTask
            {
                Date = DateTime.Now.AddDays(-1),
                Status = TaskStatus.Done
            };
            Assert.IsTrue(target.IsValild);
        }

        [TestMethod]
        public void ToDoTaskIsValidTrue5Test()
        {
            // It is true when it is Done on the same day (check second condition for ==)
            var target = new ToDoTask
            {
                Date = DateTime.Now,
                Status = TaskStatus.Done
            };
            Assert.IsTrue(target.IsValild);
        }

        [TestMethod]
        public void ToDoTaskIsValidFalse1Test()
        {
            // It is false when it is Active in the past
            var target = new ToDoTask
            {
                Date = DateTime.Now.AddDays(-1),
                Status = TaskStatus.Active
            };
            Assert.IsFalse(target.IsValild);
        }

        [TestMethod]
        public void ToDoTaskIsValidFalse2Test()
        {
            // It is false when it is Done in the future
            var target = new ToDoTask
            {
                Date = DateTime.Now.AddDays(1),
                Status = TaskStatus.Done
            };
            Assert.IsFalse(target.IsValild);
        }

        [TestMethod]
        public void ToDoTaskDeepCopyTest()
        {
            const string expectedTitle = "title";
            const string expectedDescription = "desc";
            const string expectedLocation = "location";
            var target = new ToDoTask
            {
                Title = expectedTitle,
                Description = expectedDescription,
                Location = expectedLocation,
                Date = DateTime.Now.AddDays(-20),
                Status = TaskStatus.Done
            };

            var actual = target.DeepCopy();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedTitle, actual.Title, "Title");
            Assert.AreEqual(expectedDescription, actual.Description, "Description");
            Assert.AreEqual(expectedLocation, actual.Location, "Location");
            Assert.AreEqual(DateTime.Now.Date, actual.Date.Date, "Date");
            Assert.AreEqual(TaskStatus.Active, actual.Status, "Status");
        }

        [TestMethod]
        public void ToDoTaskToStringTest()
        {
            const string expectedTitle = "title";
            const string expectedDescription = "desc";
            const string expectedLocation = "location";
            var dt = new DateTime(2015, 3, 4);
            var status = TaskStatus.Canceled;

            var target = new ToDoTask
            {
                Title = expectedTitle,
                Description = expectedDescription,
                Location = expectedLocation,
                Date = dt,
                Status = status
            };

            var actual = target.ToString();
            var expected = string.Format($"Title: {expectedTitle}{0}Description: {expectedDescription}{0}Location: {expectedLocation}{0}Date: {dt.Date.ToShortDateString()}{0}Status: {status}", Environment.NewLine);
            Assert.AreEqual(expected, actual);
        }
    }
}
