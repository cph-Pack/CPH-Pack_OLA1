using CPH_Pack_OLA1;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Unit_Test_Ola_1
{
    public class UnitTest1
    {
        [Fact]
        public void TestHellow()
        {
            Hellow program = new Hellow();
            string h = program.writeHellow();

            Assert.Equal("kk", h);
        }
    }
}