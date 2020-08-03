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
        VisitTypeBL _choose = null;

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
            if(string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Укажите название");
                return;
            }
            VisitTypeBL visitType = new VisitTypeBL(txtName.Text);
            string res = visitType.Save();
            if (!string.IsNullOrEmpty(res))
                MessageBox.Show("Не могу сохранить данные. Ошибка:" + res);

            Window_Loaded(sender, e);
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvVisitTypes.SelectedItem == null)
            {
                MessageBox.Show("Выберите тип");
                return;
            }
            VisitTypeBL type = (VisitTypeBL)lvVisitTypes.SelectedItem;
            string res = type.Delete();
            if (!string.IsNullOrEmpty(res))
                MessageBox.Show(res);

            Window_Loaded(sender, null);
        }

        /// <summary>
        /// Выбираем тип
        /// </summary>
        /// <returns></returns>
        public static VisitTypeBL Choose()
        {
            VisitTypes visits = new VisitTypes();
            visits.btChoose.Visibility = Visibility.Visible;
            visits.ShowDialog();

            return visits._choose;
        }

        private void btChoose_Click(object sender, RoutedEventArgs e)
        {
            if (lvVisitTypes.SelectedItem == null)
            {
                MessageBox.Show("Выберите пациента");
                return;
            }
            _choose = (VisitTypeBL)lvVisitTypes.SelectedItem;
            Close();
        }

        private void lvVisitTypes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            btChoose_Click(sender, null);
        }
    }
}
