using System;
using System.Windows.Forms;

namespace SyncContextDemo
{
    public sealed partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void button1_Click(object sender, EventArgs e)
        {

            var backupVentTest = new BackupVentTest();
            // Run the test within the thread synchronizer to make sure your callback
            // gets called on the appropriate thread.
            backupVentTest.RunTestAsync(OnBackupVentTestResult);
        }

        void OnBackupVentTestResult(BackupVentTestResult result)
        {
            Text = "Value = " + result.SomeValue;
        }
    }
}