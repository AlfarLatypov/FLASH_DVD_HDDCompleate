using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackupCopy.DAL.Modules;

namespace BackupCopy
{
    class GenerateDevice
    {
        public GenerateDevice()
        {
            hd = new List<HDD>();
            dv = new List<DVD>();
            fl = new List<Flash>();
        }


        public List<HDD> hd;
        public List<DVD> dv;
        public List<Flash> fl; 
        private Random r = new Random();

        public void GenerateFlash() {
            for (int i = 0; i < r.Next(1,20); i++)
            {
                Flash flash = new Flash(string.Format("Model #{0}", r.Next(1000, 9999)));
                flash.MemoryFlash = r.Next(2000, 128000);
                flash.typeDevice = (TypeDevice)r.Next(0, 1);
                fl.Add(flash);
            }
        }


    }
}
