using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackupCopy.DAL.Modules;

namespace BackupCopy
{
    class Program
    {
        static void Main(string[] args)
        {

            GenerateDevice generator = new GenerateDevice();
            Console.WriteLine("Введите объем данных");
            double temp = Double.Parse(Console.ReadLine());
            generator.GenerateFlash();

            Service serv = new Service();
            double totalMemory = serv.CalculateTotalMemory(new List<HDD>(), generator.fl, new List<DVD>());
            Console.WriteLine("Общий объем флэшек = {0} ({1})", totalMemory, generator.fl.Count);

            TimeSpan time = serv.CalculateTotalTime(generator.fl);
            Console.WriteLine(time.TotalMinutes);

            serv.getCounter(ref generator.fl, temp);

            foreach (Flash item in generator.fl)
            {
                item.PrintInfo();
            }


        }
    }
}
