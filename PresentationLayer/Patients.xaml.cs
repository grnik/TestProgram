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
            lvPatients.ItemsSource = PatientBL.GetAll();
        }

        private void btEdit_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = new Patient();
            patient.Set((PatientBL)lvPatients.SelectedItem);
            patient.ShowDialog();
        }
    }
}
