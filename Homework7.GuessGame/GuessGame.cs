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
                labelReact.Text = $"{userNumber} ������ ����������� �����.";
            else if (userNumber < computerNumber && userNumber > 0)
                labelReact.Text = $"{userNumber} ������ ����������� �����.";
            else if (userNumber == computerNumber)
            {
                labelReact.Text = $"�����������! ���������� ����� - {computerNumber}";
                labelUserNumber.Visible = false;
                textBox1.Visible = false;
                buttonCheck.Visible = false;
            }
            else
                labelReact.Text = "���� �����������. ������� ����� �� 1 �� 100";
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            labelReact.Text = "��������� ������� �����.";
            textBox1.Visible = true;
            textBox1.Text = " ";
            labelUserNumber.Visible = true;
            computerNumber = random.Next(99) + 1;
        }

        private void buttonRules_Click(object sender, EventArgs e)
        {
            MessageBox.Show("��������� ���������� ����� �� 1 �� 100. \n������� ����� � ������ � ������� ������ '���������'. ��������� ������� ���, ������ " +
                "��� ������ ���������� ����� ���������� ����. \n�������� ����!");
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("�����: ��������� ��������.\n��������� ������� � ������ �������� �� ����� '������ ����� C#' � GeekBrains.\n14.09.22 \n(c)Eddaniel");
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