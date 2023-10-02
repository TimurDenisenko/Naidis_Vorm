namespace Naidis_Vorm
{
    public partial class MyForm : Form
    {
        Button btn;
        int i;
        public MyForm()
        {
            //InitializeComponent();
            this.Width = 200;
            this.Height = 200;
            btn = new Button();
            btn.Height = 70;
            btn.Width = 70;
            btn.Text= "valjuta";
            btn.Location = new Point(10,20);
            this.Controls.Add(btn);
        }

        public MyForm(int width, int height, string name)
        {
            //InitializeComponent();
            this.Width = width;
            this.Height = height;
            this.Text = name;
            btn = new Button();
            btn.Height = 70;
            btn.Width = 70;
            btn.Text= Convert.ToString(i);
            btn.Location = new Point(10,20);
            this.Controls.Add(btn);
            btn.Click += Btn_Click;
        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            i+=1;
            btn.Text= Convert.ToString(i);
            MyForm form = new MyForm();
            form.ShowDialog();
        }
    }
}