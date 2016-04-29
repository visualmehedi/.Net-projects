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
using Labb17bV2.Repositories.Contexts;
using Labb17bV2.Repositories;
using Labb17bV2.Services;

namespace Labb17bV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private IRepository repository;
        private decimal gadgetAprice = 0;
        private decimal orderValue = 0;
        private decimal orderSum = 0;
        private CustomerType customertype;
        public MainWindow()
        {
            InitializeComponent();

            this.repository = new Repository();

            var customernames = repository.Customers().Select(c => c.CustomerName);
            comboCustomer.ItemsSource = customernames;
            // Default kund
            comboCustomer.SelectedIndex = 0;


            var gadgetnames = repository.Gadgets().Select(g => g.GadgetName);
            comboGadgets.ItemsSource = gadgetnames;
            // Default Gadget
            comboGadgets.SelectedIndex = 0;



        }

        private void selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Vald kund
            var selectedCustomer = comboCustomer.SelectedItem.ToString();

            // Ordervärde
            this.orderValue = repository.Customers().Where(c => c.CustomerName == (string)comboCustomer.SelectedItem).Select(c => c.OrderValue).First();
            lblOrderValueResult.Content = string.Format("{0} kr", this.orderValue.ToString("F"));

            // Kundtyp
            this.customertype = CalculationService.getCustomerType(this.orderValue);
            lblCustomerTypeResult.Content = customertype.ToString();

            updateView();

        }

        private void gadget_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            // Vald Gadget
            var selectedGadget = repository.Gadgets().Where(g => g.GadgetName == (string)comboGadgets.SelectedItem);
            this.gadgetAprice = selectedGadget.First().Price;
            lblAprisResult.Content = string.Format("{0} kr", this.gadgetAprice.ToString("F"));

            updateView();
        }

        private void tbxOrderAntal_MouseLeave(object sender, MouseEventArgs e)
        {
            // Valt antal
            lblSummaResult.Content = string.Format("{0} kr", (int.Parse(tbxOrderAntal.Text) * this.gadgetAprice).ToString("F"));



            updateView();
        }

        private void updateView()
        {
            // summa
            this.orderSum = int.Parse(tbxOrderAntal.Text) * this.gadgetAprice;
            lblSummaResult.Content = string.Format("{0} kr", this.orderSum.ToString("F"));

            // Rabatt
            decimal discount = CalculationService.getDiscount(this.customertype, this.orderSum);
            lblRabattResult.Content = string.Format("{0} kr", discount.ToString("F"));

            // Att betala
            decimal toPay = this.orderSum - discount;
            lblBetalaResult.Content = string.Format("{0} kr", toPay.ToString("F"));
        }


        // ************ Admin view ******************
        private void btnAddCostomer_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new CustomerDataStore())
            {
                Customer customer = new Customer();
                customer.CustomerName = tbxAddCustomer.Text;
                customer.OrderValue = (decimal)int.Parse(tbxAddOrderValue.Text);

                db.Customers.Add(customer);
                db.SaveChanges();

            }

        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new Labb17OriginalContext())
            {
                Gadget gadget = new Gadget();
                gadget.GadgetName = tbxProductName.Text;
                gadget.Price = (decimal)int.Parse(tbxProductPrice.Text);

                db.Gadgets.Add(gadget);
                db.SaveChanges();

            }
        }

        private void btnToPay_Click(object sender, RoutedEventArgs e)
        {
            updateView();
        }


    }
}
