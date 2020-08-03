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
using BusinessLayer;

namespace PresentationLayer
{
    /// <summary>
    /// Логика взаимодействия для Visit.xaml
    /// </summary>
    public partial class Visit : Window
    {
        PatientBL _ChoosePatient;
        VisitTypeBL _ChooseVisitType;

        public Visit()
        {
            InitializeComponent();
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            VisitBL visit;
            try
            {
                visit = Get();
            }
            catch (Exception)
            {
                MessageBox.Show("Не верно указаны данные.");
                return;
            }
            string res = visit.Save();
            if (!string.IsNullOrEmpty(res))
            {
                MessageBox.Show(res);
                return;
            }
            Close();
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private VisitBL Get()
        {
            VisitBL visit = new VisitBL()
            {
                Id = string.IsNullOrEmpty(txtId.Text) ? Guid.Empty : new Guid(txtId.Text),
                Date = Convert.ToDateTime(txtDate.Text),
                Diagnosis = txtDiagnosis.Text,
                Patient = _ChoosePatient,
                VisitType = _ChooseVisitType
            };
            return visit;
        }

        public void Set(VisitBL visit)
        {
            txtId.Text = visit.Id.ToString();
            txtDate.Text = visit.Date.ToString("dd/MM/yyyy");
            txtDiagnosis.Text = visit.Diagnosis;
            txtFIO.Text = visit.Patient.FIO;
            txtType.Text = visit.VisitType.Name;

            _ChoosePatient = visit.Patient;
            _ChooseVisitType = visit.VisitType;
        }

        private void txtFIO_GotFocus(object sender, RoutedEventArgs e)
        {
            _ChoosePatient = Patients.Choose();
            if (_ChoosePatient != null)
                txtFIO.Text = _ChoosePatient.FIO;

            txtId.Focusable = true;
        }

        private void txtType_GotFocus(object sender, RoutedEventArgs e)
        {
            _ChooseVisitType = VisitTypes.Choose();
            if (_ChooseVisitType != null)
                txtType.Text = _ChooseVisitType.Name;

            txtId.Focusable = true;
        }

        private void btCancel_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
