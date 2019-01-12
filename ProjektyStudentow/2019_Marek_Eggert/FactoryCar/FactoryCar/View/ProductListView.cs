using FactoryCar.Model;
using FactoryCar.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace FactoryCar.View
{
    public partial class ProductListView : Form
    {
        CarDocument doc = new CarDocument();
        CarPresenter pres = new CarPresenter();
        BindingSource bs = new BindingSource();


        public ProductListView()
        {
            
            InitializeComponent();
       
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Car p = new Car();
            p.Name = txtProductName.Text;
            p.Speed = Decimal.Parse(txtPrice.Text);
            p.Battery = cbType.Text;
            bs.DataSource = pres.AddNewProduct(p);
        }
        
        private void ProductListView_Load(object sender, EventArgs e)
        {
            pres.OnInit();

            bs.DataSource = pres.document.CarList;
            grProducts.DataSource = bs;
            grProducts.AutoGenerateColumns = true;

            foreach (var item in Enum.GetValues(typeof(Currency)))
            {
                cbCurrency.Items.Add(item);
            }

            foreach (var item in Enum.GetValues(typeof(Model.Type)))
            {
                cbType.Items.Add(item);
            }
        }

        private void btnCalulate_Click(object sender, EventArgs e)
        {
            bs.DataSource = pres.Calulate(cbCurrency.SelectedItem.ToString());
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
        //zapis CSV
        private void ctxMenuCSV_Click(object sender, EventArgs e)
        {
            pres.WriteToCSV();
        }
        //zapis PDF
        private void ctxMenuPDF_Click(object sender, EventArgs e)
        {
            pres.WriteToTxt();
        }

        private void grProducts_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem(""));
                m.MenuItems.Add(new MenuItem("Copy"));
                m.MenuItems.Add(new MenuItem("Paste"));

                ctxMenu.Show(grProducts, new Point(e.X, e.Y));

            }
        }

        private void grProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}