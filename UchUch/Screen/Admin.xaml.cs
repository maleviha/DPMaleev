using System;
using System.Threading;
using System.Collections.Generic;
using System.Data.Linq;
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
using System.Windows.Shapes;
using UchUch.Classes;

namespace UchUch.Screen
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        DataContext db = new DataContext(Properties.Settings.Default.conn);
        public Admin()
        {
            InitializeComponent();
            updateGridOrders();
        }
        private void updateGridOrders() //получение таблицы работ из базы
        {
            DG_Job.ItemsSource = db.GetTable<Job>().Where(a => a.status == 1);



        }
        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            var tempFIO = Sign.db.GetTable<Users>().Where(l => l.num == Users.LoginName).Select(s => s.fio).ToArray()[0];

            Hide();
            AddWorker w = new AddWorker();
            w.Show();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            var tempFIO = Sign.db.GetTable<Users>().Where(l => l.num == Users.LoginName).Select(s => s.fio).ToArray()[0];

            Hide();
            MessageBox.Show($"{tempFIO}, вы вернулись в профиль");
            Hub w = new Hub();
            w.Show();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
