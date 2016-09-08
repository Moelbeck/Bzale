using biz2biz.Enums;
using biz2biz.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class TestServiceClasses
    {
        private AccountService _accountService;
        private ImageService _imageService;

        public TestServiceClasses()
        {
            _accountService = new AccountService();
            _imageService = new ImageService();
        }
        [TestMethod]
        public void TestVATChecker()
        {
            
            //string validVAT = "78161418"; //Kreativ Marketing
            string validVAT = "83179813"; //randi a/s
            var obj = _accountService.ValidateVAT("DK", validVAT);
            Assert.IsTrue(obj.IsValid);
        }

        [TestMethod]
        public void TestCreateAndGetFolder()
        {
            var newfolder = _imageService.GetFolder(eImageType.JobCategory);
            Assert.IsNotNull(newfolder);
        }
    }
}
