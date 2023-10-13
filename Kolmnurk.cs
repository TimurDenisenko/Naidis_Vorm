using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace Naidis_Vorm
{
    public partial class Kolmnurk: Form
    {
        Label lbl;
        PictureBox pb;
        Button btn;
        ListBox lb;
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
            btn.Location = new Point(pb.Left, pb.Top-150);

            lb = new ListBox();
            lb.Height = 280;
            
            lb.Items.Add("Külg A: ");
            lb.Items.Add("Külg B: ");
            lb.Items.Add("Külg C: ");
            lb.Items.Add("Olemas: ");
            lb.Items.Add("Perimeeter: ");
            lb.Items.Add("Ruut: ");
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
            lb.Location = new Point(50,lbl.Bottom+50);

            ControlsAdd(new Control[] {lbl, pb, btn, lb});
        }

        private void ControlsAdd(Control[] arrayVisibleTrue)
        {
            if (arrayVisibleTrue != null)
            {
                foreach (Control item in arrayVisibleTrue)
                {
                    this.Controls.Add(item);
                }
            }
        }
    }
}
