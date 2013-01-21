using System;
using NSubstitute;
using NUnit.Framework;

namespace Examples.Tests.Inherited
{
    public class BaseTestClass
    {
        [SetUp]
        public virtual void Setup()
        {
            Console.WriteLine("in setup");
            LoggingFacility.Logger = Substitute.For<ILogger>();
        }
    }
}