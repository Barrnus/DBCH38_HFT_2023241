using DBCH38_HFT_2023241.Models;
using DBCH38_SZTGUI_202320242.WpfClient.VMs;
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
using System.Windows.Shapes;

namespace DBCH38_SZTGUI_202320242.WpfClient
{
    /// <summary>
    /// Interaction logic for NonCrudWindow.xaml
    /// </summary>
    public partial class NonCrudWindow : Window
    {
        public NonCrudWindow(string message, object values)
        {
            InitializeComponent();
            tb_noncrud.Text = message;
            if (values is List<string>)
            {
                foreach (var item in (List<string>)values)
                {
                    lb_noncrud.Items.Add(item);
                }
            }
            else if (values is List<DBCH38_HFT_2023241.Models.Task>) 
            {
                foreach (var item in (List<DBCH38_HFT_2023241.Models.Task>)values)
                {
                    lb_noncrud.Items.Add(item.Type);
                }
            }
            else
            {
                foreach (var item in (List<Priority>)values)
                {
                    lb_noncrud.Items.Add(item.Value);
                }
            }
        }
    }
}
