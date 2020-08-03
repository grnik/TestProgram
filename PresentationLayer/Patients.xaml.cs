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
    /// Логика взаимодействия для Patients.xaml
    /// </summary>
    public partial class Patients : Window
    {
        private PatientBL _choose = null;

        public Patients()
        {
            InitializeComponent();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = new Patient();
            patient.ShowDialog();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            var items = PatientBL.GetAll();
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                items = items.FindAll(p => p.FIO.Contains(txtSearch.Text));
            }
            lvPatients.ItemsSource = items;
        }

        private void btEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lvPatients.SelectedItem == null)
            {
                MessageBox.Show("Выберите пациента");
                return;
            }
            Patient patient = new Patient();
            patient.Set((PatientBL)lvPatients.SelectedItem);
            patient.ShowDialog();
        }

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            Window_Activated(sender, null);
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvPatients.SelectedItem == null)
            {
                MessageBox.Show("Выберите пациента");
                return;
            }
            PatientBL patient = (PatientBL)lvPatients.SelectedItem;
            string res = patient.Delete();
            if (!string.IsNullOrEmpty(res))
                MessageBox.Show(res);

            Window_Activated(sender, null);
        }

        /// <summary>
        /// Выбираем пациента
        /// </summary>
        /// <returns></returns>
        public static PatientBL Choose()
        {
            Patients patients = new Patients();
            patients.btChoose.Visibility = Visibility.Visible;
            patients.ShowDialog();

            return patients._choose;
        }

        private void btChoose_Click(object sender, RoutedEventArgs e)
        {
            if (lvPatients.SelectedItem == null)
            {
                MessageBox.Show("Выберите пациента");
                return;
            }
            _choose = (PatientBL)lvPatients.SelectedItem;
            Close();
        }

        private void lvPatients_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            btChoose_Click(sender, null);
        }
    }
}
