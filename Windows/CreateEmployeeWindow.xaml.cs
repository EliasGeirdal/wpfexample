using ChessBase.DAL;
using ChessBase.Extensions;
using ChessBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ChessBase.Windows
{
    /// <summary>
    /// Interaction logic for CreateEmployeeWindow.xaml
    /// </summary>
    public partial class CreateEmployeeWindow : Window
    {
        private readonly RefreshListDelegate refresh; // delegate object
        public CreateEmployeeWindow(RefreshListDelegate refresh)
        {
            InitializeComponent();
            this.refresh = refresh; // assign method to delegate
        }

        private void Exit_Window(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Create_Employee(object sender, RoutedEventArgs e)
        {
            if (errorCheck())
            {

                String name = EmployeeName.Text.Trim();
                String salary = EmployeeSalary.Text.Trim();

                // construct employee object
                Employee employee = new Employee(name, int.Parse(salary));
                MainWindow.context.Employees.Add(employee);

                MainWindow.context.SaveChanges();

                // refresh list of employees to include this.
                refresh(); // use delegate

                this.Close();
            }
        }

        private bool errorCheck()
        {
            if (EmployeeName.Text.isEmpty() || EmployeeSalary.Text.isEmpty())
            {
                MessageBox.Show("Empty fields not allowed.", "Error");
                return false;
            }

            // salary must be an integer
            string strRegex = @"(^[0-9]+$)";
            Regex re = new Regex(strRegex);

            if (!re.IsMatch(EmployeeSalary.Text.Trim()))
            {
                MessageBox.Show("Salary must be an integer", "Error");
                return false;
            }
            return true;
        }
    }
}
