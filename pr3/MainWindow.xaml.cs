using System;
using System.Collections.Generic;
using System.Windows.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pr3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
        
        public Classes.PersonInfo Player = new Classes.PersonInfo("Student",100,10,1,0,0,5);
        public Classes.PersonInfo Empty;
        public List<Classes.PersonInfo> Emptys = new List<Classes.PersonInfo>();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            UserInfoPlayer();
            Emptys.Add(new Classes.PersonInfo("Враг 1", 100, 20, 1, 15, 5, 20));
            Emptys.Add(new Classes.PersonInfo("Враг 2", 20, 5, 1, 5, 2, 5));
            Emptys.Add(new Classes.PersonInfo("Враг 3", 50, 3, 1, 10, 10, 15));

            dispatcherTimer.Tick += AttackPlayer;
            dispatcherTimer.Interval = new System.TimeSpan(0, 0, 10);
            dispatcherTimer.Start();

            SelectEmpty();
        }

        public void UserInfoPlayer()
        {
            if (Player.Glasses > 100 * Player.Level)
            {
                Player.Level++;
                Player.Glasses = 0;
                Player.Health += 100;
                Player.Damage++;
                Player.Armor++;
            }
            playerHealth.Content = "Жизненные показтели: " + Player.Health;
            playerArmor.Content = "Броня: " + Player.Armor;
            playerLevel.Content = "Уровень: " + Player.Level;
            playerGlasses.Content = "Опыт: " + Player.Glasses;
            playerMoney.Content = "Монеты: " + Player.Money;
        }

        public void SelectEmpty()
        {
            int Id = new Random().Next(0,Emptys.Count);
            Empty = new Classes.PersonInfo(
                Emptys[Id].Name,
                Emptys[Id].Health,
                Emptys[Id].Armor,
                Emptys[Id].Level,
                Emptys[Id].Glasses,
                Emptys[Id].Money,
                Emptys[Id].Damage);
        }

        private void AttackPlayer(object sender, System.EventArgs e)
        {
            Player.Health -= Convert.ToInt32(Empty.Damage * 100f / (100f - Player.Armor));
            UserInfoPlayer();
        }

        private void AttackEmpty(object sender, MouseButtonEventArgs e)
        {
            Empty.Health -= Convert.ToInt32(Player.Damage * 100f / (100f - Empty.Armor));
            if (Empty.Health <= 0)
            {
                Player.Glasses += Empty.Glasses;
                Player.Money -= Empty.Money;
                UserInfoPlayer();
                SelectEmpty();
            }
            else
            {
                emptyHealth.Content = "Жизненные показтели: " + Empty.Health;
                emptyArmor.Content = "Броня: " + Empty.Armor;
            }
        }
    }
}
