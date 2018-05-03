using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackupCopy.DAL.Modules
{
    public enum TypeDVD { OneSide, TwoSide}
    public class DVD : Storage
    {

        public DVD() : this(0) { }
        public DVD(int SpeedWrite) : this(SpeedWrite,TypeDVD.OneSide) { }
        public DVD(int SpeedWrite, TypeDVD typeDVD) : base()
        {
            this.SpeedWrite = SpeedWrite;
            this.typeDVD = typeDVD;
        }

        public DVD(string name)
        {
            base.Name = name;
            base.Model = "fsfsdf";
         }

        public int SpeedWrite { get; set; }
        public int SpeedRead { get; set; }
        public TypeDVD typeDVD { get; set; }

        public override double getMemory()
        {
            if (TypeDVD.OneSide == typeDVD) return 4.7;
            else return 4.7 * 2;
        }

     
        public override void PrintInfo()
        {
            base.PrintInfo();  // Console.WriteLine("{0} ({1})", base.Name, base.Model);
            Console.WriteLine("SpeedWrite = {0} \n SpeedRead = {1} \n typeDVD = {2} \n ", SpeedWrite, SpeedRead, typeDVD);

        }

      /*  ●	расчет времени необходимого для копирования;*/

        public sealed override void Copy() //zapechatannui metod (nelza pereopredelit6)
        {
            int sum = (int) getMemory() / SpeedWrite;
            for (int i = 0; i < sum; i++)
            {
                Console.WriteLine(".");
                Thread.Sleep(500);
            }
        }

    }
}
