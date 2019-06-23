using Phone_Store_Management.DAO;
using Phone_Store_Management.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Phone_Store_Management.UserControls
{
    /// <summary>
    /// Interaction logic for UCStatistics.xaml
    /// </summary>
    public partial class UCStatistics : UserControl
    {
        public UCStatistics()
        {
            InitializeComponent();
            LoadPieChartData();
        }
        private void LoadPieChartData()
        {
            //Get all bill details
            List<BillDetail> list = new BillDetailDAO().GetAll();
            //Return if list contains no products
            if (list.Count() == 0)
                return;
            //Only get productID and unit price
            List<KeyValuePair<string, double>> sources = new List<KeyValuePair<string, double>>{ };
            foreach (BillDetail bd in list)
            {
                sources.Add(new KeyValuePair<string, double>(bd.ProductId.ToString(), bd.UnitPrice));
            }
            //Sum duplicated value
            List<KeyValuePair<string, double>> result = new List<KeyValuePair<string, double>> { };
            foreach (KeyValuePair<string, double> pair in sources)
            {
                if (result.FindIndex(x => x.Key == pair.Key) < 0)
                {
                    double total = sources.Where(x => x.Key == pair.Key).Sum(x => x.Value);
                    result.Add(new KeyValuePair<string, double>(pair.Key, total));
                }
            }
            //Replace key with Product DisplayName
            ProductDAO productDAO = new ProductDAO();
            for (int i=0;i<result.Count();i++)
            {
                result[i] = new KeyValuePair<string, double>(productDAO.Get(int.Parse(result[i].Key)).DisplayName, result[i].Value);
            }
            ((PieSeries)mcChart.Series[0]).ItemsSource = result;
        }
    }
}
