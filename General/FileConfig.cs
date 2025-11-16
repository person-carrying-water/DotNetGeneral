using global::System.Text;
using global::System.Text.Json.Serialization;

namespace General
{
    /// <summary>ファイル情報格納基底クラス
    /// <para>※抽象クラスのためインスタンス化できません</para></summary>
    /// <remarks></remarks>
    [global::System.SerializableAttribute]
    [global::System.Xml.Serialization.XmlRootAttribute("FileConfig")]
    [global::System.Runtime.Serialization.DataContractAttribute(Namespace = "", Name = "FileConfig")]
    public abstract class FileConfig
    {
        #region "フィールド"
        [global::System.NonSerializedAttribute]
        protected string _FilePath = string.Empty;
        [NonSerialized] protected string _FileExtension = default!;
        #endregion

        #region "定数"
        protected const string FILE_PATH = "FilePath";
        protected const string FILE_NAME_EXTENSION = "FileNameExtension";
        [NonSerialized] protected const Encode ENC_DEF = Encode.UTF8N;
        #endregion

        #region "メソッド"
        ///<summary>文字コードをセットします</summary>
        ///<param name="code">文字コード指定</param>
        ///<returns>System.Text.Encoding</returns>
        ///<remarks></remarks>
        public static global::System.Text.Encoding SetEncode(Encode code)
        {
            global::System.Text.Encoding enc = Encoding.Default;

            switch (code)
            {
                case Encode.ShiftJIS:
                    enc = global::System.Text.Encoding.GetEncoding("shift-jis");
                    break;
                case Encode.UTF8:
                    enc = global::System.Text.Encoding.GetEncoding("utf-8");
                    break;
                case Encode.UTF8N: //BOMなし
                    //enc = global::System.Text.Encoding.GetEncoding("utf-8n");
                    enc = new UTF8Encoding(false);
                    break;
            }

            return enc;
        }

        /// <summary>ファイル名に拡張子を含んでいるかチェック</summary>
        /// <returns>含んでいる=true / 含まれていない=false</returns>
        /// <returns></returns>
        public static bool FileExtensionCheck(string str)
        {
            return global::System.IO.Path.HasExtension(str);
        }
        #endregion

        #region "プロパティ"
        [global::System.Xml.Serialization.XmlElementAttribute(ElementName = FILE_PATH, Order = 0)]
        [global::System.Runtime.Serialization.DataMemberAttribute(Name = FILE_PATH, Order = 0)]
        [global::System.Text.Json.Serialization.JsonPropertyName(FILE_PATH)]
        [global::System.Text.Json.Serialization.JsonPropertyOrder(0)]
        public string FilePath
        {
            get => _FilePath;
            set => _FilePath = value;
        }

        [global::System.Xml.Serialization.XmlElementAttribute(ElementName = FILE_NAME_EXTENSION, Order = 1)]
        [global::System.Runtime.Serialization.DataMemberAttribute(Name = FILE_NAME_EXTENSION, Order = 1)]
        [JsonPropertyName(FILE_NAME_EXTENSION)]
        [JsonPropertyOrder(1)]
        public string FileExtension
        {
            get => _FileExtension;
            set => _FileExtension = value;
        }
        #endregion
    }

    ///<summary>文字コード指定・列挙型</summary>
    ///<remarks>UTF8N=BOMなし</remarks>
    public enum Encode
    {
        ShiftJIS = 932,
        MacJapan = 10001,
        IBM290 = 20290,
        EUCjp1990 = 20932,
        ISO2022jp = 50220,
        csISO2022JP = 50221,
        CP50222 = 50222,
        EUCjp = 51932,
        UTF7 = 65000,
        UTF8 = 65001,
        UTF8N = 65002,
        UTF16 = 1200,
        UTF16BE = 1201,
        UTF32 = 12000,
        UTF32BE = 12001,
        USascii = 20127
    }
}