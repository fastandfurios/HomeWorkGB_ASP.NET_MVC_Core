using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace Lesson1
{
    public partial class MainWindow
    {
        private IList<long> _numbers = new List<long>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var thread = new Thread(() => CountFibbonaci());
            thread.Start();
        }

        private void CountFibbonaci()
        {
            foreach (var item in CalulateData())
            {
                Numbers.Dispatcher.Invoke(() =>
                {
                    Numbers.Text += $" {item}";
                    Thread.Sleep(1000);
                }, DispatcherPriority.Background);
            }
        }

        private IEnumerable<string> CalulateData()
        {
            for (int i = 0; ; i++)
            {
                if (i is 0 or 1)
                {
                    _numbers.Add(i);
                    yield return i.ToString();
                }
                else
                {
                    _numbers.Add(_numbers[i - 2] + _numbers[i - 1]);
                    yield return (_numbers[i - 2] + _numbers[i - 1]).ToString();
                }
            }
        }
    }
}
