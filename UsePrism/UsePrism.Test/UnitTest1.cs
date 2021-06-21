using Microsoft.VisualStudio.TestTools.UnitTesting;
using UsePrism.ViewModels;

namespace UsePrism.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var vm = new MainPageViewModel(null);
            Assert.AreEqual("DDD", vm.LabelC);
            vm.ButtonC.Execute();
            Assert.AreEqual("EEE", vm.LabelC);
        }
    }
}
