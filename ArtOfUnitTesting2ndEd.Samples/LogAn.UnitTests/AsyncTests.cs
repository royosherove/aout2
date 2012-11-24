using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    //PRODUCTION CODE
    public class ClassUnderTest
    {
        public static void ReturnAfter500ms(int value, Action<int> result)
        {
            TaskFacility.Factory.StartNew(() =>
            {
                Thread.Sleep(500);
                result(value);
            });
        }
    }


    public class TaskFacility
    {
        private static TaskFactory _factory;

        public static void Reset()
        {
            Factory = Task.Factory;
        }

        public static TaskFactory Factory
        {
            get { if (_factory == null) return Task.Factory;
                return _factory;
            }
             set
             {
                 _factory = value;
             } }    
    }



    // TEST CODE
    [TestFixture]
    class AsyncTests
    {
        [Test]
        public void TestAsync()
        {
            var tasks = new TaskFactory(new CancellationTokenSource().Token, TaskCreationOptions.AttachedToParent, 
                                        TaskContinuationOptions.ExecuteSynchronously,TaskScheduler.Default);
            TaskFacility.Factory = tasks;

            ClassUnderTest.ReturnAfter500ms(3,i => Console.WriteLine(i));

        }
        
    }


}
