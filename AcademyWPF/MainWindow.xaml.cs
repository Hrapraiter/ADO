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

using DBtools;
using System.Configuration;
using System.Runtime.InteropServices;

namespace AcademyWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Connector connector;
        DataGrid[] tables;
        public MainWindow()
        {
            AllocConsole();
            InitializeComponent();
            connector = new Connector(ConfigurationManager.ConnectionStrings["PV_522_Import"].ConnectionString);
            tables = new DataGrid[] {dgvStudents , dgvGroups , dgvDirections ,  dgvDisciplines , dgvTeachers};
            tabControl.SelectedIndex = 0;
            tabControl_SelectionChanged(tabControl, null);
        }
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(tabControl.SelectedIndex);
            tables[tabControl.SelectedIndex].ItemsSource = connector.Load($"SELECT * FROM {(tabControl.SelectedItem as TabItem).Header}").DefaultView;
            statusBarCount.Text = $"Колличество записей: {tables[tabControl.SelectedIndex].Items.Count - 1}";
        }
    }
}
