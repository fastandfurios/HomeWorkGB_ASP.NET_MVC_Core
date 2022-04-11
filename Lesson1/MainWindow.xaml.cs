using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace Lesson1
{
    public partial class MainWindow
    {
        private readonly IList<long> _numbers = new List<long>();
        private const int _factor = 1000;
        private int _milliseconds;
        private Thread? _thread;

        public MainWindow()
        {
            InitializeComponent();
        }

        //Решение задачи 1
        private void Button_Click_Start(object sender, RoutedEventArgs e)
        {
            Numbers.Text = "";
            _thread = new Thread(() => EnumerableFibonacci());
            _thread.Start();
        }

        //Решение задачи 3
        private void Button_Click_Stop(object sender, RoutedEventArgs e) => _thread?.Interrupt();

        private void EnumerableFibonacci()
        {
            try
            {
                foreach (var number in GetNumberFibonacci())
                {
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, () =>
                    {
                        Thread.Sleep(_milliseconds);
                        Numbers.Text += $" {number}";
                    });
                }
            }
            catch (OverflowException ex)
            {
                Debug.WriteLine(ex.Message);
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, () => Numbers.Text += $" {ex.Message}");
            }
            catch (ThreadInterruptedException ex)
            {
                Debug.WriteLine(ex.Message);
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, () => Numbers.Text += " Sequence Stop!");
            }
        }

        private IEnumerable<long> GetNumberFibonacci()
        {
            long number = 0;

            for (int i = 0; ; i++)
            {
                if (i is 0 or 1)
                {
                    _numbers.Add(i);
                    yield return i;
                }
                else
                {
                    try
                    {
                        checked
                        {
                            number = _numbers[i - 2] + _numbers[i - 1];
                            _numbers.Add(number);
                        }
                    }
                    finally { }

                    yield return number;
                }
            }
        }

        //Решение задачи 2
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
          => new Thread(() =>
             {
                 Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, () =>
                 {
                     _milliseconds = (int)(Slider.Value * _factor);
                     Interval.Text = $"{Slider.Value:0.0} с";
                 });
             })
          { Name = "Slider" }.Start();
    }
}
