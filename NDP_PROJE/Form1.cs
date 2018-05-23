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


namespace NDP_PROJE
{
    public partial class Form1 : Form
    {
       // System.Drawing.Graphics graf;
        //Brush firca;
        Color secimRenk=Color.Black;
        string strRenk="siyah",sekil;
        int x, y;
        bool bkare=false, bdaire=false, bucgen=false, baltigen=false,ciz=false,sec=false;
        public Form1()
        { 
            InitializeComponent();
        }
        private void altigenPanel_Paint(object sender, PaintEventArgs e)
        {
            Point[] altigenNoktalar = { new Point(33, 8), new Point(18, 32), new Point(33, 55), new Point(54, 55), new Point(68, 30), new Point(54, 8) };
            MenuSekilCiz.MenuCiz(altigenPanel,Color.Red,altigenNoktalar);
        }
       // int a = 50;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void ucgenPanel_MouseClick(object sender, MouseEventArgs e)
        {
            sekil = "U";
            SekilCiz.sekilCizTik("ucgen");
            MenuArkaplanRenk.ArkaPlanDegis(karePanel, Color.MistyRose);
            MenuArkaplanRenk.ArkaPlanDegis(altigenPanel, Color.MistyRose);
            MenuArkaplanRenk.ArkaPlanDegis(dairePanel, Color.MistyRose);
            MenuArkaplanRenk.ArkaPlanDegis(ucgenPanel,Color.SeaGreen);
            bucgen = true;
            baltigen = false;
            bdaire = false;
            bkare = false; 
        }

        private void altigenPanel_MouseClick(object sender, MouseEventArgs e)
        {
            sekil = "A";
            SekilCiz.sekilCizTik("altigen");
            MenuArkaplanRenk.ArkaPlanDegis(karePanel, Color.MistyRose);
            MenuArkaplanRenk.ArkaPlanDegis(dairePanel, Color.MistyRose);
            MenuArkaplanRenk.ArkaPlanDegis(ucgenPanel, Color.MistyRose);
            MenuArkaplanRenk.ArkaPlanDegis(altigenPanel,Color.SeaGreen);

            bucgen = false;
            baltigen = true;
            bdaire = false;
            bkare = false;

        }

        

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(ciz)
            SekilCiz.sekilCiz(panel1, e, secimRenk, strRenk);

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
           
            SekilCiz.sekilCizUp();
            if (!sec)
            {
                if (bkare)
                {
                    Point[] kareNoktalar = { new Point(x, y), new Point(x, e.Y), new Point(e.X, e.Y), new Point(e.X, y) };
                    Kaydet.cokgen(strRenk, kareNoktalar);
                }
                else if (bdaire)
                {
                    Kaydet.daire(strRenk, (2 * x - e.X), (2 * y - e.Y), (2 * (e.X - x)), (2 * (e.Y - y)));
                }
                else if (baltigen)
                {
                    Point[] altigenNoktalar = { new Point(Math.Abs((x - (e.X - x) / 2)), Math.Abs(y - Math.Abs(e.Y - y))), new Point(Math.Abs(2 * x - e.X), y), new Point(Math.Abs((x - (e.X - x) / 2)), e.Y), new Point((x + (e.X - x) / 2), e.Y), new Point(e.X, y), new Point((x + (e.X - x) / 2), Math.Abs(y - Math.Abs(e.Y - y))) };
                    Kaydet.cokgen(strRenk, altigenNoktalar);

                }
                else if (bucgen)
                {
                    Point[] ucgenDizi = { new Point(x, y), new Point(Math.Abs(x - (e.X - x)), e.Y), new Point(e.X, e.Y) };
                    Kaydet.cokgen(strRenk, ucgenDizi);
                }

            }
            ciz = false;
            
        }

        private void kirmiziButon_Click(object sender, EventArgs e)
        {
            strRenk = "kirmizi";
            secimRenk = Color.Red;
            MenuArkaplanRenk.ArkaPlanDegis(kirmizi, Color.SeaGreen);
            MenuArkaplanRenk.ArkaPlanDegis(mavi, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(yesil, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(sari, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(turuncu, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(mor, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(koyuKirmizi, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(beyaz, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(siyah, Color.Aqua);
            if (sec)
            {
                SekilIsaretle.yenidenRenk(strRenk, panel1);
            }
        }

        private void maviButon_Click(object sender, EventArgs e)
        {
            strRenk = "mavi";
            secimRenk = Color.Blue;
            MenuArkaplanRenk.ArkaPlanDegis(kirmizi, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(mavi, Color.SeaGreen);
            MenuArkaplanRenk.ArkaPlanDegis(yesil, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(sari, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(turuncu, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(mor, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(koyuKirmizi, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(beyaz, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(siyah, Color.Aqua);
            if (sec)
            {
                SekilIsaretle.yenidenRenk(strRenk, panel1);
            }
        }

        private void yesilButon_Click(object sender, EventArgs e)
        {
            strRenk = "yesil";
            secimRenk = Color.Green;
            MenuArkaplanRenk.ArkaPlanDegis(kirmizi, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(mavi, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(yesil, Color.SeaGreen);
            MenuArkaplanRenk.ArkaPlanDegis(sari, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(turuncu, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(mor, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(koyuKirmizi, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(beyaz, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(siyah, Color.Aqua);
            if (sec)
            {
                SekilIsaretle.yenidenRenk(strRenk, panel1);
            }
        }

        private void turuncuButon_Click(object sender, EventArgs e)
        {
            strRenk = "turuncu";
            secimRenk = Color.Orange;
            MenuArkaplanRenk.ArkaPlanDegis(kirmizi, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(mavi, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(yesil, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(sari, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(turuncu, Color.SeaGreen);
            MenuArkaplanRenk.ArkaPlanDegis(mor, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(koyuKirmizi, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(beyaz, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(siyah, Color.Aqua);
            if (sec)
            {
                SekilIsaretle.yenidenRenk(strRenk, panel1);
            }
        }

        private void siyahButon_Click(object sender, EventArgs e)
        {
            strRenk = "siyah";
            secimRenk = Color.Black;
            MenuArkaplanRenk.ArkaPlanDegis(kirmizi, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(mavi, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(yesil, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(sari, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(turuncu, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(mor, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(koyuKirmizi, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(beyaz, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(siyah, Color.SeaGreen);
            if (sec)
            {
                SekilIsaretle.yenidenRenk(strRenk, panel1);
            }
        }

        private void sariButon_Click(object sender, EventArgs e)
        {
            strRenk = "sari";
            secimRenk = Color.Yellow;
            MenuArkaplanRenk.ArkaPlanDegis(kirmizi, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(mavi, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(yesil, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(sari, Color.SeaGreen);
            MenuArkaplanRenk.ArkaPlanDegis(turuncu, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(mor, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(koyuKirmizi, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(beyaz, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(siyah, Color.Aqua);
            if (sec)
            {
                SekilIsaretle.yenidenRenk(strRenk, panel1);
            }
        }

        private void morButon_Click(object sender, EventArgs e)
        {
            strRenk = "mor";
            secimRenk = Color.Purple;
            MenuArkaplanRenk.ArkaPlanDegis(kirmizi, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(mavi, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(yesil, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(sari, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(turuncu, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(mor, Color.SeaGreen);
            MenuArkaplanRenk.ArkaPlanDegis(koyuKirmizi, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(beyaz, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(siyah, Color.Aqua);
            if (sec)
            {
                SekilIsaretle.yenidenRenk(strRenk, panel1);
            }
        }

        private void kKirmiziButon_Click(object sender, EventArgs e)
        {
            strRenk = "kkirmizi";
            secimRenk = Color.DarkRed;
            MenuArkaplanRenk.ArkaPlanDegis(kirmizi, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(mavi, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(yesil, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(sari, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(turuncu, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(mor, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(koyuKirmizi, Color.SeaGreen);
            MenuArkaplanRenk.ArkaPlanDegis(beyaz, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(siyah, Color.Aqua);
            if (sec)
            {
                SekilIsaretle.yenidenRenk(strRenk, panel1);
            }
        }

        private void beyazButon_Click(object sender, EventArgs e)
        {
            strRenk = "beyaz";
            secimRenk = Color.White;
            MenuArkaplanRenk.ArkaPlanDegis(kirmizi, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(mavi, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(yesil, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(sari, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(turuncu, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(mor, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(koyuKirmizi, Color.Aqua);
            MenuArkaplanRenk.ArkaPlanDegis(beyaz, Color.SeaGreen);
            MenuArkaplanRenk.ArkaPlanDegis(siyah, Color.Aqua);
            if (sec)
            {
                SekilIsaretle.yenidenRenk(strRenk,panel1);
            }
        }

        private void secPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (secPanel.BackColor == Color.YellowGreen)
            {
                MenuArkaplanRenk.ArkaPlanDegis(secPanel, Color.White);
            }
            else
            {
                MenuArkaplanRenk.ArkaPlanDegis(secPanel, Color.YellowGreen);
                MenuArkaplanRenk.ArkaPlanDegis(silPanel, Color.White);
                bucgen = false;
                baltigen = false;
                bdaire = false;
                bkare = false;
                MenuArkaplanRenk.ArkaPlanDegis(karePanel,Color.MistyRose);
                MenuArkaplanRenk.ArkaPlanDegis(ucgenPanel, Color.MistyRose);
                MenuArkaplanRenk.ArkaPlanDegis(dairePanel, Color.MistyRose);
                MenuArkaplanRenk.ArkaPlanDegis(altigenPanel, Color.MistyRose);
            }

            if (sec==false)
            {
                ciz = false;
                sec = true;
            }
            else
            {
                ciz = true;
                sec = false;
            }

        }

        private void silPanel_MouseClick(object sender, MouseEventArgs e)
        {
           
            SekilIsaretle.sil(panel1);
            sec = false;
            MenuArkaplanRenk.ArkaPlanDegis(secPanel,Color.White);
            ciz = true;
            
        }

        private void dosyadanAcPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (dosyadanAcPanel.BackColor == Color.YellowGreen)
            {
                MenuArkaplanRenk.ArkaPlanDegis(dosyadanAcPanel, Color.White);
            }
            else
            {
                MenuArkaplanRenk.ArkaPlanDegis(dosyadanAcPanel, Color.YellowGreen);
                MenuArkaplanRenk.ArkaPlanDegis(kaydetPanel, Color.White);
            }
            OpenFileDialog oku = new OpenFileDialog();
            if (oku.ShowDialog()==DialogResult.OK)
            {
                ButondanOku.oku(panel1,oku);
            }
            MenuArkaplanRenk.ArkaPlanDegis(dosyadanAcPanel, Color.White);

        }

        private void kaydetPanel_MouseClick(object sender, MouseEventArgs e)
        {
          
            if (kaydetPanel.BackColor == Color.YellowGreen)
            {
                MenuArkaplanRenk.ArkaPlanDegis(kaydetPanel, Color.White);
            }
            else
            {
                MenuArkaplanRenk.ArkaPlanDegis(kaydetPanel, Color.YellowGreen);
                MenuArkaplanRenk.ArkaPlanDegis(dosyadanAcPanel, Color.White);
            }
            SaveFileDialog kayit = new SaveFileDialog();
            if (kayit.ShowDialog() == DialogResult.OK)
            {
                Kaydet.butonluKayit(kayit);
            }
        }

        private void dairePanel_MouseClick(object sender, MouseEventArgs e)
        {
            sekil = "D";
            SekilCiz.sekilCizTik("daire");
            MenuArkaplanRenk.ArkaPlanDegis(karePanel, Color.MistyRose);
            MenuArkaplanRenk.ArkaPlanDegis(altigenPanel, Color.MistyRose);
            MenuArkaplanRenk.ArkaPlanDegis(ucgenPanel, Color.MistyRose);
            MenuArkaplanRenk.ArkaPlanDegis(dairePanel, Color.SeaGreen);

            bucgen = false;
            baltigen = false;
            bdaire = true;
            bkare = false;

        }

        

        private void ucgenPanel_Paint(object sender, PaintEventArgs e)
        {
            Point[] ucgenNoktalar = { new Point(39, 8), new Point(17, 53), new Point(61, 53) };
            MenuSekilCiz.MenuCiz(ucgenPanel,Color.Brown,ucgenNoktalar);
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if(sec)
            SekilIsaretle.isretle(e,panel1);
            
        }

        private void karePanel_MouseClick(object sender, MouseEventArgs e)
        {
            sekil = "K";
            SekilCiz.sekilCizTik("kare");
            MenuArkaplanRenk.ArkaPlanDegis(dairePanel, Color.MistyRose);
            MenuArkaplanRenk.ArkaPlanDegis(altigenPanel, Color.MistyRose);
            MenuArkaplanRenk.ArkaPlanDegis(ucgenPanel, Color.MistyRose);
            MenuArkaplanRenk.ArkaPlanDegis(karePanel, Color.SeaGreen);
            bucgen = false;
            baltigen = false;
            bdaire = false;
            bkare = true;
        }

        

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Kaydet.dosyaTemizle();
        }

        private void dairePanel_Paint(object sender, PaintEventArgs e)
        {
            MenuSekilCiz.MenuCiz(dairePanel,"daire",Color.Blue,17,8,45,45);
        }

      
        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }

        private void karePanel_Paint(object sender, PaintEventArgs e)
        {
            MenuSekilCiz.MenuCiz(karePanel,"kare",Color.Yellow,17,8,45,45);
           
            
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if(!sec)
            ciz = true;
            if(ciz)
            SekilCiz.sekilCiz(e);
            x = e.X;
            y = e.Y;
            
        }

        
    }
}
