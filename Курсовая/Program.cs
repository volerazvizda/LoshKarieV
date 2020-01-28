using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая
{
    class Program
    {
        static void Main(string[] args)
        {

            SaveManager file = new SaveManager("Result.txt");


            while (true)
            {
                Console.WriteLine("БАЗА ДАННЫХ ГОРОДСКОГО ТРАНСПОРТА");
                Console.WriteLine("*********************************");
                Console.WriteLine("*****Меню*****");
                Console.WriteLine("1-Ввод из файла");
                Console.WriteLine("2-Ввод из консоли");
                Console.WriteLine("3-Очистить базу данных");
                Console.WriteLine("4-Завершить редактирование");
                Console.WriteLine("5-Выход из программы");
                int sp = int.Parse(Console.ReadLine());
                switch (sp)
                {
                    case 1:
                        try
                        {
                            int i = 0;
                            Transport[] transportf = new Transport[30];
                            Vid_Transporta[] vid_transportf = new Vid_Transporta[30];
                            Marshrut[] marshrutf = new Marshrut[30];
                            Poezdka[] poezdkaf = new Poezdka[30];

                            //StreamReader sr = File.OpenText("Transport.txt");
                            LoadManager sr = new LoadManager("Transport.txt");
                            sr.OpenText();
                            //StreamReader sr2 = File.OpenText("Marshrut.txt");
                            LoadManager sr2 = new LoadManager("Marshrut.txt");
                            sr2.OpenText();
                            // StreamReader sr3 = File.OpenText("Poezdka.txt");
                            LoadManager sr3 = new LoadManager("Poezdka.txt");
                            sr3.OpenText();

                            while (true)
                            {
                                string str = sr.ReadLine();
                                if (str == null)
                                    break;
                                string[] elements = str.Split(';');


                                //ТС(считывание значений)
                                transportf[i] = new Transport();

                                transportf[i].setgos_nomer(elements[0]); //Номер
                                transportf[i].setmarka(elements[1]); //Марка                                
                                transportf[i].setmodel(elements[2]); //Модель
                                transportf[i].setgod_vypuska(int.Parse(elements[3])); //Год выпуска

                                vid_transportf[i] = new Vid_Transporta();
                                vid_transportf[i].setvid_transporta(elements[4]); //Вид ТС
                                vid_transportf[i].setsrednyaya_skorost(int.Parse(elements[5])); // Средняя скорость
                                vid_transportf[i].setkolichestvo_mest(int.Parse(elements[6])); // Кол-во мест
                                vid_transportf[i].setstoimost_proezda(int.Parse(elements[7])); // Стоимость проезда
                                vid_transportf[i].getkolichestvo_mashin_v_avtoparke(); // Кол-во машин всего

                                transportf[i].setvid_TS(vid_transportf[i]);

                                string strn = sr2.ReadLine();
                                if (strn == null)
                                    break;
                                string[] elementsn = strn.Split(';');


                                //Маршруты
                                marshrutf[i] = new Marshrut();
                                marshrutf[i].setnomer_marshruta(int.Parse(elementsn[0]));
                                marshrutf[i].setnazvanie_marshruta(elementsn[1], elementsn[2]);
                                marshrutf[i].setrasstoyanie(float.Parse(elementsn[3]));
                                marshrutf[i].setkolichestvo_ostanovok_vputi(int.Parse(elementsn[4]));                               
                                marshrutf[i].setplan_po_kolichestvu_passazhirov_v_den(int.Parse(elementsn[5]));
                                marshrutf[i].setplan_po_sboru_za_proezd(float.Parse(elementsn[6]));

                                string strs = sr3.ReadLine();
                                if (strs == null)
                                    break;
                                string[] elementss = strs.Split(';');

                                //Поездка
                                poezdkaf[i] = new Poezdka();
                                poezdkaf[i].setdata_vyezda(DateTime.Parse(elementss[0]));
                                poezdkaf[i].setnomer_TS(elementss[1]);
                                poezdkaf[i].setnomer_marshruta(int.Parse(elementss[2]));
                                poezdkaf[i].setkolichestvo_oborotov_za_den(int.Parse(elementss[3]));
                                poezdkaf[i].setcount_passangers(int.Parse(elementss[4]));
                                poezdkaf[i].setvyruchka_za_den((poezdkaf[i].getcount_passangers()) * (vid_transportf[i].getstoimost_proezda()));


                                i++;
                            }
                            //sr.Close();
                            sr.EndRead();
                            sr2.EndRead();
                            sr3.EndRead();
                            i = 0;
                            file.WriteLine("БАЗА ДАННЫХ ГОРОДСКОГО ТРАНСПОРТА");
                            while (true)
                            {
                                if (transportf[i] == null) break;
                                //ТС
                                Console.WriteLine("ТС[" + (i + 1) + "]");
                                file.WriteLine("ТС[" + (i + 1) + "]");
                                transportf[i].Print();
                                transportf[i].Printf(file);
                                //Их маршруты
                                Console.WriteLine("Маршрут ТС[" + (i + 1) + "]");
                                file.WriteLine("Маршрут ТС[" + (i + 1) + "]");
                                marshrutf[i].Print();
                                marshrutf[i].Printf(file);
                                file.WriteLine("***************");
                                Console.WriteLine("===============");
                                i++;
                            }
                            i = 0;
                            while (true)
                            {
                                if (poezdkaf[i] == null) break;
                                //Поездки по маршрутам
                                Console.WriteLine("Поездкa[" + (i + 1) + "]");
                                file.WriteLine("Поездкa[" + (i + 1) + "]");
                                poezdkaf[i].Print();
                                poezdkaf[i].Printf(file);

                                if ((poezdkaf[i].getcount_passangers()) > (marshrutf[i].getplan_po_kolichestvu_passazhirov_v_den()))
                                {
                                    Console.WriteLine("План по пассажирам выполнен");
                                    file.WriteLine("План по пассажирам выполнен");
                                }
                                else
                                {
                                    Console.WriteLine("План по пассажирам не выполнен");
                                    file.WriteLine("План по пассажирам не выполнен");
                                }

                                if ((poezdkaf[i].getvyruchka_za_den()) > (marshrutf[i].getplan_po_sboru_za_proezd()))
                                {
                                    Console.WriteLine("План по выручке выполнен");
                                    file.WriteLine("План по выручке выполнен");
                                }
                                else
                                {
                                    Console.WriteLine("План по выручке не выполнен");
                                    file.WriteLine("План по выручке не выполнен");
                                }


                                i++;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("---Ошибка при заполнении!Повторите ввод---");
                        }
                        break;


                    case 2:
                              int n;
                            for (; ; )
                            {
                            try
                            {
                                Console.WriteLine("Введите количество ТС");
                                n = int.Parse(Console.ReadLine());
                                if (n > 0)
                                {
                                    break;
                                }

                                else
                                {
                                    Console.WriteLine("---Значение введено неверно!Пожалуйста повторите ввод---");
                                }
                            }
                            catch
                            {
                                Console.WriteLine("---Значение введено неверно!Пожалуйста повторите ввод---");
                            }

                            }

                            Transport[] transport = new Transport[n];
                            Vid_Transporta[] vid_transport = new Vid_Transporta[n];
                            Marshrut[] marshrut = new Marshrut[n];


                            for (int i = 0; i < n; i++)
                            {

                                transport[i] = new Transport();
                            for (; ; )
                            {
                                try
                                {
                                    Console.WriteLine("Введите гос.номер ТС");
                                    transport[i].setgos_nomer(Console.ReadLine());
                                    break;
                                }
                                catch
                                {
                                    Console.WriteLine("---Значение введено неверно!Пожалуйста повторите ввод---");
                                }
                            }

                            for (; ; )
                            {
                                try
                                {
                                    Console.WriteLine("Введите марку ТС");
                                    transport[i].setmarka(Console.ReadLine());
                                    break;
                                }
                                catch
                                {
                                    Console.WriteLine("---Значение введено неверно!Пожалуйста повторите ввод---");
                                }
                            }
                         
 
                               
                                for (; ; )
                                {
                                    try
                                    {
                                        Console.WriteLine("Введите год выпуска ТС");
                                        transport[i].setgod_vypuska(int.Parse(Console.ReadLine()));
                                    break;
                                    }
                                    catch
                                    {
                                        Console.WriteLine("---Значение введено неверно!Пожалуйста повторите ввод---");
                                    }
                                }

  
                              
                                vid_transport[i] = new Vid_Transporta();
                                for(; ; )
                                {
                                    try
                                    {
                                        Console.WriteLine("Введите вид ТС");
                                        vid_transport[i].setvid_transporta(Console.ReadLine());
                                        break;
                                    }
                                    catch
                                    {
                                        Console.WriteLine("---Значение введено неверно!Пожалуйста повторите ввод---");
                                    }
                                }
                          
                                for (; ; )
                                {
                                    try
                                    {
                                        Console.WriteLine("Введите среднюю скорость");
                                        vid_transport[i].setsrednyaya_skorost(int.Parse(Console.ReadLine()));
                                        if (vid_transport[i].getsrednyaya_skorost() > 0)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("---Неверно введено значение!Пожалуйста повторите---");
                                        }
                                    }

                                    catch
                                    {
                                        Console.WriteLine("---Значение введено неверно!Пожалуйста повторите ввод---");
                                    }
                                }
                                for (; ; )
                                {
                                    try
                                    {
                                        Console.WriteLine("Введите кол-во мест");
                                        vid_transport[i].setkolichestvo_mest(int.Parse(Console.ReadLine()));
                                        if (vid_transport[i].getkolichestvo_mest() > 0)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("---Значение введено неверно!Пожалуйста повторите ввод---");
                                        }
                                    }

                                    catch
                                    {
                                        Console.WriteLine("---Значение введено неверно!Пожалуйста повторите ввод---");
                                    }
                                }

                                for (; ; )
                                {
                                    try
                                    {
                                        Console.WriteLine("Введите стоимость проезда");
                                        vid_transport[i].setstoimost_proezda(int.Parse(Console.ReadLine()));
                                        if (vid_transport[i].getstoimost_proezda() > 0)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("---Неверно введено значение!Пожалуйста повторите---");
                                        }
                                    }

                                    catch
                                    {
                                        Console.WriteLine("---Неверно введено значение!Пожалуйста повторите---");
                                    }
                                }

                                vid_transport[i].getkolichestvo_mashin_v_avtoparke();//Кол-во машин
                                transport[i].setvid_TS(vid_transport[i]);

                                marshrut[i] = new Marshrut();

                            for (; ; )
                            {
                                try
                                {
                                    Console.WriteLine("Введите номер маршрута");
                                    marshrut[i].setnomer_marshruta(int.Parse(Console.ReadLine()));
                                    if (marshrut[i].getnomer_marshruta() > 0)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("---Неверно введено значение!Пожалуйста повторите---");
                                    }
                                }

                                catch
                                {
                                    Console.WriteLine("---Неверно введено значение!Пожалуйста повторите---");
                                }
                            }



                            for (; ; )
                            {
                                try
                                {
                                    Console.WriteLine("Введите начальный пункт,конечный пункт");
                                    marshrut[i].setnazvanie_marshruta(Console.ReadLine(), Console.ReadLine());
                                    break;
                                }

                                catch
                                {
                                    Console.WriteLine("---Неверно введено значение!Пожалуйста повторите---");
                                }
                            }
                            for (; ; )
                            {
                                try
                                {
                                    Console.WriteLine("Введите расстояние");
                                    marshrut[i].setrasstoyanie(float.Parse(Console.ReadLine()));
                                    if (marshrut[i].getrasstoyanie() > 0)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("---Неверно введено значение!Пожалуйста повторите---");
                                    }
                                }

                                catch
                                {
                                    Console.WriteLine("---Неверно введено значение!Пожалуйста повторите---");
                                }
                            }
                            for (; ; )
                            {
                                try
                                {
                                    Console.WriteLine("Введите количество остановок");
                                    marshrut[i].setkolichestvo_ostanovok_vputi(int.Parse(Console.ReadLine()));
                                    if (marshrut[i].getkolichestvo_ostanovok_vputi() > 0)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("---Неверно введено значение!Пожалуйста повторите---");
                                    }
                                }

                                catch
                                {
                                    Console.WriteLine("---Неверно введено значение!Пожалуйста повторите---");
                                }
                            }
                            for (; ; )
                            {
                                try
                                {
                                    Console.WriteLine("Введите план пассажиров в день");
                                    marshrut[i].setplan_po_kolichestvu_passazhirov_v_den(int.Parse(Console.ReadLine()));
                                    if (marshrut[i].getplan_po_kolichestvu_passazhirov_v_den() > 0)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("---Неверно введено значение!Пожалуйста повторите---");
                                    }
                                }

                                catch
                                {
                                    Console.WriteLine("---Неверно введено значение!Пожалуйста повторите---");
                                }
                            }


                            for (; ; )
                            {
                                try
                                {
                                    Console.WriteLine("Введите план по пассажирам за проезд");
                                    marshrut[i].setplan_po_sboru_za_proezd(float.Parse(Console.ReadLine()));
                                    if (marshrut[i].getplan_po_sboru_za_proezd() > 0)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("---Неверно введено значение!Пожалуйста повторите---");
                                    }
                                }

                                catch
                                {
                                    Console.WriteLine("---Неверно введено значение!Пожалуйста повторите---");
                                }
                            }




                            int[] m = new int[10];



                            for (; ; )
                            {
                                try
                                {
                                    Console.WriteLine("Введите количество поездок");
                                    m[i] = int.Parse(Console.ReadLine());
                                    if (m[i]> 0)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("---Неверно введено значение!Пожалуйста повторите---");
                                    }
                                }

                                catch
                                {
                                    Console.WriteLine("---Неверно введено значение!Пожалуйста повторите---");
                                }
                            }
                           
                            Poezdka[,] poezdka = new Poezdka[n, m[i]];

                            for (int j = 0; j < m[i]; j++)
                                {


                                    poezdka[i, j] = new Poezdka();

                                for (; ; )
                                {
                                    try
                                    {
                                        Console.WriteLine("Введите дату выезда в формате год.месяц.день час:минута:секунда");
                                        poezdka[i, j].setdata_vyezda(DateTime.Parse(Console.ReadLine()));

                                        break;
                                    }
                                    catch
                                    {
                                        Console.WriteLine("---Неверно введено значение!Пожалуйста повторите---");
                                    }
                                }


                                for (; ; )
                                {
                                    try
                                    {
                                        Console.WriteLine("Введите номер ТС");
                                        poezdka[i, j].setnomer_TS(Console.ReadLine());
                                        break;
                 
                                    }

                                    catch
                                    {
                                        Console.WriteLine("---Неверно введено значение!Пожалуйста повторите---");
                                    }
                                }



                                for (; ; )
                                {
                                    try
                                    {
                                        Console.WriteLine("Введите номер маршрута");
                                        poezdka[i, j].setnomer_marshruta(int.Parse(Console.ReadLine()));
                                        if (poezdka[i,j].getnomer_marshruta() > 0)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("---Неверно введено значение!Пожалуйста повторите---");
                                        }
                                    }

                                    catch
                                    {
                                        Console.WriteLine("---Неверно введено значение!Пожалуйста повторите---");
                                    }
                                }



                                for (; ; )
                                {
                                    try
                                    {
                                        Console.WriteLine("Введите количество оборотов за день");
                                        poezdka[i, j].setkolichestvo_oborotov_za_den(int.Parse(Console.ReadLine()));
                                        if (poezdka[i, j].getkolichestvo_oborotov_za_den() > 0)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("---Неверно введено значение!Пожалуйста повторите---");
                                        }
                                    }

                                    catch
                                    {
                                        Console.WriteLine("---Неверно введено значение!Пожалуйста повторите---");
                                    }
                                }


                                for (; ; )
                                {
                                    try
                                    {
                                        Console.WriteLine("Введите количество пассажиров за день");
                                        poezdka[i, j].setcount_passangers(int.Parse(Console.ReadLine()));
                                        if (poezdka[i, j].getcount_passangers() > 0)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("---Неверно введено значение!Пожалуйста повторите---");
                                        }
                                    }

                                    catch
                                    {
                                        Console.WriteLine("---Неверно введено значение!Пожалуйста повторите---");
                                    }
                                }

                                



                                    poezdka[i, j].setvyruchka_za_den((poezdka[i, j].getcount_passangers()) * (vid_transport[i].getstoimost_proezda()));//выручка

                                 
                                }



                                        //ТС
                                        Console.WriteLine("ТС[" + (i + 1) + "]");
                                        file.WriteLine("ТС[" + (i + 1) + "]");
                                        transport[i].Print();
                                        transport[i].Printf(file);
                                        //Их маршруты
                                        Console.WriteLine("Маршрут ТС[" + (i + 1) + "]");
                                        file.WriteLine("Маршрут ТС[" + (i + 1) + "]");
                                        marshrut[i].Print();
                                        marshrut[i].Printf(file);
                                        file.WriteLine("***************");
                                        Console.WriteLine("===============");
                                    for (int z = 0; z < m[i]; z++)
                                    {
                                        //Поездки по маршрутам
                                        Console.WriteLine("Поездкa[" + (z + 1) + "]");
                                        file.WriteLine("Поездкa[" + (z + 1) + "]");

                                        poezdka[i, z].Print();
                                        poezdka[i, z].Printf(file);

                                        if ((poezdka[i, z].getcount_passangers()) > (marshrut[i].getplan_po_kolichestvu_passazhirov_v_den()))
                                        {
                                            Console.WriteLine("План по пассажирам выполнен");
                                            file.WriteLine("План по пассажирам выполнен");
                                        }
                                        else
                                        {
                                            Console.WriteLine("План по пассажирам не выполнен");
                                            file.WriteLine("План по пассажирам не выполнен");
                                        }

                                        if ((poezdka[i, z].getvyruchka_za_den()) > (marshrut[i].getplan_po_sboru_za_proezd()))
                                        {
                                            Console.WriteLine("План по выручке выполнен");
                                            file.WriteLine("План по выручке выполнен");
                                        }
                                        else
                                        {
                                            Console.WriteLine("План по выручке не выполнен");
                                            file.WriteLine("План по выручке не выполнен");
                                        }
                                    }
                                    }


                                
                            
                            





                        break;
                    case 3: file.WriteLine(""); break;
                    case 4: file.Close(); return;
                    case 5: Environment.Exit(0); break;
                    default:
                        Console.WriteLine("Введено неверное значение");
                        Console.ReadKey();
                        break;
                };


            }
        }
    }
}
