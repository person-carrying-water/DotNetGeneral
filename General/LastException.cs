using global::System.Text;
using global::System.IO;

namespace General
{
    /// <summary>最新の例外格納クラス</summary>
    /// <remarks></remarks>
    public abstract class LastException
    {
        #region "フィールド"
        protected static string _LastExcepTitle = string.Empty;
        protected static string _LastExcepPlace = string.Empty;
        protected static string _LastExcepParam = string.Empty;
        protected static string _LastExcepMessage = string.Empty;
        protected static string? _LastExcepTrace = string.Empty;
        #endregion

        #region "コンストラクタ"
        /// <summary>デフォルトコンストラクタ</summary>
        /// <remarks></remarks>>
        public LastException()
        {

        }
        #endregion

        #region "メソッド"
        /// <summary>最新の例外情報をセットします</summary>
        /// <param name="title">例外のクラス名</param>
        /// <param name="method">例外が発生したメソッド</param>
        /// <param name="param">例外の発生したメソッドが引き受けた引数、参考値など</param>
        /// <param name="ex">Exceptionまたは派生クラス</param>
        /// <remarks></remarks>
        public static void SetLastException(string title, string method, string param, Exception ex)
        {
            _LastExcepTitle = title;
            _LastExcepPlace = method;
            _LastExcepParam = param;
            _LastExcepMessage = ex.Message;
            _LastExcepTrace = ex.StackTrace;
        }

        /// <summary>例外ログの書き込み</summary>
        /// <remarks></remarks>
        public static void LogWrite()
        {
            var LogStr = $"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}:{_LastExcepTitle}{Environment.NewLine}";
            LogStr += $"例外メッセージ：{_LastExcepMessage}{Environment.NewLine}";
            LogStr += $"スタックトレース：{_LastExcepTrace}{Environment.NewLine}";
            File.AppendAllText(@"Exceptionlog.txt", LogStr, Encoding.Default);
        }
        #endregion

        #region "プロパティ"

        /// <summary>最新の例外のクラス名が格納されます</summary>
        /// <returns></returns>
        public static string LastExcepTitle
        {
            get => _LastExcepTitle;
            set => _LastExcepTitle = value;
        }

        /// <summary>最新の例外のメソッド名が格納されます</summary>
        /// <returns></returns>
        public static string LastExcepPlace
        {
            get => _LastExcepPlace;
            set => _LastExcepPlace = value;
        }

        /// <summary>最新の例外のパラメータが格納されます
        /// <para>(メソッドに与えた引数や参考になる情報など)</para></summary>
        /// <returns></returns>
        public static string LastExcepParam
        {
            get => _LastExcepParam;
            set => _LastExcepParam = value;
        }

        /// <summary>最新の例外のメッセージが格納されます</summary>
        /// <returns></returns>
        public static string LastExcepMessage
        {
            get => _LastExcepMessage;
            set => _LastExcepMessage = value;
        }

        /// <summary>最新の例外のスタックトレースが格納されます</summary>
        /// <remarks></remarks>
        public static string? LastExcepTrace
        {
            get => _LastExcepTrace;
            set => _LastExcepTrace = value;
        }
        #endregion
    }
}