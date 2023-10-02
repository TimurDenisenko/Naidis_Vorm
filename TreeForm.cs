using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naidis_Vorm
{
    public partial class TreeForm : Form
    {
        TreeView tree;
        Button btn;
        TreeNode tn = new TreeNode("Elemendid");
        Label lbl;
        double i=0;
        int j, o = 0;
        public TreeForm()
        {
            this.Height = 600;
            this.Width = 800;
            this.Text = "Vorm põhielementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Top;
            tree.BorderStyle = BorderStyle.Fixed3D;
            tree.AfterSelect+=Tree_AfterSelect;
            tn.Nodes.Add(new TreeNode("Nupp-Button"));
            btn = new Button();
            btn.Height = 50;
            btn.Width = 100;
            btn.Text= "Click!\n"+i;
            btn.Location = new Point(400, 300);
            btn.Click+=Btn_Click;
            btn.MouseWheel +=Btn_MouseWheel;
            //Label
            tn.Nodes.Add("Silt-Label");
            lbl = new Label();
            lbl.Text = "Pealkiri";
            lbl.Location = new Point(0,0);
            lbl.BackColor = Color.Gray;
            lbl.Size = new Size(this.Width,btn.Location.Y);
            tree.Nodes.Add(tn);
            this.Controls.Add(tree);

            this.Controls.Add(btn);
            this.Controls.Add(lbl);
            btn.Visible = false;
            lbl.Visible = false;
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
                if (j%2==0)
                {
                    btn.Visible = true;
                }
                else
                {
                    btn.Visible = false;
                }
                j++;
            }
            else if (e.Node.Text == "Silt-Label")
            {
                if (o%2==0)
                {
                    lbl.Visible = true;
                }
                else
                {
                    lbl.Visible = false;                   
                }
                o++;
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
            btn.Location = new Point(new Random().Next(0,600), new Random().Next(200, 500));
            lbl.Size = new Size(this.Width, btn.Location.Y);
        }
    }
}
