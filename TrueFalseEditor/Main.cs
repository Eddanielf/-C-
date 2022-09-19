using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TrueFalseEditor
{
    public partial class Main : Form
    {
        TrueFalseEngine engine;

        public Main()
        {
            InitializeComponent();
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuItemNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                engine = new TrueFalseEngine(dlg.FileName);
                engine.Add("Банан - это фрукт?", false);
                engine.Save();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;
            }
        }

        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            if (engine == null)
            {
                MessageBox.Show("Файл не найден. Создайте файл.");

            }
            else
            {
                tbQuestion.Text = engine[(int)nudNumber.Value - 1].Text;
                checkTrue.Checked = engine[(int)nudNumber.Value - 1].TrueFalse;
            }
        }

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                engine = new TrueFalseEngine(dlg.FileName);
                engine.Load();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = engine.Count;
                nudNumber.Value = 1;
            }
        }

        private void menuItemSave_Click(object sender, EventArgs e)
        {
            if (engine == null)
            {
                MessageBox.Show("Файл не найден. Создайте файл.");

            }
            else
            {
                engine.Save();
            }
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vasileva Serafima\nGeekBrains C# course 2022\n(c) Eddaniel");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (engine == null)
            {
                MessageBox.Show("Файл не найден. Создайте файл.");
                                
            }
             else
            { 
                engine.Add($"#{engine.Count + 1}", true);
                nudNumber.Maximum = engine.Count;
                nudNumber.Value = engine.Count;
            }
        }
          
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (engine == null)
            {
                
                MessageBox.Show("Файл не найден. Создайте файл.");

            }
            else
            {
                engine[(int)nudNumber.Value - 1].Text = tbQuestion.Text;
                engine[(int)nudNumber.Value - 1].TrueFalse = checkTrue.Checked;
            }
                       
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (engine == null)
            {
                MessageBox.Show("Файл не найден. Создайте файл.");

            }
            else
            {
                engine.Remove((int)nudNumber.Value - 1);
                nudNumber.Maximum--;
                nudNumber.Value--;

            }
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
