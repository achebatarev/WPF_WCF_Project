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
using ServiceReference1;

namespace WpfApp1
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
/*            Person p = new Person();
            *//*p.Id = Convert.ToInt32(textbox1.Text);
            p.Name = textbox2.Text;
            p.Age = Convert.ToInt32(textbox3.Text);*//*

            CalculatorClient service = new CalculatorClient();
            if ( service.InsertPerson(p) == 1)
            {
                MessageBox.Show("Success");
            }*/
        }

        private void ButtonInsertClick(object sender, RoutedEventArgs e)
        {
            Customer c = new Customer()
            {
                FirstName = textbox1.Text,
                LastName = textbox2.Text,
                Phone = textbox3.Text
            };
            ServiceClient service = new ServiceClient();
            if (service.InsertCustomer(c) == 1) 
            {
                MessageBox.Show("Customer is added");
            }
        }

        private void ButtonUpdateClick(object sender, RoutedEventArgs e)
        {
            Customer c = new Customer()
            {
                FirstName = textbox1.Text,
                LastName = textbox2.Text,
                Phone = textbox3.Text
            };

            ServiceClient service = new ServiceClient();
            if (service.UpdateCustomerPhone(c) == 1)
            {
                MessageBox.Show("Customer is updated");
            }
        }

        private void ButtonReadClick(object sender, RoutedEventArgs e)
        {
            ServiceClient service = new ServiceClient();
            output.ItemsSource = service.GetAllCustomers();
        }

    }
}
