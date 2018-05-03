using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackupCopy.DAL.Modules
{
    public class HDD : Storage
    {
        public HDD() : this(0){  }
        public HDD(int SpeedHDD):this(SpeedHDD, TypeDevice.USB2) { }
        public HDD(int SpeedHDD, TypeDevice typeDevice): base("") // libo base() pustoi
        {
            this.SpeedHDD = SpeedHDD;
            this.typeDevice = typeDevice;
        }



        public TypeDevice typeDevice { get; set; }
        public int SpeedHDD { get; set; }

        public int Claster { get; set; }
        public int ClasterMemory { get; set; }
        public override double getMemory()
        {
            return ClasterMemory;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();  // Console.WriteLine("{0} ({1})", base.Name, base.Model);
            Console.WriteLine("SpeedHDD = {0} \n typeDevice = {1} \n Cluster = {2} \n ClasterMemory = {3}" , SpeedHDD, typeDevice, Claster, ClasterMemory);
        }

        /*●	расчет времени необходимого для копирования;*/
        public override void Copy()
        {
            int sum = ClasterMemory / SpeedHDD;
            for (int i = 0; i < sum; i++)
            {
                Console.WriteLine(".");
                Thread.Sleep(500);
            }
        }


    }
}
