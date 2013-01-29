using System;
using System.Threading;

namespace SyncContextDemo
{
    sealed class BackupVentTest : ITest<BackupVentTestResult>
    {
        static readonly Random RandGen = new Random();

        public BackupVentTestResult Run()
        {
            // Pretend we're doing something
            Thread.Sleep(1000);
            // See this just runs synchronouosly; we don't have to
            // worry about switching thread contexts from the
            // test class itself.  Ahhh....nice.
            return new BackupVentTestResult(RandGen.NextDouble());
        }
    }

    public struct BackupVentTestResult
    {
        public readonly double SomeValue;

        public BackupVentTestResult(double d)
        {
            SomeValue = d;
        }
    }
}