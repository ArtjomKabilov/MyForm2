using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyVorm
{
    public partial class saal : Form
    {
        
        TableLayoutPanel tlp = new TableLayoutPanel();
        Button btn_tabel;


        public saal(int read, int kohad)
        {
            
            this.tlp.ColumnCount = kohad;
            this.tlp.RowCount = read;
            this.tlp.ColumnStyles.Clear();
            this.tlp.RowStyles.Clear();
            int i, j;
            for (i = 0; i < read; i++)
            {
                this.tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 50 / read));
            }
            for (i = 0; i < kohad; i++)
            {
                this.tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50 / kohad));
            }
            this.Size = new System.Drawing.Size(kohad * 50, read * 50);
            for (int r = 0; r < read; r++)
            {
                for (int k = 0; k < kohad; k++)
                {
                    btn_tabel = new Button
                    {
                        Text = String.Format($"{r + 1}{k + 1}"),
                        Name = String.Format($"{r}{k}"),
                        Dock = DockStyle.Fill,
                        BackColor = Color.LightGreen
                    };
                    this.tlp.Controls.Add(btn_tabel, k, r);
                    btn_tabel.MouseClick += Btn_tabel_MouseClick;
                }
            }
            //btn_w = (int)(100 / kohad);
            //btn_h = (int)(100 / read);
            this.tlp.Dock = DockStyle.Fill;
            //this.tlp.Size = new System.Drawing.Size(tlp.ColumnCount*btn_w*3,tlp.RowCount * btn_h*2);
            this.Controls.Add(tlp);


        }

        private void Btn_tabel_MouseClick(object sender, MouseEventArgs e)
        {   
            Button b = sender as Button;
            b.BackColor = Color.Yellow;
            var answer = MessageBox.Show(
         "Хотите купить место",
         "Сообщение",
         MessageBoxButtons.YesNo,
         MessageBoxIcon.Information,
         MessageBoxDefaultButton.Button1,
         MessageBoxOptions.DefaultDesktopOnly);
            if (answer == DialogResult.Yes)
            {
                b.BackColor = Color.Red;
            }
            else
            {
                b.BackColor = Color.LightGreen;
            }

        }
    }
}