using System;
using Chapter5.LogAn;
using NSubstitute;
using NUnit.Framework;

namespace NSubExamples
{
    [TestFixture]
    public class NSubBasics
    {
        [Test]
        public void SubstituteFor_ForInterfaces_ReturnsAFakeInterface()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            Assert.IsFalse(fakeRules.IsValidLogFileName("something.bla"));
        }
        [Test]
        public void Returns_ArgAny_IgnoresArgument()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            fakeRules.IsValidLogFileName(Arg.Any<string>()).Returns(true);
              
            Assert.IsTrue(fakeRules.IsValidLogFileName("anything, really"));
        }
        
        [Test]
        public void Returns_ArgAny_Throws()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            fakeRules.When(x => x.IsValidLogFileName(Arg.Any<string>()))
                     .Do(x => { throw new Exception("fake exception"); });


            Assert.Throws<Exception>(() =>
                                     fakeRules.IsValidLogFileName("anything"));

        }
        
        
        [Test]
        public void Returns_ByDefault_WorksForHardCodedArgument()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            fakeRules.IsValidLogFileName("file.name").Returns(true);
            
            Assert.IsTrue(fakeRules.IsValidLogFileName("file.name"));
        }
        
        [Test]
        public void RecursiveFakes()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            fakeRules.IsValidLogFileName("file.name").Returns(true);
            
            Assert.IsTrue(fakeRules.IsValidLogFileName("file.name"));
        }
        [Test]
        public void RecursiveFakes_work()
        {
            IPerson p = Substitute.For<IPerson>();

            Assert.IsNotNull(p.GetManager());
            Assert.IsNotNull(p.GetManager().GetManager());
            Assert.IsNotNull(p.GetManager().GetManager().GetManager());
        }

        public interface IPerson
        {
            IPerson GetManager();
        }
    }
}
