﻿using System;
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

namespace Pract5
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

        Triangle triangle;

        private void Очистить_Click(object sender, RoutedEventArgs e)
        {
            inputValue1.Text = null;
            inputValue2.Text = null;
            inputValue3.Text = null;
            inputValueA.Text = null;
            inputValueB.Text = null;
            inputValueC.Text = null;
            result.Text = null;
            triangle.ClearTriangle();
        }

        private void Выход_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void О_Программе_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Создать класс Triangle (треугольник) с полями-сторонами. " +
                "Создать необходимые методы и свойства.Определить метод вычисления периметра. " +
                "Создать перегруженные методы SetParams, для установки параметров объекта, " +
                "том числе увеличения размеров треугольника в 2 раза.");
        }

        private void Рассчитать_Click(object sender, RoutedEventArgs e)
        {
            bool checkValue1 = uint.TryParse(inputValue1.Text, out uint value1);
            bool checkValue2 = uint.TryParse(inputValue2.Text, out uint value2);
            bool checkValue3 = uint.TryParse(inputValue3.Text, out uint value3);

            if (!(checkValue1 && checkValue2 && checkValue3))
            {
                MessageBox.Show("Данные введены неверно!");
                return;
            }
            triangle = new Triangle(value1, value2, value3);
            uint res = triangle.PerimeterTriangle();
            result.Text = res.ToString();
        }

        private void Изменить_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                uint valueA = uint.Parse(inputValueA.Text);
                uint valueB = uint.Parse(inputValueB.Text);
                uint valueC = uint.Parse(inputValueC.Text);
                if (!(inputValueA.Text == null && inputValueB.Text == null && inputValueC.Text == null))
                {
                    triangle.SetParams(valueA, valueB, valueC);
                    inputValue1.Text = inputValueA.Text;
                    inputValue2.Text = inputValueB.Text;
                    inputValue3.Text = inputValueC.Text;
                    Рассчитать_Click(calculate, null);

                    inputValueA.Text = null;
                    inputValueB.Text = null;
                    inputValueC.Text = null;
                }
                else if (inputValueC.Text == null)
                {
                    triangle.SetParams(valueA, valueB);
                    inputValue1.Text = inputValueA.Text;
                    inputValue2.Text = inputValueB.Text;
                    Рассчитать_Click(calculate, null);

                    inputValueA.Text = null;
                    inputValueB.Text = null;
                }
                else if (inputValueB.Text == null && inputValueC.Text == null)
                {
                    triangle.SetParams(valueA);
                    inputValue1.Text = inputValueA.Text;
                    Рассчитать_Click(calculate, null);

                    inputValueA.Text = null;
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("сначала создайте треугольник");
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Данные должны быть больше 0");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Увеличить_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                triangle.IncreaseLength();
                inputValue1.Text = $"{triangle.Length1}";
                inputValue2.Text = $"{triangle.Length2}";
                inputValue3.Text = $"{triangle.Length3}";
                Рассчитать_Click(calculate, null);
            }
            catch
            {
                MessageBox.Show("Сначала создайте треугольник");
            }
        }
    }
}