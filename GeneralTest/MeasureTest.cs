using global::Xunit;
using global::Xunit.Abstractions;
using global::General;
using System;
using System.Collections.Generic;
using System.Text;


namespace GeneralTest
{
    public class MeasureTest : IDisposable, IClassFixture<FixtureData>
    {
        #region "フィールド"
        private FixtureData _fixture;
        private Xunit.Abstractions.ITestOutputHelper? help;
        private const int SLEEP_DATA1 = 1500;
        private const int OFFSET = 50;
        private const string CATEGORY = $"カテゴリー";
        private const string SLEEP = $"スリープ";
        private const string STOPWATCH = $"ストップウォッチ";
        #endregion

        #region "テストメソッドごとの開始処理、終了処理"
        /// <summary>テストメソッド共通開始処理</summary>
        /// <param name="helper">テストダイアログメッセージのためのヘルパー</param>
        public MeasureTest(ITestOutputHelper helper, FixtureData fixture)
        {
            _fixture = fixture;
            help = helper;
            Measure.StopwatchStart();
        }

        /// <summary>テストメソッド共通終了処理</summary>
        /// <remarks>IDisposable実装メソッド</remarks>
        public void Dispose()
        {
            var time = Measure.StopwatchStop();
            var milli = time.TotalMilliseconds;
            help!.WriteLine($"実行時間は、{time:mm'分'ss'秒'fffffff}です。");
            help!.WriteLine($"ミリ実行時間は、{milli}ミリ秒です。");
        }
        #endregion

        #region "テストメソッド"
        private bool RangeJadge(double milli)
        {
            if (milli < SLEEP_DATA1 + OFFSET && milli > SLEEP_DATA1 - OFFSET)
            {
                return true;
            }

            return false;
        }

        [Theory(DisplayName = "ApiSleepテスト")]
        [Trait(CATEGORY, SLEEP)]
        [InlineData(SLEEP_DATA1)]
        public void ApiSleep(int param)
        {
            Measure.StopwatchStart();
            Measure.ApiSleep((uint)param);
            var time = Measure.StopwatchStop();

            Assert.True(RangeJadge(time.TotalMilliseconds));
        }

        [Theory(DisplayName = "DateTimeDiffテスト")]
        [Trait(CATEGORY, STOPWATCH)]
        [InlineData(SLEEP_DATA1)]
        public void DateTimeDiffTest(int param)
        {
            Measure.DateTimeStart();
            Thread.Sleep(param);
            var time = Measure.DateTimeStop();

            Assert.True(RangeJadge(time.TotalMilliseconds));
        }

        [Theory(DisplayName = "Stopwatchテスト")]
        [Trait(CATEGORY, STOPWATCH)]
        [InlineData(SLEEP_DATA1)]
        public void StopwatchTest(int param)
        {
            Measure.StopwatchStart();
            Thread.Sleep(param);
            var time = Measure.StopwatchStop();

            Assert.True(RangeJadge(time.TotalMilliseconds));
        }

        [Theory(DisplayName = "QueryPerformanceCouonterテスト")]
        [Trait(CATEGORY, STOPWATCH)]
        [InlineData(SLEEP_DATA1)]
        public void QueryPerformanceCounterTest(int param)
        {
            Measure.QueryPerformanceStart();
            Thread.Sleep(param);
            var time = Measure.QueryPerformanceStop();

            Assert.True(RangeJadge(time.TotalMilliseconds));
        }

        [Theory(DisplayName = "TimeLoopテスト")]
        [Trait(CATEGORY, SLEEP)]
        [InlineData(SLEEP_DATA1)]
        public void TimeLoop(int param)
        {
            Measure.TimeLoop(param);
        }
        #endregion
    }
}
