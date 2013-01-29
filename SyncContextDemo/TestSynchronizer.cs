using System;
using System.Threading;

namespace SyncContextDemo
{
    // This class wraps all thread context switching so nobody else has to worry about it.
    public static class TestSynchronizer
    {
        // This should be run from the GUI thread.
        public static void RunTestAsync<T>(this ITest<T> test, Action<T> finishedCallback)
        {
            // Get the current context; presumably the GUI that you want to post back to
            var guiContext = SynchronizationContext.Current;

            // Run the test in a new thread so the UI doesn't get blocked.
            new Thread(() =>
            {
                var result = test.Run();
                // Post a message to the GUI thread to 
                // run the callback function with the result
                guiContext.Post(_ => finishedCallback(result), null);
            }).Start();
        }
    }
}