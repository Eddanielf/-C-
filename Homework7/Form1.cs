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

namespace Homework7
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private int computerNumber;
        private int userNumber;

        public Form1()
        {
            InitializeComponent();

            UpdateGameState(userNumber, random.Next(19) + 1);
        }

        private void UpdateGameState(int userNumber)
        {
            labelUserNumber.Text = $"Ваше число: {userNumber}";
        }

        private void UpdateGameState(int userNumber, int computerNumber)
        {
            UpdateGameState(userNumber);
            this.computerNumber = computerNumber;
            labelComputerNumber.Text = $"Загаданное число: {computerNumber}";
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            //userNumber = 0;
            UpdateGameState(userNumber *= 0, random.Next(19) + 1);
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            //userNumber = userNumber * 2;
            UpdateGameState(userNumber *= 2);
            CheckWin();
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            //userNumber = userNumber + 1;
            UpdateGameState(++userNumber);
            CheckWin();
        }

        public void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void buttonRules_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Правила игры 'Удвоитель'. \n Компьютер задает число. Ваша задача за минимальное количество действий его достичь. \n" +
                "'+1' добавляет единицу к вашему числу, 'x2' удваивает его. Удачи! ", "Удвоитель", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
            private void CheckWin()
        {
            if (userNumber == computerNumber)
            {
                MessageBox.Show("Вы успешно завершили игру!", "Удвоитель", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                if (MessageBox.Show("Желаете сыграть еще раз?", "Удвоитель", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UpdateGameState(userNumber *= 0, random.Next(19) + 1);
                }
                else
                {
                    Close();
                }
            }
            else if (userNumber > computerNumber)
            {
                //TODO: ...
            }
        }

        private void userNumber_Click()
        {

        }

        private void computerNumber_Click()
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
