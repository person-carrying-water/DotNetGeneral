using global::Microsoft.VisualBasic;

namespace General
{
    /// <summary>共通ロジッククラス</summary>
    /// <remarks></remarks>
    public class GeneralLogic
    {
        #region "メソッド"
        /// <summary>nullであるならstring.Empty(空文字)に変換します</summary>
        /// <param name="str">変換させる文字列</param>
        /// <returns>変換された文字列</returns>
        public static string NullToEmpty(string? str)
        {
            if (str == null)
                str = string.Empty;

            return str;
        }

        /// <summary>文字列内の全角英数字をすべて半角へ変換します。nullはnullで返します</summary>
        /// <param name="str">変換させる文字列</param>
        /// <returns>半角に変換された文字列</returns>
        public static string? WideToNarrow(string? str)
        {
            if (str != null)
            {
                //System.NotSupportedExceptionが出るためカスタムエンコーディングの定義に932を追加？
                global::System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                str = Strings.StrConv(str, Conversion: VbStrConv.Narrow);
            }

            return str;
        }

        /// <summary>文字列の配列をリスト化したものを文字列の２次元配列へ変換します。</summary>
        /// <param name="list">IEnumerabe<string[]></param>
        /// <returns>２次元配列</returns>
        public static string[][] ListInArrayTo2Array(IEnumerable<string[]> list)
        {
            return list.ToArray();
        }

        /// <summary>文字列の２次元リストを文字列の２次元配列へ変換します。</summary>
        /// <param name="list">IEnumerable<IEnumerable<string>></param>
        /// <returns>２次元配列</returns>
        public static string[][] ListInListTo2Array(IEnumerable<IEnumerable<string>> list)
        {
            return list.Select(x => x.ToArray()).ToArray();
        }

        //Replaceで空白削除
        #endregion
    }
}