﻿using System;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Timers;

namespace CapDeviceManager.Utils
{
    public class BashHelper
    {
        public static StringBuilder bashOutput = new StringBuilder();
        public static StringBuilder bashError = new StringBuilder();
        public static Process bashProcess = null;

        public static void BashProcessExecute(string arguments)
        {
            try
            {
                bashOutput.Clear();
                bashError.Clear();
                bashProcess = new Process();
                /*
                 * ProcessStartInfo psi = new ProcessStartInfo(@"C:\cygwin64\bin\bash.exe");
                    psi.Arguments = "--login -i E://Work/sync.sh  E://Work/Voice/Temp";
                    Process p = Process.Start(psi);
                 */
                //ProcessStartInfo psi = new ProcessStartInfo(@"C:\cygwin64\bin\bash.exe");
                // bashProcess.StartInfo = psi;
                var escapedArgs = arguments.Replace("\"", "\\\"");
                bashProcess.StartInfo.FileName = "C:/Windows/System32/bash";
                bashProcess.StartInfo.Arguments = $"-c \"{escapedArgs}\"";

                bashProcess.StartInfo.CreateNoWindow = true;
                bashProcess.StartInfo.UseShellExecute = false;
                bashProcess.StartInfo.RedirectStandardOutput = true;
                bashProcess.StartInfo.RedirectStandardError = true;
                bashProcess.OutputDataReceived += (sender, data) =>
                {
                    bashOutput.Append(data.Data);
                    Debug.WriteLine("Output: " + data.Data);
                };
                bashProcess.ErrorDataReceived += (sender, data) =>
                {
                    bashError.Append(data.Data);
                    Debug.WriteLine("Error: " + data.Data);
                };

                bashProcess.Start();
                bashProcess.BeginOutputReadLine();
                bashProcess.BeginErrorReadLine();
                bashProcess.WaitForExit();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message.ToString());
            }
        }

        public static void BashDeployIotEdge(string connectionString)
        {
            string path = "/mnt/" + Directory.GetCurrentDirectory().Replace("C:\\","c/").Replace("\\", "/") + "/Utils/root";
            //Console.WriteLine(path);
            //BashProcessExecute(path + "/test.sh \"" + connectionString + "\"");
            BashProcessExecute(path + "/deploy_iot_edge.sh \"" + connectionString + "\"");
            //CheckDeployment();
        }

        private static void CheckDeployment()
        {
            Timer timer = new Timer();


        }
    }
}
