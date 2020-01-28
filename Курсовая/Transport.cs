using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Гос.номер
Марка
Модель
Год выпуска
Вид ТС
*/

namespace Курсовая
{
    class Transport
    {
        string gos_nomer;
        string marka;
        string model;
        int    god_vypuska;
        Vid_Transporta vid_TS;

        public Transport() { }
        ~Transport() { }

        public void setvid_TS(Vid_Transporta vid_TS)
        {
            this. vid_TS =  vid_TS;
        }

        public void setgos_nomer(string gos_nomer)
        {

            this.gos_nomer = gos_nomer;
        }
        public void setmarka(string marka)
        {    
            this.marka = marka;
        }
        public void setmodel(string model)
        {
            this.model = model;
        }
        public int getgod_vypuska() { return god_vypuska; }
        public void setgod_vypuska(int god_vypuska)
        {
            this.god_vypuska = god_vypuska;
        }
  
        public void Print()
        {
            Console.WriteLine("Гос.номер: " + gos_nomer);
            Console.WriteLine("Марка: " + marka);
            Console.WriteLine("Модель: " + model);
            Console.WriteLine("Год выпуска: " + god_vypuska);
            Console.WriteLine("Вид ТС: "+ vid_TS.getvid_transporta());
            Console.WriteLine("Средняя скорость: " + vid_TS.getsrednyaya_skorost());
            Console.WriteLine("Количество мест: " + vid_TS.getkolichestvo_mest());
            Console.WriteLine("Стоимость проезда: " + vid_TS.getstoimost_proezda());
            Console.WriteLine("Количество машин в автопарке: " + vid_TS.getkolichestvo_mashin_v_avtoparke());
        }
        public void Printf(SaveManager file)
        {
            file.WriteLine("Гос.номер: " + gos_nomer);
            file.WriteLine("Марка: " + marka);
            file.WriteLine("Модель: " + model);
            file.WriteLine("Год выпуска: " + god_vypuska);
            file.WriteLine("Вид ТС: " + vid_TS.getvid_transporta());
            file.WriteLine("Средняя скорость: " + vid_TS.getsrednyaya_skorost());
            file.WriteLine("Количество мест: " + vid_TS.getkolichestvo_mest());
            file.WriteLine("Стоимость проезда: " + vid_TS.getstoimost_proezda());
            file.WriteLine("Количество машин в автопарке: " + vid_TS.getkolichestvo_mashin_v_avtoparke());
        }


    }
}
