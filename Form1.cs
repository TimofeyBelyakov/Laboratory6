using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Обработка нажатия цифр
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (display.Text == "0" || flagAction)
            {
                display.Text = "";
                flagAction = false;
            }

            if (display.Text.Length <= 12)
            {
                display.Text += (sender as Button).Text;
                flagLastAction = false;
            }
        }

        /// <summary>
        ///     Обработка нажатия разделяющей запятой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDot_Click(object sender, EventArgs e)
        {
            if (!display.Text.Contains(","))
            {
                display.Text += (sender as Button).Text;
                flagLastAction = false;
            }
        }

        double digit1 = 0,
               digit2 = 0,
               result = 0;
        char action = '@';
        bool flagAction = false,
             flagLastAction = false,
             flagDig1 = false,
             flagDig2 = false;

        /// <summary>
        ///     Обработкка нажатия очистки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCE_Click(object sender, EventArgs e)
        {
            display.Text = "0";
            digit1 = 0;
            digit2 = 0;
            action = '@';
            flagAction = false;
            flagLastAction = false;
            flagDig1 = false;
            flagDig2 = false;
        }

        /// <summary>
        ///     Обработка арифметических операций
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if(!flagLastAction) SetDigit();

            if (action != '@' && flagDig1 && flagDig2 && !flagLastAction)
            {
                DoAction();
                digit1 = result;
                flagDig2 = false;
            }
            
            action = (sender as Button).Text[0];
            flagAction = true;
            flagLastAction = true;
        }

        /// <summary>
        ///     Обработка нажатия знака равно
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEqual_Click(object sender, EventArgs e)
        {
            SetDigit();

            if (action != '@' && flagDig1 && flagDig2)
            {
                DoAction();
                flagDig1 = false;
                flagDig2 = false;
            }
        }

        /// <summary>
        ///     Метод, производящий расчёты и вывод результата
        /// </summary>
        private void DoAction()
        {
            switch (action)
            {
                case '+':
                    result = digit1 + digit2;
                    break;
                case '-':
                    result = digit1 - digit2;
                    break;
                case '*':
                    result = digit1 * digit2;
                    break;
                case '/':
                    result = digit1 / digit2;
                    break;
            }
            display.Text = result.ToString();
            Clipboard.SetDataObject(result.ToString());
        }

        /// <summary>
        ///     Устанавлявает числа
        /// </summary>
        private void SetDigit()
        {
            if (!flagDig1)
            {
                digit1 = Convert.ToDouble(display.Text);
                flagDig1 = true;
            }
            else if (!flagDig2)
            {
                digit2 = Convert.ToDouble(display.Text);
                flagDig2 = true;
            }
        }

        /// <summary>
        ///     Ввод цифр с клавиатуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.D0)
                button0.PerformClick();
            if (e.KeyValue == (char)Keys.D1)
                button1.PerformClick();
            if (e.KeyValue == (char)Keys.D2)
                button2.PerformClick();
            if (e.KeyValue == (char)Keys.D3)
                button3.PerformClick();
            if (e.KeyValue == (char)Keys.D4)
                button4.PerformClick();
            if (e.KeyValue == (char)Keys.D5)
                button5.PerformClick();
            if (e.KeyValue == (char)Keys.D6)
                button6.PerformClick();
            if (e.KeyValue == (char)Keys.D7)
                button7.PerformClick();
            if (e.KeyValue == (char)Keys.D8)
                button8.PerformClick();
            if (e.KeyValue == (char)Keys.D9)
                button9.PerformClick();
            if (e.KeyValue == (char)Keys.Oemcomma)
                buttonDot.PerformClick();
        }
    }
}
