using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackupCopy.DAL.Modules
{


    public enum TypeDevice { USB2, USB3 }
    public class Flash : Storage
    {
        public Flash(string Model):base("", Model)
        {

        }
        public Flash() : this(0) { }
        public Flash(int SpeedFlash) : this(SpeedFlash, 0) { }

        public Flash(int SpeedFlash, double MemoryFlash) : base()
        {
            this.SpeedFlash = SpeedFlash;
            this.MemoryFlash = MemoryFlash;
        }

        public int SpeedFlash { get; private set; }
        public double MemoryFlash { get; set; }


        private TypeDevice TypeDevice_;
        public TypeDevice typeDevice {
            get { return TypeDevice_; }
            set { if (TypeDevice.USB2 == value) SpeedFlash = 2000; else SpeedFlash = 3000; }
        }


        public override double getMemory()
        {
            return MemoryFlash;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();  // Console.WriteLine("{0} ({1})", base.Name, base.Model);
            Console.WriteLine("SpeedFlash = {0} \n MemoryFlash = {1} \n TypeDevice = {2}", SpeedFlash, MemoryFlash, typeDevice);

        }
        /*●	расчет времени необходимого для копирования;*/
        public override void Copy()
        {
            int sum = (int)MemoryFlash / SpeedFlash;
            for (int i = 0; i < sum; i++)
            {
                Console.WriteLine(".");
                Thread.Sleep(500);
            }
        }




    }
}
