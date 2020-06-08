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

namespace fighterjetshooting
{
    
    public partial class Form4 : Form
    {
        System.Windows.Forms.Label[] scores =  new System.Windows.Forms.Label[12];
        int num = 0;

        public Form4()
        {
            InitializeComponent();
            AccessLabel();
            ReadDate();
        }

        private void ReadDate()
        {
            if(File.Exists(Form1.dataPath))
            {
                string[] content = File.ReadAllLines(Form1.dataPath);
                string[] contents = BubbleSort(content);
                foreach (string s in contents)
                {
                    if (num >= 12)
                    {
                        break;
                    }
                    else
                    {
                        scores[num].Text = s;
                        num++;
                    }
                }
            }
        }

        private string[] BubbleSort(string[] arr)
        {
            int temp;
            string temp_player;
            for (int j = 0; j <= arr.Length - 2; j++)
            {
                if(j % 2 == 0)
                {
                    continue;
                }
                for (int i = 0; i <= arr.Length - 2; i++)
                {
                    if (i % 2 == 0)
                    {
                        continue;
                    }
                    if (Convert.ToInt32(arr[i]) < Convert.ToInt32(arr[i + 2]))
                    {
                        temp = Convert.ToInt32(arr[i+2]);
                        temp_player = arr[i + 1];
                        arr[i + 1] = arr[i - 1];
                        arr[i - 1] = temp_player;
                        arr[i + 2] = Convert.ToString(arr[i]);
                        arr[i] = Convert.ToString(temp);
                    }
                }
            }
            return arr;
        }
        private void AccessLabel()
        {
            scores[0] = Score_Username_1;
            scores[1] = Score_units_1;
            scores[2] = Score_Username_2;
            scores[3] = Score_units_2;
            scores[4] = Score_Username_3;
            scores[5] = Score_units_3;
            scores[6] = Score_Username_4;
            scores[7] = Score_units_4;
            scores[8] = Score_Username_5;
            scores[9] = Score_units_5;
            scores[10] = Score_Username_6;
            scores[11] = Score_units_6;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void ReplayButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
}
