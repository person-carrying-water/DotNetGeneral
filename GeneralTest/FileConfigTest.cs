using global::Xunit;
using global::System.IO;
using global::System.Text;
using global::General;

namespace GeneralTest
{
    public class FileConfigTest
    {
        [Theory]
        [InlineData("file.txt")]
        private void FileExtensionCheckTest(string str)
        {
            bool data = FileConfig.FileExtensionCheck(str);

            Assert.True(data);
        }

        [Theory]
        [InlineData(Encode.UTF8)]
        private void SetEncodeTest(Encode enc)
        {
            Encoding data = FileConfig.SetEncode(enc);

            Assert.Equal(Encoding.UTF8, data);
        }
    }
}
