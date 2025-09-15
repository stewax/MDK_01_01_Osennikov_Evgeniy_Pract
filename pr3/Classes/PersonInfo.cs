using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr3.Classes
{
    internal class PersonInfo
    {
        /// Наименование
        public string Name { get; set; }
        /// Жизненные показатели
        public int Health { get; set; }
        /// Броня
        public int Armor { get; set; }
        /// Уровень
        public int Level { get; set; }
        /// Опыт
        public int Glasses { get; set; }
        /// Денежные средства
        public int Money { get; set; }
        /// Урон
        public float Damage { get; set; }

        public PersonInfo(string Name, int Health, int Armor, int Level, int Glasses, int Money, float Damage)
        {
            this.Name = Name;
            this.Health = Health;
            this.Armor = Armor;
            this.Level = Level;
            this.Glasses = Glasses;
            this.Money = Money;
            this.Damage = Damage;
        }
    }
}
