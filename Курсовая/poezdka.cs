using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Дата выезда
Номер ТС
Номер маршрута
Количество оборотов за день
Выручка за день

 */

namespace Курсовая
{
    class Poezdka
    {
    
    DateTime data_vyezda = new DateTime();
    string nomer_TS;
    int nomer_marshruta;
    int kolichestvo_oborotov_za_den;
    float vyruchka_za_den;
    int count_passangers;

    public Poezdka() { }
        ~Poezdka() { }
        public void setnomer_TS(string nomer_TS)
        {
            this.nomer_TS = nomer_TS;
        }
        public void setnomer_marshruta(int nomer_marshruta)
        {
            this.nomer_marshruta = nomer_marshruta;
        }
        public void setkolichestvo_oborotov_za_den(int kolichestvo_oborotov_za_den)
        {
            this.kolichestvo_oborotov_za_den = kolichestvo_oborotov_za_den;
        }
        public void setvyruchka_za_den(float vyruchka_za_den)
        {
            this.vyruchka_za_den = vyruchka_za_den;
        }
        public void setdata_vyezda(DateTime data_vyezda)
        {
            this.data_vyezda = data_vyezda;
        }
        public void setcount_passangers(int count_passangers)
        {
            this.count_passangers = count_passangers;
     }
        public int getkolichestvo_oborotov_za_den() { return kolichestvo_oborotov_za_den; }
        public int getnomer_marshruta() { return nomer_marshruta; }
        public string getnomer_TS() { return nomer_TS; }
        public int getcount_passangers() { return count_passangers; }

        public float getvyruchka_za_den() { return vyruchka_za_den; }

        public void Print()
        {
            Console.WriteLine("Дата выезда: " + data_vyezda);
            Console.WriteLine("Номер ТС: " + nomer_TS);
            Console.WriteLine("Номер маршрута: " + nomer_marshruta);
            Console.WriteLine("Количество оборотов за день: " + kolichestvo_oborotov_za_den);
            Console.WriteLine("Количество пассажиров за день: " + count_passangers);
            Console.WriteLine("Выручка за день: " + vyruchka_za_den);
        }
        public void Printf(SaveManager file)
        {
            file.WriteLine("Дата выезда: " + data_vyezda);
            file.WriteLine("Номер ТС: " + nomer_TS);
            file.WriteLine("Номер маршрута: " + nomer_marshruta);
            file.WriteLine("Количество оборотов за день: " + kolichestvo_oborotov_za_den);
            file.WriteLine("Количество пассажиров за день: " + count_passangers);
            file.WriteLine("Выручка за день: " + vyruchka_za_den);
        }

    }
}
