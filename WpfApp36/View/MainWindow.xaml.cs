using System;
using System.Collections.Generic;
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
using WpfApp36.Core;
using WpfApp36.View;
using WpfApp36.Models;

namespace WpfApp36
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DbModelContext.DB = new test01Entities1();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DbModelContext.DB.Users.Add(new Users()
                {
                    UserLogin = Tblogin.Text,
                    Password = PbPassword.Password,
                    Phone = TbPhone.Text,
                    Email = TbEmail.Text
                });
                DbModelContext.DB.SaveChanges();
                MessageBox.Show("Данные успешно сохранены",
                                "Системное сообщение",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),
                                "Системное сообщение",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }

        private void Run_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new InfoWindow().Show();
            Close();
        }
    }
}
