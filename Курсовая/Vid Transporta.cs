using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Вид транспорта
Средняя скорость
Количество мест
Стоимость проезда
Количество машин в автопарке
*/

namespace Курсовая
{
    class Vid_Transporta
    {
        string vid_transporta;
        float srednyaya_skorost;
        int kolichestvo_mest;
        int stoimost_proezda;
        static int kolichestvo_mashin_v_avtoparke;
        public Vid_Transporta() { kolichestvo_mashin_v_avtoparke++; }
        ~Vid_Transporta() { kolichestvo_mashin_v_avtoparke--; }

        public void setvid_transporta(string vid_transporta)
        {
            this.vid_transporta = vid_transporta;
        }
        public void setsrednyaya_skorost(float srednyaya_skorost)
        {
            this.srednyaya_skorost = srednyaya_skorost;
        }

        public void setkolichestvo_mest(int kolichestvo_mest)
        {
            this.kolichestvo_mest = kolichestvo_mest;
        }

        public void setstoimost_proezda(int stoimost_proezda)
        {
            this.stoimost_proezda = stoimost_proezda;
        }
        public int getstoimost_proezda() { return stoimost_proezda; }
        public float getsrednyaya_skorost() { return srednyaya_skorost; }
        public int getkolichestvo_mest() { return kolichestvo_mest; }
        public string getvid_transporta() { return vid_transporta; }
        public int getkolichestvo_mashin_v_avtoparke() { return kolichestvo_mashin_v_avtoparke; }
        public void Print()
        {
            Console.WriteLine("Вид транспорта: " + vid_transporta);
            Console.WriteLine("Средняя скорость: " + srednyaya_skorost);
            Console.WriteLine("Количество мест: " + kolichestvo_mest);
            Console.WriteLine("Стоимость проезда: " + stoimost_proezda);
            Console.WriteLine("Количество машин в автопарке: " + kolichestvo_mashin_v_avtoparke);
        }

        public void Printf(SaveManager file)
        {
            file.WriteLine("Вид транспорта: " + vid_transporta);
            file.WriteLine("Средняя скорость: " + srednyaya_skorost);
            file.WriteLine("Количество мест: " + kolichestvo_mest);
            file.WriteLine("Стоимость проезда: " + stoimost_proezda);
            file.WriteLine("Количество машин в автопарке: " + kolichestvo_mashin_v_avtoparke);
        }
       
                
           
        
    }
}
