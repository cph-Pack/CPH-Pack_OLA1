using CPH_Pack_OLA1;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Unit_Test_Ola_1
{
    public class UnitTest1
    {
        [Fact]
        public void AddTaskTest()
        {

        }

        [Fact]
        public void SuccessTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        [Fact]
        public void FailTest()
        {
            Assert.NotEqual(5, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}