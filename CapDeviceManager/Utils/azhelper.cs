﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CapDeviceManager.Utils
{
    public class AzHelper
    {
        public static StringBuilder azOutput = new StringBuilder();
        public static StringBuilder azError = new StringBuilder();
        public static Process azProcess = null;

        private static Task WaitForExitAsync(Process process,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var tcs = new TaskCompletionSource<object>();
            process.EnableRaisingEvents = true;
            process.Exited += (sender, args) => tcs.TrySetResult(null);
            if (cancellationToken != default(CancellationToken))
                cancellationToken.Register(tcs.SetCanceled);

            return tcs.Task;
        }

        public static async void AzLoginWithDeviceCode()
        {
            try
            {
                //Logout the User
                AzLogoutUser();

                //Clear All the Account
                AzClearAccounts();

                azOutput.Clear();
                azError.Clear();
                azProcess = new Process();
                //azProcess.StartInfo.WorkingDirectory = @"c:\Program Files (x86)\Microsoft SDKs\Azure\CLI2";
                //azProcess.StartInfo.FileName = "python.exe";
                //azProcess.StartInfo.Arguments = "-IBm azure.cli login --use-device-code";

                azProcess.StartInfo.WorkingDirectory = @"c:\Program Files (x86)\Microsoft SDKs\Azure\CLI2\wbin";
                azProcess.StartInfo.FileName = "az.cmd";
                azProcess.StartInfo.Arguments = "login --use-device-code";

                azProcess.StartInfo.CreateNoWindow = true;
                azProcess.StartInfo.UseShellExecute = false;
                azProcess.StartInfo.RedirectStandardOutput = true;
                azProcess.StartInfo.RedirectStandardError = true;
                azProcess.OutputDataReceived += (sender, data) =>
                {
                    azOutput.Append(data.Data);
                    Debug.WriteLine("Output: " + data.Data);
                };
                azProcess.ErrorDataReceived += (sender, data) =>
                {
                    azError.Append(data.Data);
                    Debug.WriteLine("Error: " + data.Data);
                };

                azProcess.Start();
                azProcess.BeginOutputReadLine();
                azProcess.BeginErrorReadLine();
                await WaitForExitAsync(azProcess);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message.ToString());
            }
        }

        public static void AzAccountGetAccessToken()
        {
            try
            {
                azOutput.Clear();
                azError.Clear();

                azProcess = new Process();

                azProcess.StartInfo.WorkingDirectory = @"c:\Program Files (x86)\Microsoft SDKs\Azure\CLI2\wbin";
                azProcess.StartInfo.FileName = "az.cmd";
                azProcess.StartInfo.Arguments = "account get-access-token --output jsonc";

                azProcess.StartInfo.CreateNoWindow = true;
                azProcess.StartInfo.UseShellExecute = false;
                azProcess.StartInfo.RedirectStandardOutput = true;
                azProcess.StartInfo.RedirectStandardError = true;
                azProcess.OutputDataReceived += (sender, data) =>
                {
                    azOutput.Append(data.Data);
                    Debug.WriteLine("Output: " + data.Data);
                };
                azProcess.ErrorDataReceived += (sender, data) =>
                {
                    azError.Append(data.Data);
                    Debug.WriteLine("Error: " + data.Data);
                };

                azProcess.Start();
                azProcess.BeginOutputReadLine();
                azProcess.BeginErrorReadLine();
                azProcess.WaitForExit();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message.ToString());
            }
        }

        public static void AzAccountDetails()
        {
            try
            {
                azOutput.Clear();
                azError.Clear();

                azProcess = new Process();

                azProcess.StartInfo.WorkingDirectory = @"c:\Program Files (x86)\Microsoft SDKs\Azure\CLI2\wbin";
                azProcess.StartInfo.FileName = "az.cmd";
                azProcess.StartInfo.Arguments = "account show --output jsonc";

                azProcess.StartInfo.CreateNoWindow = true;
                azProcess.StartInfo.UseShellExecute = false;
                azProcess.StartInfo.RedirectStandardOutput = true;
                azProcess.StartInfo.RedirectStandardError = true;
                azProcess.OutputDataReceived += (sender, data) =>
                {
                    azOutput.Append(data.Data);
                    Debug.WriteLine("Output: " + data.Data);
                };
                azProcess.ErrorDataReceived += (sender, data) =>
                {
                    azError.Append(data.Data);
                    Debug.WriteLine("Error: " + data.Data);
                };

                azProcess.Start();
                azProcess.BeginOutputReadLine();
                azProcess.BeginErrorReadLine();
                azProcess.WaitForExit();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message.ToString());
            }
        }

        public static void AzLogoutUser()
        {
            try
            {
                azOutput.Clear();
                azError.Clear();

                azProcess = new Process();

                azProcess.StartInfo.WorkingDirectory = @"c:\Program Files (x86)\Microsoft SDKs\Azure\CLI2\wbin";
                azProcess.StartInfo.FileName = "az.cmd";
                azProcess.StartInfo.Arguments = "logout --output jsonc";

                azProcess.StartInfo.CreateNoWindow = true;
                azProcess.StartInfo.UseShellExecute = false;
                azProcess.StartInfo.RedirectStandardOutput = true;
                azProcess.StartInfo.RedirectStandardError = true;
                azProcess.OutputDataReceived += (sender, data) =>
                {
                    azOutput.Append(data.Data);
                    Debug.WriteLine("Output: " + data.Data);
                };
                azProcess.ErrorDataReceived += (sender, data) =>
                {
                    azError.Append(data.Data);
                    Debug.WriteLine("Error: " + data.Data);
                };

                azProcess.Start();
                azProcess.BeginOutputReadLine();
                azProcess.BeginErrorReadLine();
                azProcess.WaitForExit();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message.ToString());
            }
        }

        public static void AzGetSubscription()
        {
            try
            {
                azOutput.Clear();
                azError.Clear();
                azProcess = new Process();

                azProcess.StartInfo.WorkingDirectory = @"c:\Program Files (x86)\Microsoft SDKs\Azure\CLI2\wbin";
                azProcess.StartInfo.FileName = "az.cmd";
                azProcess.StartInfo.Arguments = "account list --output jsonc";

                azProcess.StartInfo.CreateNoWindow = true;
                azProcess.StartInfo.UseShellExecute = false;
                azProcess.StartInfo.RedirectStandardOutput = true;
                azProcess.StartInfo.RedirectStandardError = true;
                azProcess.OutputDataReceived += (sender, data) =>
                {
                    azOutput.Append(data.Data);
                    Debug.WriteLine("Output: " + data.Data);
                };
                azProcess.ErrorDataReceived += (sender, data) =>
                {
                    azError.Append(data.Data);
                    Debug.WriteLine("Error: " + data.Data);
                };

                azProcess.Start();
                azProcess.BeginOutputReadLine();
                azProcess.BeginErrorReadLine();
                azProcess.WaitForExit();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message.ToString());
            }
        }
        public static void AzClearAccounts()
        {
            try
            {
                azOutput.Clear();
                azError.Clear();
                azProcess = new Process();

                azProcess.StartInfo.WorkingDirectory = @"c:\Program Files (x86)\Microsoft SDKs\Azure\CLI2\wbin";
                azProcess.StartInfo.FileName = "az.cmd";
                azProcess.StartInfo.Arguments = "account clear";

                azProcess.StartInfo.CreateNoWindow = true;
                azProcess.StartInfo.UseShellExecute = false;
                azProcess.StartInfo.RedirectStandardOutput = true;
                azProcess.StartInfo.RedirectStandardError = true;
                azProcess.OutputDataReceived += (sender, data) =>
                {
                    azOutput.Append(data.Data);
                    Debug.WriteLine("Output: " + data.Data);
                };
                azProcess.ErrorDataReceived += (sender, data) =>
                {
                    azError.Append(data.Data);
                    Debug.WriteLine("Error: " + data.Data);
                };

                azProcess.Start();
                azProcess.BeginOutputReadLine();
                azProcess.BeginErrorReadLine();
                azProcess.WaitForExit();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message.ToString());
            }
        }
    }
}
