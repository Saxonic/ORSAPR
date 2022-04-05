using System;
using System.Diagnostics;
using System.IO;
using ComputerCase;
using Microsoft.VisualBasic.Devices;

namespace StressTesting
{
    internal static class Program
    {
        private const double BitsInGigabyte = 1073741824;
        private static void Main(string[] args)
        {
            TestKompas3D();
            //TestInventor();
        }

        private static CaseParameters GetCaseParameters()
        {
            return new CaseParameters
            {
                FrontFansCount = 2,
                FrontFansDiameter = 120,
                Height = 391,
                Length = 400,
                MotherboardType = MotherboardType.ATX,
                UpperFansCount = 3,
                UpperFansDiameter = 120,
                Width = 160
            };
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
            var caseParameters = GetCaseParameters();
            var streamWriter = new StreamWriter($"log{apiService}.txt", true);
            Process currentProcess = Process.GetCurrentProcess();
            var count = 0;
            while (true)
            {
                builder.CrateCase(caseParameters);
                var computerInfo = new ComputerInfo();
                var usedMemory = (computerInfo.TotalPhysicalMemory - computerInfo.AvailablePhysicalMemory)/
                                 BitsInGigabyte;
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