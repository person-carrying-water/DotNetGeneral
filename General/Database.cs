using global::System.Data;
using System.Text;

namespace General
{
    /// <summary>ADO.NET基底クラス</summary>
    /// <remarks></remarks>
    public abstract class Database : LastException
    {
        #region "フィールド"
        protected string _Host = string.Empty;
        protected string _Instance = string.Empty;
        protected ushort _Port = 0;
        protected string _Catalog = string.Empty;
        protected string _UserID = string.Empty;
        protected string _Password = string.Empty;
        #endregion

        #region "抽象メソッド"

        protected abstract void ConecString();
        public abstract void Connect();

        public abstract Task ConnectAsync();

        public abstract void Disconnect();

        public abstract Task DisconnectAsync();

        public abstract global::System.Data.DataTable DataAdapter(string SelectSql);

        public abstract IEnumerable<IDictionary<string, string>> DataReader(string SelectSql);

        public abstract Task<IEnumerable<IDictionary<string, string>>> DataExtractAsync(string SelectSql);

        public abstract IEnumerable<DTO> DataReader<DTO>(string SelectSql) where DTO : class, new();

        public abstract Task<IEnumerable<DTO>> DataExtractAsync<DTO>(string SelectSql) where DTO : class, new();

        public abstract int Scalar(string ScalarSql);
        public abstract void ParametersClear();
        public abstract void SetParameters(string name, SqlDbType type, int size, object value);
        public abstract int DataUpdate(string updateSql);

        public abstract Task<int> DataUpdateAsync(string updateSql);

        #endregion

        #region "プロパティ"
        /// <summary>ホスト名(サーバー名)またはIPアドレス</summary>
        /// <returns>ホスト名(サーバー名)またはIPアドレス</returns>
        /// <remarks>サーバー／クライアント型のみ必要</remarks>
        public string Host
        {
            get => _Host;
            set => _Host = value;
        }

        /// <summary>インスタンス名</summary>
        /// <returns>インスタンス名</returns>
        /// <remarks>サーバー／クライアント型のみ必要</remarks>
        public string Instance
        {
            get => _Instance;
            set => _Instance = value;
        }

        /// <summary>ネットワーク ポート番号</summary>
        /// <returns>ネットワーク ポート番号</returns>
        /// <remarks>ローカルホスト接続の場合は自動的に無効とします</remarks>
        public ushort Port
        {
            get => _Port;
            set => _Port = value;
        }

        /// <summary>データベース名</summary>
        /// <returns>データベース名</returns>
        /// <remarks></remarks>
        public string Catalog
        {
            get => _Catalog;
            set => _Catalog = value;
        }

        /// <summary>ログインユーザー名</summary>
        /// <returns>ユーザー名</returns>
        /// <remarks>OS統合認証の場合は必要ありません</remarks>
        public string UserID
        {
            get => _UserID;
            set => _UserID = value;
        }

        /// <summary>ログインパスワード</summary>
        /// <returns>パスワード</returns>
        /// <remarks>パスワード認証が無い場合は必要ありません</remarks>
        public string Password
        {
            get => _Password;
            set => _Password = value;
        }
        #endregion
    }
}