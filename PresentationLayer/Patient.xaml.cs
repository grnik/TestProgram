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
    /// Логика взаимодействия для Patient.xaml
    /// </summary>
    public partial class Patient : Window
    {
        public Patient()
        {
            InitializeComponent();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            PatientBL patient;
            try
            {
                patient = Get();
            }
            catch (Exception)
            {
                MessageBox.Show("Не верно указаны данные.");
                return;
            }
            try
            {
                patient.Save();
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось сохранить данные.");
                return;
            }
            Close();
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private PatientBL Get()
        {
            PatientBL patient = new PatientBL()
            {
                Id = string.IsNullOrEmpty(txtId.Text) ? Guid.Empty : new Guid(txtId.Text),
                FIO = txtFIO.Text,
                Gender = (Gender)cbSex.SelectedIndex,
                Birth = Convert.ToDateTime(txtBirth.Text),
                Address = txtAddress.Text,
                Phone = txtPhone.Text
            };
            return patient;
        }

        public void Set(PatientBL patient)
        {
            txtId.Text = patient.Id.ToString();
            txtFIO.Text = patient.FIO;
            cbSex.SelectedIndex = (int)patient.Gender;
            txtBirth.Text = patient.Birth.ToString("dd/MM/yyyy");
            txtAddress.Text = patient.Address;
            txtPhone.Text = patient.Phone;
        }
    }
}
