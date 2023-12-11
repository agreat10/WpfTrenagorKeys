using System;
using System.Collections;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTrenagorKeys
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Brush brush;
        string str = "xmlnshttpschemasmicrosoftcomwinfx2006xam";
        
        List<char> chars = new List<char>();
        int count = 0;
        int it = 0;        
        int failanswer = 0;
        int rightanswer = 0;
        public MainWindow()
        {
            InitializeComponent();           
            foreach (var item in str)
            {
                chars.Add(item);
                TextBlock TBstr = new TextBlock();
                TBstr.FontSize = 20;
                TBstr.FontWeight = FontWeights.Bold;
                TBstr.Width = 19;
                TBstr.TextAlignment = TextAlignment.Center;                
                TBstr.Text = item.ToString();
                SPstr.Children.Add(TBstr);
                count++;
            }   
        }
        
        
        private void OnKeyDown(object sender, KeyEventArgs e)
        {           
            List<StackPanel> myList = new List<StackPanel>();
            myList.Add(Ttilda);
            myList.Add(Ttab);
            myList.Add(Tcaps);
            myList.Add(Tshift);
            myList.Add(Tctrl);
            foreach (var el in myList)
            {
                foreach (var item in el.Children)
                {
                    if (item is Button)
                    {
                        if (Convert.ToString(e.Key) == ((Button)item).Name)
                        {
                            string x = " ";
                            var a = ((Button)item);
                            brush = a.Background;
                            var i = Brushes.Gray;
                            a.Background = Brushes.Yellow;
                            if (brush.ToString() == i.ToString()) { return; }
                            if(a.Content.ToString() == "Space") x = " ";                             
                            else   x = a.Content.ToString();
                           
                            TextBlock TBstr = new TextBlock();
                            if (chars[it].ToString() == x) { TBstr.Foreground = Brushes.Green; rightanswer++; }
                            else { TBstr.Foreground = Brushes.Red; failanswer++; }
                            TBstr.FontSize = 20;
                            TBstr.Width = 19;
                            TBstr.TextAlignment = TextAlignment.Center;                            
                            TBstr.FontWeight = FontWeights.Bold;
                            TBstr.Text = x;
                            SPstr1.Children.Add(TBstr);
                            textblock2.Text = failanswer.ToString();
                            textblock4.Text = rightanswer.ToString();
                            it++;
                            
                            if (it == count)
                            {
                                double x1 = (double)rightanswer / (double)count * 100;                                
                                MessageBox.Show($"Результат: {x1}% правильных ответов. ");
                                Environment.Exit(0);
                            }
                            return;
                        }
                    }
                }
            }          
        }
        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            List<StackPanel> myList = new List<StackPanel>();
            myList.Add(Ttilda);
            myList.Add(Ttab);
            myList.Add(Tcaps);
            myList.Add(Tshift);
            myList.Add(Tctrl);
            foreach (var el in myList)
            {
                foreach (var item in el.Children)
                {
                    if (item is Button)
                    {
                        if (Convert.ToString(e.Key) == ((Button)item).Name)
                        {
                            
                            var a = ((Button)item);
                            a.Background = brush;
                            return;
                        }
                    }
                }
            }
        }
    }
}
