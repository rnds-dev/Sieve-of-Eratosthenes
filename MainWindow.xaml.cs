using System;
using System.Collections.Generic;
using System.Windows;
using System.Threading.Tasks;


namespace Sieve_of_Eratosthenes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //отрисовка компонентов из отдельного файла xaml
            InitializeComponent(); 
        }

        int start, end;
        async void SieveOfEratosthenes()
        {
            
            string filler = TypeResultLine.IsChecked == true ? " " : "\n";
            string s = "";

            if (end > 100000) ResultTextBox.Text = "Получение результата, ожидайте...";
            
            await Task.Run(() =>
            {
                //Создание массива булевых переменных
                List<bool> array = new List<bool>(end);

                //Заполнение массива
                for (int i = 0; i <= end; i++) array.Add(true);

                //Алгоритм - РЕШЕТО ЭРАТОСФЕНА
                for (int i = 2; i * i <= end; i++)
                    if (array[i])
                        for (int j = i * i; j <= end; j += i)
                            array[j] = false;

                if (start < 2) start = 2;

                for (int i = start; i < array.Count; i++)
                    if (array[i])
                        s += Convert.ToString(i) + filler;

            });
            ResultTextBox.Text = s;

        }

        private void GetResult(object sender, RoutedEventArgs e)
        {
            try
            {
                start = Convert.ToInt32(InputStart.Text);
                end = Convert.ToInt32(InputEnd.Text);
            }
            catch (System.FormatException)
            {
                ResultTextBox.Text = "Неверный ввод! Допустимы только целые числа";
                return;
            }

            if (start > end) ResultTextBox.Text = "Начало диапазона должно быть меньше его конца";
            else if (start < 0) ResultTextBox.Text = "Начало диапазона должно быть больше нуля";
            else SieveOfEratosthenes();


            return;
        }
    }
}
