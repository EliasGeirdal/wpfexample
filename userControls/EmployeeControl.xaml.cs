using ChessBase.DAL;
using ChessBase.Models;
using ChessBase.Windows;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace ChessBase.userControls
{
    /// <summary>
    /// Interaction logic for EmployeeControl.xaml
    /// </summary>
    public partial class EmployeeControl : UserControl
    {
        public EmployeeControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                System.Windows.Data.CollectionViewSource employeeViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["employeeViewSource"];

                MainWindow.context.Employees.Load();
                employeeViewSource.Source = MainWindow.context.Employees.Local;
            }
        }
        // method used in delegate in createEmployeeWindow
        private void RefreshEmployeeList()
        {
            System.Windows.Data.CollectionViewSource employeeViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["employeeViewSource"];

            MainWindow.context.Employees.Load();
            employeeViewSource.Source = MainWindow.context.Employees.Local;
        }

        private void Delete_Employee(object sender, RoutedEventArgs e)
        {
            // get the selected employee from list.
            if (employeeDataGrid.SelectedItem is Employee selectedEmployee)
            {
                // only delete it if an employee has been selected. Otherwise ignore.
                // find employee in database with matching id.
                var returnedEmployee = (from employee in MainWindow.context.Employees
                                        where employee.ID == selectedEmployee.ID
                                        select employee).ToList();
                // if there is a match (should very well be) remove it.
                if (returnedEmployee.Count > 0)
                {
                    MainWindow.context.Employees.Remove(returnedEmployee[0]);
                    MainWindow.context.SaveChanges();
                }
            }
            // unselect auto selected item.
            employeeDataGrid.SelectedItem = null;
        }

        private void Add_Employee(object sneder, RoutedEventArgs e)
        {
            CreateEmployeeWindow popup = new CreateEmployeeWindow(RefreshEmployeeList); // function passed as arguement
            popup.ShowDialog();
        }
    }
}
