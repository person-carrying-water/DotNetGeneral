using global::Xunit;
using global::General;

// 参照の追加で共有プロジェクトに表示されるGeneralプロジェクトのチェックボックスをONにする事

namespace GeneralTest
{
    /// <summary>General.GeneralLogicクラスのテスト</summary>
    /// <remarks></remarks>
    public class GeneralLogicTest
    {
        #region "メソッド"
        [global::Xunit.TheoryAttribute]
        [global::Xunit.InlineDataAttribute(null, "")]
        [InlineData("", "")]
        private void NullToEmptyTest(string? before, string? after)
        {
            string data = global::General.GeneralLogic.NullToEmpty(before);

            global::Xunit.Assert.Equal(after, data);
        }

        [Theory]
        [InlineData("１２３", "123")]
        [InlineData("ＷＩＤＥ", "WIDE")]
        private void WideToNarrowTest(string? before, string? after)
        {
            string? data = GeneralLogic.WideToNarrow(before);

            Assert.Equal(after, data);
        }
        #endregion
    }
}
