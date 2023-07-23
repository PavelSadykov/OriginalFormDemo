using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;
using Button = System.Windows.Forms.Button;

namespace OriginalFormDemo
{
    public partial class Form1 : Form
    {
        Point pointStart; // точка для перемещения
        private void addCloseButton() 
        {
            // Кнопка закрытия
            Button buttonClose = new Button();
            buttonClose.Location = new Point(this.Width / 3, this.Height / 3);
            buttonClose.Text = "Х";
            buttonClose.Click += buttonClose_Click;
            this.Controls.Add(buttonClose); 
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void addChoiceForm()
        {
            ComboBox cmbChoice = new ComboBox();
            cmbChoice.Location = new Point(this.Width/3, this.Height/3 + 30);
            var items = new object[] { "normal", "ellipse", "polygon" };
            cmbChoice.Items.AddRange(items);
            cmbChoice.SelectedValueChanged += CmbChoice_SelectedValueChanged;
            this.Controls.Add(cmbChoice);
        }



        private void CmbChoice_SelectedValueChanged(object sender, EventArgs e)
        {
            OrigWindow.setOriginalForm(this, ((ComboBox)sender).SelectedItem.ToString());
        }

        public Form1()
        {
            InitializeComponent();
            addCloseButton();
            addChoiceForm();
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // если нажата левая кнопка мыши
            if (e.Button == MouseButtons.Left)
            {
                pointStart = new Point(e.X, e.Y);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // если нажата левая кнопка мыши
            if ((e.Button & MouseButtons.Left) != 0)
            {
                // получаем новую точку положения формы
                Point deltaPos = new Point(e.X - pointStart.X, e.Y - pointStart.Y);
                // устанавливаем положение формы
                this.Location = new Point(this.Location.X + deltaPos.X,
                  this.Location.Y + deltaPos.Y);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получение чисел из текстовых полей
            if (!double.TryParse(textBox1.Text, out double number1) || !double.TryParse(textBox2.Text, out double number2))
            {
                MessageBox.Show("Введите корректные числа.");
                return;
            }

            // Выполнение операции сложения
            double result = number1 + number2;

            // Отображение результата в поле вывода
            textBox3.Text = result.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox1.Text, out double number1) || !double.TryParse(textBox2.Text, out double number2))
            {
                MessageBox.Show("Введите корректные числа.");
                return;
            }

            // Выполнение операции сложения
            double result = number1 - number2;

            // Отображение результата в поле вывода
            textBox3.Text = result.ToString();
        }
    

        private void button3_Click(object sender, EventArgs e)
        {
        // Получение чисел из текстовых полей
        if (!double.TryParse(textBox1.Text, out double number1) || !double.TryParse(textBox2.Text, out double number2))
        {
            MessageBox.Show("Введите корректные числа.");
            return;
        }
        try
        {
            if (number2 == 0)
            {
                throw new DivideByZeroException("Деление на ноль недопустимо");
            }
            // Выполнение операции деления
            double result = number1 / number2;

            // Отображение результата в поле вывода
            textBox3.Text = result.ToString();

        }
        catch (DivideByZeroException ex)
        {
            //Обработка исключени деления на ноль
            MessageBox.Show(ex.Message);
        }
    }

        private void button4_Click(object sender, EventArgs e)
        {
        // Получение чисел из текстовых полей
        if (!double.TryParse(textBox1.Text, out double number1) || !double.TryParse(textBox2.Text, out double number2))
        {
            MessageBox.Show("Введите корректные числа.");
            return;
        }

        // Выполнение операции сложения
        double result = number1 * number2;

        // Отображение результата в поле вывода
        textBox3.Text = result.ToString();
    }
    }
}
