using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*●	расчет общего количества памяти всех устройств;
  ●	копирование информации на устройства;
  ●	расчет времени необходимого для копирования;
  ●	расчет необходимого количества носителей информации представленных типов для переноса информации.
*/

namespace BackupCopy.DAL.Modules
{
    public class Service
    {
        public double CalculateTotalMemory(List<HDD> hdds, List<Flash> flashes, List<DVD> dvds) //●	расчет общего количества памяти всех устройств;
        {
            double result = 0;

            foreach (HDD item in hdds)
                result += item.getMemory();
            foreach (Flash item in flashes)
                result += item.getMemory();
            foreach (DVD item in dvds)
                result += item.getMemory();
            return result;
        }

        /*●	расчет времени необходимого для копирования;*/
        public TimeSpan CalculateTotalTime(List<HDD> hdds)
        {   double sum = 0;
            foreach (HDD item in hdds)
                sum += item.ClasterMemory / item.SpeedHDD;
            return TimeSpan.FromMilliseconds(sum);  }

        public TimeSpan CalculateTotalTime(List<Flash> flashes)
        {
            double sum = 0;
            foreach (Flash item in flashes)
                sum += item.MemoryFlash / item.SpeedFlash;
            return TimeSpan.FromMilliseconds(sum);
        }

        public TimeSpan CalculateTotalTime(List<DVD> dvds)
        {
            double sum = 0;
            foreach (DVD item in dvds)
                sum += item.getMemory() / item.SpeedWrite;
            return TimeSpan.FromMilliseconds(sum);
        }


        /*●	расчет необходимого количества носителей информации представленных типов для переноса информации.*/
        private int DeviceCounter( DVD dvds, double MemoryData/*, out int count*/)
        {
            return
              Int32.Parse(
                Math.Ceiling(
                    (MemoryData / dvds.getMemory())).ToString()
                    );
        }
        private int DeviceCounter(HDD hdds, double MemoryData)
        {
           return
                 Int32.Parse(
                Math.Ceiling(
                    (MemoryData / hdds.getMemory())).ToString()
                    );
        }
        private int DeviceCounter(Flash flashs, double MemoryData)
        {
            return
                 Int32.Parse(
                Math.Ceiling(
                    (MemoryData / flashs.MemoryFlash)).ToString()
                    );
        }

        public void getCounter(ref List<Flash> flashs, double MemoryData)
        {
            foreach (Flash item in flashs)
            {
                item.Count = DeviceCounter(item, MemoryData);
            }
                        
        }
        public void getCounter(ref List<HDD> hdds, double MemoryData)
        {
            foreach (HDD item in hdds)
            {
                item.Count = DeviceCounter(item, MemoryData);
            }

        }
        public void getCounter(ref List<DVD> dvds, double MemoryData)
        {
            foreach (DVD item in dvds)
            {
                item.Count = DeviceCounter(item, MemoryData);
            }

        }



    }
}
