using NUnit.Framework;
using Rhino.Mocks;

namespace Logic.Test
{
    [TestFixture]
    public class CoordinatorTest
    {
        private MockRepository repository;
        private AbstractAction act; 

        [SetUp]
        public void SetUp()
        {
            repository=new MockRepository();
            act = repository.CreateMock<AbstractAction>();
        }

        [Test]
        public void AddActionTest()
        {
            Coordinator coord=new Coordinator();
            repository.ReplayAll();
            coord.AddAction(act);
            repository.VerifyAll();
            Assert.AreEqual(1,coord.runningActions.Count);
            
        }
        [Test]
        public void RunTest()
        {
            Coordinator coord = new Coordinator();
            act.Run();
            repository.ReplayAll();
            coord.AddAction(act);
            coord.Run();
            repository.VerifyAll();
            //Assert.AreEqual(false, coord.Canceled);
        }

        [Test]
        public void CancelTest()
        {
            Coordinator coord = new Coordinator();
            act.Cancel();
            repository.ReplayAll();
            coord.currAction = act;
            coord.Cancel();
            repository.VerifyAll();
            //Assert.AreEqual(true,coord.Canceled);
        }

        [Test]
        public void GetActionsTest()
        {
            Coordinator coord = new Coordinator();
            Expect.Call(act.Name()).Return("Тест");
            repository.ReplayAll();
            coord.AddAction(act);
            string[] str = coord.GetActions();
            repository.VerifyAll();
            Assert.AreEqual("Тест", str[0]);
        }
    }
}
