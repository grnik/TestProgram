using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PresentationLayer
{
    /// <summary>
    /// Логика взаимодействия для VisitTypes.xaml
    /// </summary>
    public partial class VisitTypes : Window
    {
        public VisitTypes()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lvVisitTypes.ItemsSource = VisitTypeBL.GetAll();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            VisitTypeBL visitType = new VisitTypeBL(txtName.Text);
            string res = visitType.Save();
            if (!string.IsNullOrEmpty(res))
                MessageBox.Show("Не сохранить данные. Ошибка:" + res);
        }
    }
}
