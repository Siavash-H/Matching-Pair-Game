





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
            Label clickLable = sender as Label;
            if (clickLable != null)
            {
                if (clickLable.ForeColor == Color.Black)
                {
                    return;

                if(firstClick == null)
                { 
                    firstClick = clickLable;
                    firstClick.ForeColor = Color.Black;
                        return;

                }
                }
            }
        }




        public Game()
        {
            //label_Click(object );
            InitializeComponent();
            AssignRandomTobox();
        }
    }
}