using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.Design.AxImporter;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Naidis_Vorm
{
    public partial class TreeForm : Form
    {
        TreeView tree;
        Button btn,btn1,btn2;
        TreeNode tn = new TreeNode("Elemendid");
        Label lbl;
        TextBox txt_box;
        RadioButton r1, r2;
        CheckBox c1, c2;
        PictureBox pb,home,pizza;
        ListBox lb;
        DataGridView dgv;
        Kolmnurk kolmnurk;

        double i=0;
        public TreeForm()
        {
            this.Height = 600;
            this.Width = 800;
            this.Text = "Vorm põhielementidega";

            this.Paint += new PaintEventHandler(set_background);

            tree = new TreeView();
            tree.Dock = DockStyle.Top;
            tree.BorderStyle = BorderStyle.Fixed3D;
            tree.AfterSelect+=Tree_AfterSelect;
            //Button
            tn.Nodes.Add(new TreeNode("Nupp-Button"));
            btn = new Button();
            btn.Height = 50;
            btn.Width = 100;
            btn.Text= "Click!\n"+i;
            btn.Location = new Point(400, 200);
            btn.Click+=Btn_Click;
            btn.MouseWheel +=Btn_MouseWheel;

            //Label
            tn.Nodes.Add("Silt-Label");
            lbl = new Label();
            lbl.Text = "Pealkiri";
            lbl.Location = new Point(0, tree.Bottom);
            lbl.Size = new Size(this.Width, btn.Top-tree.Bottom);
            lbl.BackColor= Color.LightGray;
            lbl.BorderStyle= BorderStyle.Fixed3D;
            lbl.Font = new Font("Tahoma", 24);
            tree.Nodes.Add(tn);
            //tekstkast
            tn.Nodes.Add(new TreeNode("Tekstkast-Textbox"));
            txt_box= new TextBox();
            txt_box.Height = 50;
            txt_box.Width = 100;
            txt_box.Text = "...";
            txt_box.Location = new Point(btn.Left, btn.Top+btn.Height+20);
            txt_box.KeyDown += new KeyEventHandler(Txt_box_KeyDown);
            //Radiobutton
            tn.Nodes.Add(new TreeNode("Radionupp-Radiobutton"));
            r1 = new RadioButton();
            r1.Text = "See on must";
            r1.Location = new Point(btn.Left - 120, btn.Top);
            r1.CheckedChanged += new EventHandler(RadioButtons_Changed);
            r2 = new RadioButton();
            r2.Text = "See on must";
            r2.Location = new Point(r1.Left, r1.Top+r1.Height);
            r2.CheckedChanged += new EventHandler(RadioButtons_Changed);

            //Checkbox
            tn.Nodes.Add(new TreeNode("Valikkast-Checkbox"));
            c1 = new CheckBox();
            c1.Text = "0";
            c1.Location = new Point(r1.Left - 120, r1.Top);
            c1.CheckedChanged += C_CheckedChanged;
            c2 = new CheckBox();
            c2.Text = "0";
            c2.Location = new Point(c1.Left, c1.Top+c1.Height);
            c2.CheckedChanged += C_CheckedChanged;

            btn1 = new Button();
            btn1.Height = 50;
            btn1.Width = 100;
            btn1.Text = "Teadma";
            btn1.Location = new Point(c2.Left, c2.Bottom);
            btn1.Click += Btn1_Click;

            //Image
            tn.Nodes.Add(new TreeNode("Pilt-Image"));
            pb = new PictureBox();
            pb.Location = new Point(btn.Right+50,btn.Top);
            pb.Image = new Bitmap("../../../clock.png");
            pb.Size = new Size(100, 100);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.BorderStyle = BorderStyle.Fixed3D;

            pizza = new PictureBox();
            pizza.Location = new Point(pb.Location.X,pb.Location.Y);
            pizza.Image = new Bitmap("../../../pizza.png");
            pizza.Size = new Size(100, 100);
            pizza.SizeMode = PictureBoxSizeMode.Zoom;

            home = new PictureBox();
            home.Location = new Point(pb.Location.X, pb.Location.Y);
            home.Image = new Bitmap("../../../home.png");
            home.Size = new Size(100, 100);
            home.SizeMode = PictureBoxSizeMode.Zoom;

            //Loetelu
            tn.Nodes.Add(new TreeNode("Loetelu-Listbox"));
            lb = new ListBox();
            lb.Height = 20;
            lb.Location = new Point(c1.Left-150,c1.Top);

            btn2 = new Button();
            btn2.Height = 50;
            btn2.Width = lb.Width;
            btn2.Text = "Lisa";
            btn2.Location = new Point(lb.Left, lb.Bottom);
            btn2.Click +=Btn2_Click;

            lb.KeyDown+=Lb_KeyDown;

            //Data 
            tn.Nodes.Add(new TreeNode("DataGridView"));
            DataSet ds = new DataSet("XML fail. Menüü");
            ds.ReadXml(@"..\..\..\food.xml");
            dgv = new DataGridView();
            dgv.Location = new Point(0,pb.Bottom+70);
            dgv.AutoSize = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.DataSource = ds;
            dgv.AutoGenerateColumns = true;
            dgv.DataMember = "food";

            //Kolmnurk vorm
            tn.Nodes.Add(new TreeNode("Kolmnurk"));

            ControlsAdd(new Control[] {tree}, 
            new Control[] { btn, lbl, txt_box, r1, r2, c1, c2, pb, pizza, home, btn1, lb, btn2, dgv });         
        }

        private void Lb_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (lb.SelectedItem!=null)
                {
                    lb.Items.Remove(lb.SelectedItem);
                    if (lb.Items.Count<7)
                    {
                        lb.Height-=20;
                        lb.Height+=20;
                        btn2.Location =new Point(lb.Left, lb.Bottom);
                    }
                }
            }
        }

        private void Btn2_Click(object? sender, EventArgs e)
        {
            string tekst = Interaction.InputBox("Lisa uus väli", "Pealkiri muutmine", "Väli");
            if (tekst.Length>0 && !lb.Items.Contains(tekst))
            {
                lb.Items.Add(tekst);
                if (lb.Height<=100)
                {
                    lb.Height+=20;
                    btn2.Location =new Point(lb.Left, lb.Bottom);
                }
            }
        }

        private void ControlsAdd([Optional] Control[] arrayVisibleTrue, Control[] arrayVisibleFalse)
        {
            if (arrayVisibleTrue != null)
            {
                foreach (Control item in arrayVisibleTrue)
                {
                    this.Controls.Add(item);
                }
            }
            foreach (Control item in arrayVisibleFalse)
            {
                    this.Controls.Add(item);      
                    item.Visible = false;
            }           
        }

        private void Btn1_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Kas sa oled kindel?", "Küsimus", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                if (c1.Checked == true && c2.Checked == true)
                {
                    btn1.Text = "True";
                    txt_box.Enabled = true;
                }
                else if (c2.Checked == true)
                {
                    btn1.Text = "False";
                    txt_box.Enabled = false;
                }
                else if (c1.Checked == true)
                {
                    btn1.Text = "False";
                    txt_box.Enabled = false;
                }
                else
                {
                    btn1.Text = "False";
                    txt_box.Enabled = false;
                }
            }
            else
            {
                btn1.Text = "Teadma";
            }
        }

        private void Txt_box_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult result = MessageBox.Show("Kas sa oled kindel?", "Küsimus", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (txt_box.Text.ToLower() == "pizza")
                    {
                        pb.Visible = false;
                        home.Visible = false;
                        pizza.Visible = true;
                    }
                    else if (txt_box.Text.ToLower() == "home")
                    {
                        pb.Visible = false;
                        pizza.Visible = false;
                        home.Visible = true;
                    }
                    else
                    {
                        pizza.Visible = false;
                        home.Visible = false;
                    }
                }
                else
                {
                    string tekst = Interaction.InputBox("Sisesta pealkiri", "Pealkiri muutmine", "Uus pealkiri");
                    if (tekst.Length>0) 
                    {
                        this.Text = tekst;
                    }
                }
            }
        }

        private void C_CheckedChanged(object? sender, EventArgs e)
        {
            if (c1.Checked == true && c2.Checked == true)
            {
                c1.Text = "1";
                c2.Text = "1";
            }
            else if (c2.Checked == true)
            {
                c1.Text = "0";
                c2.Text = "1";
                

            }
            else if (c1.Checked == true)
            {
                c1.Text = "1";
                c2.Text = "0";
            }
            else
            {
                c1.Text = "0";
                c2.Text = "0";
            }
        }

        private void RadioButtons_Changed(object? sender, EventArgs e)
        {
            if (r1.Checked == true)
            {
                r1.BackColor = Color.Black;
                r1.ForeColor = Color.White;
                r2.BackColor = Color.White;
                r2.ForeColor= Color.Black;
            }
            else 
            {
                r2.BackColor = Color.Black;
                r2.ForeColor = Color.White;
                r1.BackColor = Color.White;
                r1.ForeColor = Color.Black;
            }
        }

        private void Btn_MouseWheel(object? sender, MouseEventArgs e)
        {
            i+=1;
            btn.Text= "Click!\n"+i;
        }

        private void Tree_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            if (e.Node.Text=="Nupp-Button")
            {
                if (btn.Visible == false)
                {
                    btn.Visible = true;
                }
                else
                {
                    btn.Visible = false;
                }
            }
            else if (e.Node.Text == "Silt-Label")
            {
                if (lbl.Visible == false)
                {
                    lbl.Visible = true;
                }
                else
                {
                    lbl.Visible = false;
                }
            }
            else if (e.Node.Text == "Tekstkast-Textbox")
            {
                if (txt_box.Visible == false)
                {
                    txt_box.Visible = true;
                }
                else
                {
                    txt_box.Visible = false;
                }
            }
            else if (e.Node.Text == "Radionupp-Radiobutton")
            {
                if (r1.Visible == false)
                {
                    r1.Visible = true;
                    r2.Visible = true;
                }
                else
                {
                    r1.Visible = false;
                    r2.Visible = false;
                }
            }
            else if (e.Node.Text == "Pilt-Image")
            {
                if (pb.Visible == false)
                {
                    pb.Visible = true;
                }
                else
                {
                    pb.Visible = false;
                }
            }
            else if (e.Node.Text == "Loetelu-Listbox")
            {
                if (lb.Visible == false)
                {
                    lb.Visible = true;
                    btn2.Visible = true;
                }
                else
                {
                    lb.Visible = false;
                    btn2.Visible = false;
                }
            }
            else if (e.Node.Text == "DataGridView")
            {
                if (dgv.Visible == false)
                {
                    dgv.Visible = true;
                }
                else
                {
                    dgv.Visible = false;
                }
            }
            else if (e.Node.Text == "Valikkast-Checkbox")
            {
                if (c1.Visible == false)
                {
                    c1.Visible = true;
                    c2.Visible = true;
                    btn1.Visible = true;
                }
                else
                {
                    c1.Visible = false;
                    c2.Visible = false;
                    btn1.Visible = false;
                }
            }
            else if (e.Node.Text == "Kolmnurk")
            {
                  kolmnurk = new Kolmnurk();
                  kolmnurk.Show();
            }     
            tree.SelectedNode = null;
        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            i+=1;
            btn.Text= "Click!\n"+i;
            if (btn.BackColor==Color.Red)
            {
                btn.BackColor= Color.Green;
            }
            else if (btn.BackColor==Color.Green)
            {
                btn.BackColor= Color.Blue;
            }
            else
            {
                btn.BackColor= Color.Red;
            }
        }

        private void set_background(Object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush b = new LinearGradientBrush(gradient_rectangle, Color.FromArgb(0, 0, 0), Color.FromArgb(255, 255, 255), 65f);
            graphics.FillRectangle(b, gradient_rectangle);
        }
    }
}
