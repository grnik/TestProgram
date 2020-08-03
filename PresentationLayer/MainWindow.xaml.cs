using BusinessLayer;
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

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Refresh();
        }

        private void btVisitType_Click(object sender, RoutedEventArgs e)
        {
            VisitTypes visitTypes = new VisitTypes();

            visitTypes.ShowDialog();
        }

        private void btPatients_Click(object sender, RoutedEventArgs e)
        {
            Patients patients = new Patients();
            patients.ShowDialog();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            Visit visit = new Visit();
            visit.ShowDialog();

            Refresh();
        }

        private void btEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lvVisits.SelectedItem == null)
            {
                MessageBox.Show("Выберите визит");
                return;
            }
            Visit visit = new Visit();
            visit.Set((VisitBL)lvVisits.SelectedItem);
            visit.ShowDialog();

            Refresh();
        }

        void Refresh()
        {
            lvVisits.ItemsSource = VisitBL.GetAll();
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvVisits.SelectedItem == null)
            {
                MessageBox.Show("Выберите пациента");
                return;
            }
            VisitBL visit = (VisitBL)lvVisits.SelectedItem;
            string res = visit.Delete();
            if (!string.IsNullOrEmpty(res))
                MessageBox.Show(res);

            Refresh();
        }
    }
}
