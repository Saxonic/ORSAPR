using System;
using System.Diagnostics;
using System.IO;
using ComputerCase;
using Microsoft.VisualBasic.Devices;

namespace StressTesting
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            //TestKompas3D();
            TestInventor();
        }

        private static void TestInventor()
        {
            TestApi(new InventorAPI.InventorAPI());
        }

        private static void TestKompas3D()
        {
            TestApi(new KompasAPI.KompasAPI());
        }

        private static void TestApi(IBuilderProgramAPI apiService)
        {
            var builder = new CaseBuilder(apiService);
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var caseParameters = new CaseParameters
            {
                FrontFansCount = 1,
                FrontFansDiameter = 40,
                Height = 400,
                Length = 400,
                MotherboardType = MotherboardType.ATX,
                UpperFansCount = 1,
                UpperFansDiameter = 40,
                Width = 400
            };
            var streamWriter = new StreamWriter($"log{apiService}.txt", true);
            Process currentProcess = Process.GetCurrentProcess();
            var count = 0;
            while (true)
            {
                builder.CrateCase(caseParameters);
                var computerInfo = new ComputerInfo();
                var usedMemory = (computerInfo.TotalPhysicalMemory - computerInfo.AvailablePhysicalMemory) *
                                 0.000000000931322574615478515625;
                streamWriter.WriteLine(
                    $"{++count}\t{stopWatch.Elapsed:hh\\:mm\\:ss}\t{usedMemory}");
                streamWriter.Flush();
            }

            stopWatch.Stop();
            streamWriter.Close();
            streamWriter.Dispose();
            Console.Write($"End {new ComputerInfo().TotalPhysicalMemory}");
        }
    }
}