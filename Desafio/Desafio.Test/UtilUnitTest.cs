using Desafio.Core.Util;

namespace Desafio.Test
{
    public class UtilUnitTest
    {
        [Fact]
        public void TestGetDate()
        {
            DateTime inDate = new DateTime(2020, 03, 15, 22, 37, 58, 678, 547);

            DateTime expOutDate1 = new DateTime(2020, 03, 15, 0, 0, 0, 0,0);
            DateTime expOutDate2 = new DateTime(2020, 03, 15, 23, 59, 59, 999, 999);

            DateTime outDate1 = DatetimeUtil.getDate(inDate);
            DateTime outDate2 = DatetimeUtil.getDate(inDate, false);

            Assert.Equal(expOutDate1, outDate1);
            Assert.Equal(expOutDate2, outDate2);
        }
    }
}