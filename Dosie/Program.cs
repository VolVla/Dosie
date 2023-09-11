﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DosieProgram
{
    internal class Program
    {
        static void Main()
        {
            Dosie dosie = new Dosie();
            ConsoleKey exitButton = ConsoleKey.Enter;
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Для начало работы нажмите на любую клавишу");
                Console.ReadKey();
                Console.Clear();
                dosie.CortSoldier();
                Console.WriteLine($"\nВы хотите выйти из программы?Нажмите {exitButton}.\nДля продолжение работы нажмите любую другую клавишу");

                if (Console.ReadKey().Key == exitButton)
                {
                    Console.WriteLine("Вы вышли из программы");
                    isWork = false;
                }

                Console.Clear();
            }
        }
    }

    class Dosie
    {
        private List<Soldier> _soldiers;

        public Dosie() 
        {
            _soldiers = new List<Soldier>()
            {
                new Soldier("Vasy","Пулемет","Рядовой",6),
                new Soldier("Petiy","Гранатомет","Сержант",15),
                new Soldier("Volody","Грузовик","Прапорщик",32),
                new Soldier("Anton","Танк","Капитан",20),
                new Soldier("Jorg","Квадракоптер","Лейтенант",1),
            };
        }

        public void CortSoldier() 
        {
            Console.WriteLine("Введите используемое оружие солдатом");
            string weaponName = Console.ReadLine();
            Console.WriteLine("Введите срок службы солдата");
            int.TryParse(Console.ReadLine(), out int serviceLifeSoldier);
            var filterSoldiers = _soldiers.Where(soldier => soldier.Weapon == weaponName && soldier.ServiceLife == serviceLifeSoldier);
            ShowInfo(filterSoldiers);
        }

        private void ShowInfo(IEnumerable<Soldier> _cortSoldier)
        {
            foreach(var soldier in _cortSoldier)
            {
                Console.WriteLine($"Имя  солдата - {soldier.Name} , Звание - {soldier.Title}");
            }
        }
    }

    class Soldier
    {
        public Soldier(string name,string weapon,string title,int serviceLife) 
        {
            Name = name;
            Weapon = weapon;
            Title = title;
            ServiceLife = serviceLife;
        }

        public string Name { get;private set; }
        public string Weapon {  get;private set; }
        public string Title { get;private set; }
        public int ServiceLife { get;private set; }
    }
}
