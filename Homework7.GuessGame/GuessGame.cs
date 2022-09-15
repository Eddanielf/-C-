using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Homework7.GuessGame
{
    public partial class GuessGame : Form
    {
        private Random random = new Random();
        private int computerNumber;
        private int userNumber;
        
        public GuessGame()
        {
            InitializeComponent();
            textBox1.Visible = true;
            labelUserNumber.Visible = true;
            buttonCheck.Visible = true;
            computerNumber = random.Next(99) + 1;
        }
            
        private void buttonCheck_Click (object sender, EventArgs e)
        {
            userNumber = int.Parse(textBox1.Text);

            if (userNumber > computerNumber && userNumber < 101)
                labelReact.Text = $"{userNumber} больше загаданного числа.";
            else if (userNumber < computerNumber && userNumber > 0)
                labelReact.Text = $"{userNumber} меньше загаданного числа.";
            else if (userNumber == computerNumber)
            {
                labelReact.Text = $"Поздравляем! Загаданное число - {computerNumber}";
                labelUserNumber.Visible = false;
                textBox1.Visible = false;
                buttonCheck.Visible = false;
            }
            else
                labelReact.Text = "Ввод некорректен. Укажите число от 1 до 100";
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            labelReact.Text = "Компьютер загадал число.";
            textBox1.Visible = true;
            textBox1.Text = " ";
            labelUserNumber.Visible = true;
            computerNumber = random.Next(99) + 1;
        }

        private void buttonRules_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Компьютер загадывает число от 1 до 100. \nВведите число в строку и нажмите кнопку 'Проверить'. Компьютер сообщит Вам, больше " +
                "или меньше загаданное число указанного Вами. \nПриятной игры!");
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор: Васильева Серафима.\nПрограмма создана в рамках обучения на курсе 'Основы языка C#' в GeekBrains.\n14.09.22 \n(c)Eddaniel");
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}