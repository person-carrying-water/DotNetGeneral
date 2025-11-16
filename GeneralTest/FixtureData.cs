using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GeneralTest
{
    /// <summary>フィクスチャ(IClassFixture)とサンプルデータ併用クラス</summary>
    /// <remarks></remarks>
    public class FixtureData : IDisposable, IEnumerable<object[]>
    {
        #region "開始処理、終了処理"
        public FixtureData()
        {
            //テストクラスの最初の１回だけ実行させる
        }
        public void Dispose()
        {
            //テスト最初の１度のみの後処理
            //throw new NotImplementedException();
        }
        #endregion

        #region "テストデータ"
        /// <summary>ClassDataAttributeで指定してテストするサンプルを提供します</summary>
        /// <returns></returns>
        public IEnumerator<object[]> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
