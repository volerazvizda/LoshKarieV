using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Номер маршрута
Название маршрута
Начальный пункт пути
Конечный пункт пути
Расстояние
Количество остановок в пути
Количество машин на маршруте
План по количеству пассажиров в день
План по сбору за проезд
*/

namespace Курсовая
{
    class Marshrut
    {
        int nomer_marshruta;
        string nazvanie_marshruta;
        float rasstoyanie;
        int kolichestvo_ostanovok_vputi;
        int plan_po_kolichestvu_passazhirov_v_den;
        float plan_po_sboru_za_proezd;
      
        public Marshrut() { }
        ~Marshrut() { }
        public void setnomer_marshruta(int nomer_marshruta)
        {
            this.nomer_marshruta = nomer_marshruta;
        }
        public void setnazvanie_marshruta(string nachalnyj_punkt_puti, string konechnyj_punkt_puti)
        {
            this.nazvanie_marshruta = (nachalnyj_punkt_puti +"-"+ konechnyj_punkt_puti);
        }
        public void setrasstoyanie(float rasstoyanie)
        {
            this.rasstoyanie = rasstoyanie;
        }
        public void setkolichestvo_ostanovok_vputi(int kolichestvo_ostanovok_vputi)
        {
            this.kolichestvo_ostanovok_vputi = kolichestvo_ostanovok_vputi;
        }
        public void setplan_po_kolichestvu_passazhirov_v_den(int plan_po_kolichestvu_passazhirov_v_den)
        {
            this.plan_po_kolichestvu_passazhirov_v_den = plan_po_kolichestvu_passazhirov_v_den;
        }
        public void setplan_po_sboru_za_proezd(float plan_po_sboru_za_proezd)
        {
            this.plan_po_sboru_za_proezd = plan_po_sboru_za_proezd; 
        }
   
  
        public int getkolichestvo_ostanovok_vputi() { return kolichestvo_ostanovok_vputi; }
        public float getrasstoyanie() { return rasstoyanie; }
        public string getnazvanie_marshruta() { return nazvanie_marshruta; }
        public int getnomer_marshruta() { return nomer_marshruta; }
        public int getplan_po_kolichestvu_passazhirov_v_den() { return plan_po_kolichestvu_passazhirov_v_den; }
        public float getplan_po_sboru_za_proezd() { return plan_po_sboru_za_proezd; }
        public void Print()
        {
            Console.WriteLine("==================================");
            Console.WriteLine("Номер маршрута: " + nomer_marshruta);
            Console.WriteLine("Название маршрута: " + nazvanie_marshruta);
            Console.WriteLine("Расстояние: " + rasstoyanie);
            Console.WriteLine("Количество остановок в пути: " + kolichestvo_ostanovok_vputi);          
            Console.WriteLine("План по количеству пассажиров в день: " + plan_po_kolichestvu_passazhirov_v_den);
            Console.WriteLine("План по сбору за проезд: " + plan_po_sboru_za_proezd);
        }
        public void Printf(SaveManager file)
        {
            file.WriteLine("==================================");
            file.WriteLine("Номер маршрута: " + nomer_marshruta);
            file.WriteLine("Название маршрута: " + nazvanie_marshruta);
            file.WriteLine("Расстояние: " + rasstoyanie);
            file.WriteLine("Количество остановок в пути: " + kolichestvo_ostanovok_vputi);       
            file.WriteLine("План по количеству пассажиров в день: " + plan_po_kolichestvu_passazhirov_v_den);
            file.WriteLine("План по сбору за проезд: " + plan_po_sboru_za_proezd);
        }


    }
    }
