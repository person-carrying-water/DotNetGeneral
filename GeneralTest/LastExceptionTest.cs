using global::Xunit;
using global::System.Reflection;
using global::General;

namespace GeneralTest
{
    public class LastExceptionTest
    {
        [Fact]
        private void SetLastExceptionTest()
        {

        }

        [Fact]
        private void LogWriteTest()
        {

        }

        /// <summary>フィールド初期値チェックテスト(stringのみ)</summary>
        /// <param name="str"></param>
        [Theory(DisplayName = "フィールド初期値チェックテスト")]
        [InlineData("_LastExcepTitle")]
        [InlineData("_LastExcepPlace")]
        private void LastExcepTitleTest(string str)
        {
            Type type = typeof(LastException);
            LastException la = null;

            FieldInfo finfo = type.GetField(str, BindingFlags.NonPublic | BindingFlags.Static);
            string? data = finfo.GetValue(la).ToString();

            Assert.Equal(string.Empty, data);
        }
    }
}
