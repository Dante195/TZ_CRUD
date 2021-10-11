using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZ_CRY.Model;
using TZ_CRY.Context;


namespace TZ_CRY
{
    class Program
    {
        //public static Dante Dante { get; set; }
        public static ObservableCollection<Dante> Dantes { get; set; }

        public static int Action { get; set; }
        static void Main(string[] args)
        {
            Dantes = new ObservableCollection<Dante>();

            
            while (Action != 5)
            {
                Console.WriteLine("Введите что-нибудь!");
                ListCommand();
                Action = int.Parse(Console.ReadLine());

                switch (Action)
                {
                    case 1:
                        AppData.db.Dante.Add(AddDante(new Dante()));
                        AppData.db.SaveChanges();
                        Console.WriteLine("Данные успешно добавлены!");
                        break;
                    case 2:
                        Console.Write("Укажите ID: ");
                        int idEditor = int.Parse(Console.ReadLine());
                        var selectItemEditor = AppData.db.Dante.FirstOrDefault(item => item.ID == idEditor);
                        if (selectItemEditor != null)
                        {
                            AppData.db.Dante.Add (AddDante(selectItemEditor));
                            AppData.db.SaveChanges();
                            Console.WriteLine("Данные успешно отредактированы!");
                        }
                        else
                            Console.WriteLine("Такого пользователя не существует!");
                        break;
                        break;
                    case 3:
                        Console.Write("Укажите ID: ");
                        int idRemove = int.Parse(Console.ReadLine());
                        var selectedItemRemove = AppData.db.Dante.FirstOrDefault(item => item.ID == idRemove);
                        if (selectedItemRemove != null)
                        {
                            AppData.db.Dante.Remove(selectedItemRemove);
                            AppData.db.SaveChanges();
                            Console.WriteLine("Данные успешно удалены!");
                        }
                        else
                            Console.WriteLine("Такого пользователя не существует!");
                        break;
                    case 4:
                        if (Dantes != null)
                        {
                            Dantes = new ObservableCollection<Dante>(AppData.db.Dante.ToList());
                            foreach (var item in Dantes)
                            {
                                Console.WriteLine("ID: " + item.ID);
                                Console.WriteLine("Имя: " + item.FirstName);
                                Console.WriteLine("Фамилия: " + item.LastName);
                                Console.WriteLine("Отчество: " + item.MiddleName);
                                Console.WriteLine("Год рождения: " + item.DateOfBirth);
                                Console.WriteLine("------------------------------------------------------");
                            }

                        }
                        break;
                    case 5:
                        Console.WriteLine("Выйди из программы");
                        break;
                    
                }
            }
        }
        private static void ListCommand()
        {
            Console.WriteLine("1. Добавить даные в БД");
            Console.WriteLine("2. Редактировать выбранный объект");
            Console.WriteLine("3. Удалить выбранный объект");
            Console.WriteLine("4. Отобразить существующие данные");
            Console.WriteLine("5. Выйти");
        }

        private static Dante AddDante(Dante dante) 
        {
            dante = new Dante();
            Console.Write("Введите имя: ");
            dante.FirstName = Console.ReadLine();
            Console.Write("Введите фамилию: ");
            dante.LastName = Console.ReadLine();
            Console.Write("Введите отчество: " );
            dante.MiddleName = Console.ReadLine();
            Console.Write("Введите год рождения: ");
            dante.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            //AppData.db.Dante.Add(dante); 33 строка
            //AppData.db.SaveChanges(); 33 строка
            return dante;
        }


    }

}
