﻿using System;
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
    }
}
