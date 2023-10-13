using System.Runtime.InteropServices;

namespace Naidis_Vorm
{
    public partial class Kolmnurk: Form
    {
        Label lbl;
        PictureBox pb;
        Button btn;
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

            ControlsAdd(new Control[] {lbl, pb, btn});
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
