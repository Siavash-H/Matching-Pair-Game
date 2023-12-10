using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace  MatcingGame

{
    public partial class Game : Form
    {

        Label firstClick = null;
        Label secondClick = null;
        Random random = new Random();
        List<string> Icons = new List<string>()
            { "!","!","n","n","M","M","k","K",
              "W","W","L","L","S","S","R","R"
            };

        public Game()
        {
            //label_Click(object );
            InitializeComponent();
            AssignRandomTobox();
        }

        private void AssignRandomTobox()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLable = control as Label;
                if (iconLable != null)
                {
                    int randomNum = random.Next(Icons.Count);
                    iconLable.Text = Icons[randomNum];
                    iconLable.ForeColor = iconLable.BackColor;
                    Icons.RemoveAt(randomNum);


                }
            }
        }

        private void label_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
             return; 

            Label? clickLable = sender as Label;
            if (clickLable != null)
            {
                if (clickLable.ForeColor == Color.Black)
                    return;

                clickLable.ForeColor = Color.Black;
                if(firstClick == null)
                    { 
                    firstClick = clickLable;
                    firstClick.ForeColor = Color.Black;
                    return;
                    }
                
                secondClick = clickLable;
                secondClick.ForeColor = Color.Black;


                CheckWinner();
                if (firstClick.Text == secondClick.Text )
                {
                    firstClick = null;
                    secondClick = null;
                    return;
                }
                timer1.Start();
            }
        }

        private void Timer1_tick()
        {
            
            timer1.Stop();
            firstClick.ForeColor = firstClick.BackColor;
            secondClick.ForeColor = secondClick.BackColor;
            firstClick = null;
            secondClick = null;

        }

        private void CheckWinner()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconlabel = control as Label;
                if (iconlabel != null)
                {
                    if (iconlabel.ForeColor == iconlabel.BackColor)
                        return;
                }
            }
            MessageBox.Show("yeap that was it.");
            Close();
        }



    }
}