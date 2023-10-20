using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace Naidis_Vorm
{
    public partial class Kolmnurk: Form
    {
        Label lbl, lbl1, lbl2, lbl3;
        PictureBox pb;
        Button btn, btn1;
        ListBox lb, lb1;
        TextBox tb1, tb2, tb3;
        RadioButton rb1, rb2;
        Kolmnurk2 kolmnurk2;
        int j = 0;

        public Kolmnurk()
        {
            this.Height = 600;
            this.Width = 800;
            this.Text = "Kolmnurk";

            lbl = new Label();
            lbl.Text = "Kolmnurk";
            lbl.Location = new Point(0, 0);
            lbl.Size = new Size(this.Width, 50);
            lbl.BackColor = Color.LightGray;
            lbl.BorderStyle = BorderStyle.Fixed3D;
            lbl.Font = new Font("Tahoma", 24);
            lbl.TextAlign = ContentAlignment.MiddleCenter;

            pb = new PictureBox();
            pb.Location = new Point(this.Width-300,this.Height-300);
            pb.Image = new Bitmap("../../../triangle.png");
            pb.Size = new Size(200, 200);
            pb.SizeMode = PictureBoxSizeMode.Zoom;

            btn = new Button();
            btn.Height = 50;
            btn.Width = 200;
            btn.Text = "Käivitada";
            btn.Font = lbl.Font = new Font("Tahoma", 20);
            btn.Location = new Point(pb.Left, pb.Top - 150);
            btn.Click += Btn_Click;

            btn1 = new Button();
            btn1.Height = 50;
            btn1.Width = 200;
            btn1.Text = "Külg ja kõrgus";
            btn1.Font = lbl.Font = new Font("Tahoma", 20);
            btn1.Location = new Point(btn.Left, pb.Bottom);
            btn1.Click += Btn1_Click;

            lb = new ListBox();
            lb.Height = 310;
            lb.Width = 200;
            lb.Items.Add("Külg A: ");
            lb.Items.Add("Külg B: ");
            lb.Items.Add("Külg C: ");
            lb.Items.Add("Olemas: ");
            lb.Items.Add("Perimeeter: ");
            lb.Items.Add("Pindala: ");
            lb.Items.Add("Kõrgus A: ");
            lb.Items.Add("Kõrgus B: ");
            lb.Items.Add("Kõrgus C: ");
            lb.Items.Add("Mediaan A: ");
            lb.Items.Add("Mediaan B: ");
            lb.Items.Add("Mediaan C: ");
            lb.Items.Add("Nurk alpha: ");
            lb.Items.Add("Nurk beta: ");
            lb.Items.Add("Nurk gamma: ");
            lb.Items.Add("Poolitaja AB: ");
            lb.Items.Add("Poolitaja BC: ");
            lb.Items.Add("Poolitaja CA: ");
            lb.Items.Add("Nurga tüüp: ");
            lb.Items.Add("Külje tüüp: ");
            lb.Location = new Point(50, lbl.Bottom + 50);

            lb1 = new ListBox();
            if (j == 0)
            {
                foreach (var item in lb.Items)
                {
                    lb1.Items.Add(item);
                }
                j = 1;
            }

            lbl1 = new Label();
            lbl1.Text = "Külg A:";
            lbl1.Location = new Point(lb.Left, lb.Bottom + 25);
            lbl2 = new Label();
            lbl2.Text = "Külg B:";
            lbl2.Location = new Point(lb.Left, lb.Bottom + 50);
            lbl3 = new Label();
            lbl3.Text = "Külg C:";
            lbl3.Location = new Point(lb.Left, lb.Bottom + 75);

            tb1 = new TextBox();
            tb2 = new TextBox();
            tb3 = new TextBox();
            tb1.Height = 50;
            tb1.Width = 100;
            tb2.Height = 50;
            tb2.Width = 100;
            tb3.Height = 50;
            tb3.Width = 100;
            tb1.Location = new Point(lbl1.Left + 50, lbl1.Location.Y);
            tb2.Location = new Point(lbl2.Left + 50, lbl2.Location.Y);
            tb3.Location = new Point(lbl3.Left + 50, lbl3.Location.Y);

            rb1 = new RadioButton();
            rb1.Text = "Kolm külge";
            rb1.Location = new Point(btn.Left, btn.Bottom+20);
            rb1.CheckedChanged += CheckedChanged;
            rb1.Checked = true;
            rb2 = new RadioButton();
            rb2.Text = "Võrdkülgsed";
            rb2.Location = new Point(rb1.Left, rb1.Top + rb1.Height);
            rb2.CheckedChanged += CheckedChanged;

            ControlsAdd(new Control[] {lbl, pb, btn, lb, tb1, tb2, tb3, lbl1, lbl2, lbl3, rb1, rb2, btn1});
        }

        private void Btn1_Click(object? sender, EventArgs e)
        {
            kolmnurk2 = new Kolmnurk2();
            kolmnurk2.Show();
        }

        private void CheckedChanged(object? sender, EventArgs e)
        {
            tb1.Text = tb2.Text = tb3.Text  = "";
            if (rb1.Checked || rb2.Checked)
            {
                lb.Visible = btn.Visible = true;
                if (rb1.Checked)
                {
                    lbl1.Text = "Külg A:";
                    lbl2.Text = "Külg B:";
                    lbl3.Text = "Külg C:";
                    lbl1.Visible = lbl2.Visible = lbl3.Visible = tb1.Visible = tb2.Visible = tb3.Visible = true;
                }
                else if (rb2.Checked)
                {
                    lbl1.Text = "Külg:";
                    lbl1.Visible = tb1.Visible = true;
                    lbl2.Visible = lbl3.Visible = tb2.Visible = tb3.Visible = false;
                }
            }
        }

        private void Btn_Click(object? sender, EventArgs e)      
        {
            tb1.BackColor = Color.White;
            tb2.BackColor = Color.White;
            tb3.BackColor = Color.White;
            int o = 0;
            foreach (var item in lb1.Items)
            {
                lb.Items[o] = item;
                o++;
            }
            List<double> all;
            Triangle triangle;
            bool aB, bB, cB;
            aB = bB = cB = false;
            try
            {
                double a, b, c;
                c = a = b = 0;
                try { a = Convert.ToDouble(tb1.Text); aB = true; } catch (Exception) { a = 0; aB = false; }
                try { b = Convert.ToDouble(tb2.Text); bB = true; } catch (Exception) { b = 0; bB = false; }
                try { c = Convert.ToDouble(tb3.Text); cB = true; } catch (Exception) { c = 0; cB = false; }
                if (tb1.Text != "" && tb2.Text != "" && tb3.Text != "")
                {
                    triangle = new Triangle(a, b, c);
                }
                else if (tb1.Text != "" && tb2.Text == "" && tb3.Text == "")
                {
                    triangle = new Triangle(a);
                }
                else if (tb1.Text == "" && tb2.Text != "" && tb3.Text == "")
                {
                    triangle = new Triangle(b);
                }
                else if (tb1.Text == "" && tb2.Text == "" && tb3.Text != "")
                {
                    triangle = new Triangle(c);
                }
                else
                {
                    throw new Exception();
                }
                if (!triangle.On)
                {
                    throw new Exception();
                }
                all = triangle.All();
                string option = "{0,-20}\t{1,-20}";
                for (int i = 0; i < all.Count+1; i++)
                {
                    if (i<=3)
                    {
                        if (i==3)
                        {
                            lb.Items[i] = string.Format(option, lb.Items[i], triangle.On);
                        }
                        else
                        {
                            lb.Items[i] = string.Format(option, lb.Items[i], all[i]);
                        }
                    }
                    else
                    {
                        lb.Items[i] = string.Format(option, lb.Items[i], all[i-1]);
                    }
                }
                lb.Items[18] = string.Format(option, lb.Items[18], triangle.TypeAngle());
                lb.Items[19] = string.Format(option, lb.Items[19], triangle.TypeSide());
            }
            catch (Exception)
            {
                DialogResult result = MessageBox.Show("Sinu kolmnurgaga on midagi valesti", "Viga", MessageBoxButtons.OK);
                if (!aB)
                {
                    tb1.BackColor = Color.Red;
                }
                if (!bB)
                {
                    tb2.BackColor = Color.Red;
                }
                if (!cB)
                {
                    tb3.BackColor = Color.Red;
                }
                if (aB && bB && cB)
                {
                    tb1.BackColor = Color.Red;
                    tb2.BackColor = Color.Red;
                    tb3.BackColor = Color.Red;
                }
            }
        }

        private void ControlsAdd([Optional] Control[] arrayVisibleTrue, [Optional] Control[] arrayVisibleFalse)
        {
            if (arrayVisibleTrue != null)
            {
                foreach (Control item in arrayVisibleTrue)
                {
                    this.Controls.Add(item);
                }
            }
            if (arrayVisibleFalse != null)
            {
                foreach (Control item in arrayVisibleFalse)
                {
                    this.Controls.Add(item);
                    item.Visible = false;
                }
            }
        }
    }
}
