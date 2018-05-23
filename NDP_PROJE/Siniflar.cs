using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
namespace NDP_PROJE
{
    class MenuArkaplanRenk  //Menülere tıklandığında arka plan rengini değiştirmemize yarayan sınıf.
    {
        public static void ArkaPlanDegis(Panel panelAd, Color renk)
        {
            panelAd.BackColor = renk;
        }

        /*-------------------------------------------------------CLASS AYRIMI--------------------------------------------------------------- */
    }
    class MenuSekilCiz //Çizim şekillerini menü üzerine çizdirmek için oluşturduğum sınıf.
    {
        private static Graphics grafik;  //Çizim olayı sırasında metotlar tarfından kullanılmak için oluşturulan alanlar.
        private static Brush firca;

        public static void MenuCiz(Panel panelAd, Color fircaRenk, Point[] noktalar)//Dikdörtgen ve daire haric diğer menü şekillerin çizildiği fonksiyon.
        {
            grafik = panelAd.CreateGraphics();
            firca = new SolidBrush(fircaRenk);
            grafik.FillPolygon(firca, noktalar);
        }
        /*-------------------------------------------------------METOT AYRIMI--------------------------------------------------------------- */

        public static void MenuCiz(Panel panelAd, string sekilAd, Color fircaRenk, int x, int y, int w, int h)//Dikdörtgen ve dairenin menü üzerine çizildiği sınıf.
        {
            grafik = panelAd.CreateGraphics();
            firca = new SolidBrush(fircaRenk);
            if (sekilAd == "kare")
            {
                grafik.FillRectangle(firca, x, y, w, h);
            }
            else
            {
                grafik.FillEllipse(firca, x, y, w, h);
            }
        }


    }
    /*-------------------------------------------------------CLASS AYRIMI--------------------------------------------------------------- */
    class SekilCiz : Kaydet //Şekilleri çizdirmek için için oluşturulan sınıf.
    {
        static int a = 0;
        protected static Graphics graf;
        protected static Brush firca;
        private static bool kare = false, ucgen = false, altigen = false, daire = false, ciz = false;
        private static int x, y;

        public static void sekilCizTik(string sekilAd) //Seçilen şekilin adının belirlendiği metot.
        {

            if (sekilAd == "kare")
            {
                kare = true;
                daire = false;
                ucgen = false;
                altigen = false;
            }
            else if (sekilAd == "daire")
            {
                daire = true;
                kare = false;
                ucgen = false;
                altigen = false;
            }
            else if (sekilAd == "ucgen")
            {
                ucgen = true;
                daire = false;
                kare = false;
                altigen = false;
            }
            else if (sekilAd == "altigen")
            {
                altigen = true;
                daire = false;
                ucgen = false;
                kare = false;
            }
        }
        /*-------------------------------------------------------METOT AYRIMI--------------------------------------------------------------- */

        public static void sekilCizUp()//Mouse sol tık'ı bırakıldığında çizme olayını durduran metot.
        {

            ciz = false;
            a = 1;


        }
        /*-------------------------------------------------------METOT AYRIMI--------------------------------------------------------------- */

        public static void sekilCiz(MouseEventArgs basKonum)//çizim için ilk sol mouse tuşuna tıklandığında, tıklanılan yerin koordinatlarını kaydeden ve çizme olayını aktif eden  metot.
        {
            ciz = true;
            x = basKonum.X;
            y = basKonum.Y;




        }
        /*-------------------------------------------------------METOT AYRIMI--------------------------------------------------------------- */

        public static void sekilCiz(Panel panelAd, MouseEventArgs harKonum, Color renk, string strrenk) //Çizim olayının aktif olup olmamasına ve seçilen şekile göre şekli çizdiren metot.
        {


            if ((ciz == true) && kare)
            {
                graf = panelAd.CreateGraphics();
                firca = new SolidBrush(renk);
                graf.Clear(Color.Gainsboro);
                dosyaOku(panelAd);
                int y2 = harKonum.Y,x2=harKonum.X;
               
                Point[] kareNoktalar = { new Point(x, y), new Point(x, harKonum.Y), new Point(harKonum.X,harKonum.Y), new Point(harKonum.X, y) };
                graf.FillPolygon(firca, kareNoktalar);

            }
            else if ((ciz == true) && daire)
            {
                graf = panelAd.CreateGraphics();
                firca = new SolidBrush(renk);
                graf.Clear(Color.Gainsboro);
                dosyaOku(panelAd);
                graf.FillEllipse(firca, 2 * x - harKonum.X, 2 * y - harKonum.Y, 2 * (harKonum.X - x), 2 * (harKonum.Y - y));
            }
            else if (ciz == true && ucgen)
            {
                graf = panelAd.CreateGraphics();
                firca = new SolidBrush(renk);
                graf.Clear(Color.Gainsboro);
                dosyaOku(panelAd);
                Point[] ucgenDizi = { new Point(x, y), new Point(x - (harKonum.X - x), harKonum.Y), new Point(harKonum.X, harKonum.Y) };
                graf.FillPolygon(firca, ucgenDizi);
            }
            else if (ciz == true && altigen)
            {
                graf = panelAd.CreateGraphics();
                firca = new SolidBrush(renk);
                graf.Clear(Color.Gainsboro);
                dosyaOku(panelAd);
                Point[] altigenNoktalar = { new Point((x - (harKonum.X - x) / 2), y - Math.Abs(harKonum.Y - y)), new Point(2 * x - harKonum.X, y), new Point((x - (harKonum.X - x) / 2), harKonum.Y), new Point((x + (harKonum.X - x) / 2), harKonum.Y), new Point(harKonum.X, y), new Point((x + (harKonum.X - x) / 2), y - Math.Abs(harKonum.Y - y)) };

                graf.FillPolygon(firca, altigenNoktalar);
            }


        }





    }
    /*-------------------------------------------------------CLASS AYRIMI--------------------------------------------------------------- */
    class Kaydet //Kaydetme ve okuma işlemlerinin geneli için oluşturulan sınıf.
    {

        
        private static FileStream dosyaYaz; //Kaydetme ve yazma işlemleri için oluşturulan alanlar.
        private static StreamWriter yaz;
        protected static string dosyaYolu;
        public static void dosyaTemizle()  //Çizim yapılırken şekillerin geçici olarak ekranda kalması için şekillerin kaydedildiği dosyanın, form kapatıldığında temizlenmesi için oluşturulan metot.
        {
            dosyaYolu = Application.StartupPath.ToString() + "\\temporary.tmp";
            dosyaYaz = new FileStream(dosyaYolu, FileMode.Truncate);
            yaz = new StreamWriter(dosyaYaz);

            yaz.Write("");
            yaz.Close();
            dosyaYaz.Close();
        }
        /*-------------------------------------------------------METOT AYRIMI--------------------------------------------------------------- */


        public static void dosyaOku(Panel panel1) //Kaydedilen şekillerin okunup ekrana çizdirilmesini sağlayan fonksiyon.
        {
            Graphics grafik = panel1.CreateGraphics();
            Brush firca;



            Color renk = Color.Black;
            string[] okunan;
            okunan = File.ReadAllLines(Application.StartupPath.ToString() + "\\temporary.tmp");
            string[] okunanDizi = new string[30];
            /*
                                        ----Kayıt Stili----
             ŞEKİL_BAŞ HARFİ             ŞEKİL RENGİ              ŞEKİLİN KORDİNALARI
                  K            ,           kirmizi         ,       a,b,c,x,y,z,.........
             
             hepsi birbirinden virgül ile ayrılır.
             
             */



            for (int j = 0; j < okunan.Length; j++)   //Dosyadan okunan verilerden , şeklin rengi tespit edilir.
            {

                if ((okunan[j].Split(','))[1] == "kirmizi")
                {
                    renk = Color.Red;
                }
                else if ((okunan[j].Split(','))[1] == "kkirmizi")
                {
                    renk = Color.DarkRed;
                }
                else if ((okunan[j].Split(','))[1] == "mavi")
                {
                    renk = Color.Blue;
                }
                else if ((okunan[j].Split(','))[1] == "yesil")
                {
                    renk = Color.Green;
                }
                else if ((okunan[j].Split(','))[1] == "sari")
                {
                    renk = Color.Yellow;
                }
                else if ((okunan[j].Split(','))[1] == "turuncu")
                {
                    renk = Color.Orange;
                }
                else if ((okunan[j].Split(','))[1] == "mor")
                {
                    renk = Color.Purple;
                }
                else if ((okunan[j].Split(','))[1] == "siyah")
                {
                    renk = Color.Black;
                }
                else if ((okunan[j].Split(','))[1] == "beyaz")
                {
                    renk = Color.White;
                }

                if ((okunan[j].Split(','))[0] == "D") //Okunan veriden, şekil tespit edilir.
                {
                    for (int i = 0; i < 6; i++)  
                    {

                        okunanDizi[i] = Convert.ToString((okunan[j].Split(','))[i]); //Şeklin koordinatları bir diziye aktarılır.

                    }
                    firca = new SolidBrush(renk);
                    grafik.FillEllipse(firca, Convert.ToInt16(okunanDizi[2]), Convert.ToInt16(okunanDizi[3]), Convert.ToInt16(okunanDizi[4]), Convert.ToInt16(okunanDizi[5]));   //Okunulan verilere göre şekil ekrana çizdirilir.
                }
                else if ((okunan[j].Split(','))[0] == "U")
                {
                    for (int i = 0; i < 8; i++)
                    {

                        okunanDizi[i] = Convert.ToString((okunan[j].Split(','))[i]);

                    }

                    Point[] noktalar = { new Point(Convert.ToInt16(okunanDizi[2]), Convert.ToInt16(okunanDizi[3])), new Point(Convert.ToInt16(okunanDizi[4]), Convert.ToInt16(okunanDizi[5])), new Point(Convert.ToInt16(okunanDizi[6]), Convert.ToInt16(okunanDizi[7])) };
                    firca = new SolidBrush(renk);
                    grafik.FillPolygon(firca, noktalar);

                }
                else if ((okunan[j].Split(','))[0] == "A")
                {
                    for (int i = 0; i < 14; i++)
                    {

                        okunanDizi[i] = Convert.ToString((okunan[j].Split(','))[i]);

                    }
                    Point[] noktalar = { new Point(Convert.ToInt16(okunanDizi[2]), Convert.ToInt16(okunanDizi[3])), new Point(Convert.ToInt16(okunanDizi[4]), Convert.ToInt16(okunanDizi[5])), new Point(Convert.ToInt16(okunanDizi[6]), Convert.ToInt16(okunanDizi[7])), new Point(Convert.ToInt16(okunanDizi[8]), Convert.ToInt16(okunanDizi[9])), new Point(Convert.ToInt16(okunanDizi[10]), Convert.ToInt16(okunanDizi[11])), new Point(Convert.ToInt16(okunanDizi[12]), Convert.ToInt16(okunanDizi[13])) };
                    firca = new SolidBrush(renk);
                    grafik.FillPolygon(firca, noktalar);
                }
                else if ((okunan[j].Split(','))[0] == "K")
                {
                    for (int i = 0; i < 10; i++)
                    {

                        okunanDizi[i] = Convert.ToString((okunan[j].Split(','))[i]);

                    }

                    Point[] noktalar = { new Point(Convert.ToInt16(okunanDizi[2]), Convert.ToInt16(okunanDizi[3])), new Point(Convert.ToInt16(okunanDizi[4]), Convert.ToInt16(okunanDizi[5])), new Point(Convert.ToInt16(okunanDizi[6]), Convert.ToInt16(okunanDizi[7])), new Point(Convert.ToInt16(okunanDizi[8]), Convert.ToInt16(okunanDizi[9])) };
                    firca = new SolidBrush(renk);
                    grafik.FillPolygon(firca, noktalar);
                }


            }



        }
        /*-------------------------------------------------------METOT AYRIMI--------------------------------------------------------------- */

        public static void daire(string renk, int n1, int n2, int n3, int n4)  //Daire veya elips şeklini kaydetmek için oluşturulan metot.
        {
            dosyaYolu = Application.StartupPath.ToString() + "\\temporary.tmp";
            dosyaYaz = new FileStream(dosyaYolu, FileMode.Append);
            yaz = new StreamWriter(dosyaYaz);
            string nn1, nn2, nn3, nn4;
           
            nn1 = Convert.ToString(n1);
            nn2 = Convert.ToString(n2);
            nn3 = Convert.ToString(n3);
            nn4 = Convert.ToString(n4);
            
            yaz.WriteLine("D," + renk + "," + nn1 + "," + nn2 + "," + nn3 + "," + nn4);
            yaz.Close();
            dosyaYaz.Close();
        }
        /*-------------------------------------------------------METOT AYRIMI--------------------------------------------------------------- */



        public static void cokgen(string renk, Point[] noktalar)  //Kare,üçgen ve altıgen şekillerini kaydetmek için kullanılan metot.
        {
            dosyaYolu = Application.StartupPath.ToString() + "\\temporary.tmp";
            dosyaYaz = new FileStream(dosyaYolu, FileMode.Append);
            yaz = new StreamWriter(dosyaYaz);
            int x = noktalar.Length;
            if (noktalar.Length == 4) //referans alınan "noktalar" isimli dizini eleman sayısına göre, şeklin adı belirlenir.
            {
                yaz.Write("K,");
            }
            else if (noktalar.Length == 3)
            {
                yaz.Write("U,");
            }
            else if (noktalar.Length == 6)
            {
                yaz.Write("A,");
            }

            yaz.Write(renk);
            for (int i = 0; i < x; i++)
            {

                if (i == x - 1)
                {
                    yaz.WriteLine("," + noktalar[i].X + "," + noktalar[i].Y);
                }
                else
                {
                    yaz.Write("," + noktalar[i].X + "," + noktalar[i].Y);
                }


            }

            yaz.Close();
            dosyaYaz.Close();

        }
        /*-------------------------------------------------------METOT AYRIMI--------------------------------------------------------------- */

        public static void butonluKayit(SaveFileDialog dia) //Butondan manuel kayıt yapmak için kullanılan metot.
        {
            StreamWriter sw = new StreamWriter(dia.FileName);
            FileStream fs = new FileStream(Application.StartupPath.ToString() + "\\temporary.tmp", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string yazi = sr.ReadLine();
            while (yazi != null)
            {

                sw.WriteLine(yazi);
                yazi = sr.ReadLine();
            }
            sw.Close();
            sr.Close();
            fs.Close();

        }
        /*-------------------------------------------------------METOT AYRIMI--------------------------------------------------------------- */



    }
    /*-------------------------------------------------------CLASS AYRIMI--------------------------------------------------------------- */
    class ButondanOku : Kaydet  //Manuel olarak kaydedilen dosyayı açmak için kullanılan sınıf.
    {

        public static void oku(Panel panel1, OpenFileDialog ofd)
        {
            dosyaTemizle();
            Graphics grafik = panel1.CreateGraphics();
            Brush firca;
            grafik.Clear(Color.Gainsboro);


            try
            {


                Color renk = Color.Black;
                string[] okunan;
                okunan = File.ReadAllLines(ofd.FileName);
                string[] okunanDizi = new string[30];
                string xokunan;
                xokunan = File.ReadAllText(ofd.FileName);
                File.WriteAllText(Application.StartupPath.ToString() + "\\temporary.tmp", xokunan);

                for (int j = 0; j < okunan.Length; j++)
                {

                    if ((okunan[j].Split(','))[1] == "kirmizi")
                    {
                        renk = Color.Red;
                    }
                    else if ((okunan[j].Split(','))[1] == "kkirmizi")
                    {
                        renk = Color.DarkRed;
                    }
                    else if ((okunan[j].Split(','))[1] == "mavi")
                    {
                        renk = Color.Blue;
                    }
                    else if ((okunan[j].Split(','))[1] == "yesil")
                    {
                        renk = Color.Green;
                    }
                    else if ((okunan[j].Split(','))[1] == "sari")
                    {
                        renk = Color.Yellow;
                    }
                    else if ((okunan[j].Split(','))[1] == "turuncu")
                    {
                        renk = Color.Orange;
                    }
                    else if ((okunan[j].Split(','))[1] == "mor")
                    {
                        renk = Color.Purple;
                    }
                    else if ((okunan[j].Split(','))[1] == "siyah")
                    {
                        renk = Color.Black;
                    }
                    else if ((okunan[j].Split(','))[1] == "beyaz")
                    {
                        renk = Color.White;
                    }

                    if ((okunan[j].Split(','))[0] == "D")
                    {
                        for (int i = 0; i < 6; i++)
                        {

                            okunanDizi[i] = Convert.ToString((okunan[j].Split(','))[i]);

                        }
                        firca = new SolidBrush(renk);
                        grafik.FillEllipse(firca, Convert.ToInt16(okunanDizi[2]), Convert.ToInt16(okunanDizi[3]), Convert.ToInt16(okunanDizi[4]), Convert.ToInt16(okunanDizi[5]));
                    }
                    else if ((okunan[j].Split(','))[0] == "U")
                    {
                        for (int i = 0; i < 8; i++)
                        {

                            okunanDizi[i] = Convert.ToString((okunan[j].Split(','))[i]);

                        }

                        Point[] noktalar = { new Point(Convert.ToInt16(okunanDizi[2]), Convert.ToInt16(okunanDizi[3])), new Point(Convert.ToInt16(okunanDizi[4]), Convert.ToInt16(okunanDizi[5])), new Point(Convert.ToInt16(okunanDizi[6]), Convert.ToInt16(okunanDizi[7])) };
                        firca = new SolidBrush(renk);
                        grafik.FillPolygon(firca, noktalar);

                    }
                    else if ((okunan[j].Split(','))[0] == "A")
                    {
                        for (int i = 0; i < 14; i++)
                        {

                            okunanDizi[i] = Convert.ToString((okunan[j].Split(','))[i]);

                        }
                        Point[] noktalar = { new Point(Convert.ToInt16(okunanDizi[2]), Convert.ToInt16(okunanDizi[3])), new Point(Convert.ToInt16(okunanDizi[4]), Convert.ToInt16(okunanDizi[5])), new Point(Convert.ToInt16(okunanDizi[6]), Convert.ToInt16(okunanDizi[7])), new Point(Convert.ToInt16(okunanDizi[8]), Convert.ToInt16(okunanDizi[9])), new Point(Convert.ToInt16(okunanDizi[10]), Convert.ToInt16(okunanDizi[11])), new Point(Convert.ToInt16(okunanDizi[12]), Convert.ToInt16(okunanDizi[13])) };
                        firca = new SolidBrush(renk);
                        grafik.FillPolygon(firca, noktalar);
                    }
                    else if ((okunan[j].Split(','))[0] == "K")
                    {
                        for (int i = 0; i < 10; i++)
                        {

                            okunanDizi[i] = Convert.ToString((okunan[j].Split(','))[i]);

                        }

                        Point[] noktalar = { new Point(Convert.ToInt16(okunanDizi[2]), Convert.ToInt16(okunanDizi[3])), new Point(Convert.ToInt16(okunanDizi[4]), Convert.ToInt16(okunanDizi[5])), new Point(Convert.ToInt16(okunanDizi[6]), Convert.ToInt16(okunanDizi[7])), new Point(Convert.ToInt16(okunanDizi[8]), Convert.ToInt16(okunanDizi[9])) };
                        firca = new SolidBrush(renk);
                        grafik.FillPolygon(firca, noktalar);
                    }


                }


            }



            catch (Exception)
            {

                throw;
            }



        }




    }
    /*-------------------------------------------------------CLASS AYRIMI--------------------------------------------------------------- */
    class SekilIsaretle  //Seçim aracı ile üzerine tıklanılan şekli seçmek ve seçildikten sonra şekil üzerinde istenilen işlemi yapmak için oluşturulan sınıf.
    {
        private static string secilenSek = null;
        public static void isretle(MouseEventArgs e, Panel panel1)  //Şekil seçme metodu.
        {
            int bnX = e.X, bnY = e.Y;
            bool icerideMi = false;


            string[] oku = File.ReadAllLines(Application.StartupPath.ToString() + "\\temporary.tmp");
            for (int i = 0; i < oku.Length; i++)  //Mouse'un tıklanıldığı yede bir şeklin olup olmadığını tespit ediyorum. Eğer varsa etrafını koordinatlara göre çizdiriyorum.
            {

                if ((oku[i].Split(','))[0] == "D")
                {
                    if (bnX > Convert.ToInt16((oku[i].Split(','))[2]) && bnY > Convert.ToInt16((oku[i].Split(','))[3]) && bnX < (Convert.ToInt16((oku[i].Split(','))[4]) + Convert.ToInt16((oku[i].Split(','))[2])) && bnY < ((Convert.ToInt16((oku[i].Split(','))[5]) + Convert.ToInt16((oku[i].Split(','))[3]))))
                    {
                        secilenSek = oku[i];
                        icerideMi = true;
                        Graphics grafik = panel1.CreateGraphics();
                        Pen kalem = new Pen(Color.HotPink, 3);
                        grafik.Clear(Color.Gainsboro);
                        Kaydet.dosyaOku(panel1);
                        grafik.DrawRectangle(kalem, Convert.ToInt16((oku[i].Split(','))[2]) - 16, Convert.ToInt16((oku[i].Split(','))[3]) - 16, Convert.ToInt16((oku[i].Split(','))[4]) + 32, Convert.ToInt16((oku[i].Split(','))[5]) + 32);
                    }


                }
                else if ((oku[i].Split(','))[0] == "K")
                {
                    if (bnX > Convert.ToInt16((oku[i].Split(','))[2]) && bnY > Convert.ToInt16((oku[i].Split(','))[3]) && bnX < (Convert.ToInt16((oku[i].Split(','))[6])) && bnY < ((Convert.ToInt16((oku[i].Split(','))[5]))))
                    {
                        secilenSek = oku[i];
                        icerideMi = true;
                        Graphics grafik = panel1.CreateGraphics();
                        Pen kalem = new Pen(Color.HotPink, 3);
                        grafik.Clear(Color.Gainsboro);
                        Kaydet.dosyaOku(panel1);
                        grafik.DrawRectangle(kalem, Convert.ToInt16((oku[i].Split(','))[2]) - 16, Convert.ToInt16((oku[i].Split(','))[3]) - 16, Convert.ToInt16((oku[i].Split(','))[8]) - Convert.ToInt16((oku[i].Split(','))[2]) + 32, Convert.ToInt16((oku[i].Split(','))[5]) - Convert.ToInt16((oku[i].Split(','))[3]) + 32);
                    }


                }
                else if ((oku[i].Split(','))[0] == "A")
                {
                    if (bnX > Convert.ToInt16((oku[i].Split(','))[4]) && bnY > Convert.ToInt16((oku[i].Split(','))[3]) && bnX < (Convert.ToInt16((oku[i].Split(','))[10])) && bnY < ((Convert.ToInt16((oku[i].Split(','))[6]))))
                    {
                        secilenSek = oku[i];
                        icerideMi = true;
                        Graphics grafik = panel1.CreateGraphics();
                        Pen kalem = new Pen(Color.HotPink, 3);
                        grafik.Clear(Color.Gainsboro);
                        Kaydet.dosyaOku(panel1);
                        grafik.DrawRectangle(kalem, Convert.ToInt16((oku[i].Split(','))[4]) - 16, Convert.ToInt16((oku[i].Split(','))[3]) - 16, Convert.ToInt16((oku[i].Split(','))[10]) - Convert.ToInt16((oku[i].Split(','))[4]) + 32, Convert.ToInt16((oku[i].Split(','))[7]) - Convert.ToInt16((oku[i].Split(','))[13]) + 32);
                    }


                }
                else if ((oku[i].Split(','))[0] == "U")
                {
                    if (bnX > Convert.ToInt16((oku[i].Split(','))[4]) && bnY > Convert.ToInt16((oku[i].Split(','))[3]) && bnX < (Convert.ToInt16((oku[i].Split(','))[6])) && bnY < ((Convert.ToInt16((oku[i].Split(','))[7]))))
                    {
                        secilenSek = oku[i];
                        icerideMi = true;
                        Graphics grafik = panel1.CreateGraphics();
                        Pen kalem = new Pen(Color.HotPink, 3);
                        grafik.Clear(Color.Gainsboro);
                        Kaydet.dosyaOku(panel1);
                        grafik.DrawRectangle(kalem, Convert.ToInt16((oku[i].Split(','))[4]) - 16, Convert.ToInt16((oku[i].Split(','))[3]) - 16, Convert.ToInt16((oku[i].Split(','))[6]) - Convert.ToInt16((oku[i].Split(','))[4]) + 32, Convert.ToInt16((oku[i].Split(','))[5]) - Convert.ToInt16((oku[i].Split(','))[3]) + 32);
                    }


                }
            }
        }
        /*-------------------------------------------------------METOT AYRIMI--------------------------------------------------------------- */

        public static void sil(Panel panels) //Seçilen şekli sildirmek için oluşturulan metot.
        {


            if (secilenSek != null)
            {
                try
                {

                    FileStream dosyaYaz;
                    StreamWriter yaz;
                    dosyaYaz = new FileStream(Application.StartupPath.ToString() + "\\temporaryDel.tmp", FileMode.Truncate);
                    yaz = new StreamWriter(dosyaYaz);
                    string[] geciciOku = File.ReadAllLines(Application.StartupPath.ToString() + "\\temporary.tmp");
                    for (int i = 0; i < geciciOku.Length; i++)
                    {
                        if (geciciOku[i] != secilenSek)
                        {
                            yaz.WriteLine(geciciOku[i]);
                        }

                    }
                    yaz.Close();
                    dosyaYaz.Close();
                    dosyaYaz = new FileStream(Application.StartupPath.ToString() + "\\temporary.tmp", FileMode.Truncate);
                    yaz = new StreamWriter(dosyaYaz);
                    yaz.Write(File.ReadAllText(Application.StartupPath.ToString() + "\\temporaryDel.tmp"));

                    yaz.Close();
                    dosyaYaz.Close();
                    Graphics graf = panels.CreateGraphics();
                    graf.Clear(Color.Gainsboro);
                    Kaydet.dosyaOku(panels);

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        /*-------------------------------------------------------METOT AYRIMI--------------------------------------------------------------- */


        public static void yenidenRenk(string renk, Panel panels) //Seçilen şekli yeniden renklendirmek için kullanıl
        {
            if (secilenSek != null)
            {
                try
                {

                    FileStream dosyaYaz;
                    StreamWriter yaz;
                    dosyaYaz = new FileStream(Application.StartupPath.ToString() + "\\temporaryDel.tmp", FileMode.Truncate);
                    yaz = new StreamWriter(dosyaYaz);
                    string[] geciciOku = File.ReadAllLines(Application.StartupPath.ToString() + "\\temporary.tmp");
                    string[] neu=new string[geciciOku.Length];
                    for (int i = 0; i < geciciOku.Length; i++)
                    {
                        if (geciciOku[i] != secilenSek)
                        {
                            yaz.WriteLine(geciciOku[i]);
                        }
                        else
                        {
                            yaz.WriteLine(geciciOku[i].Replace(geciciOku[i].Split(',')[1],renk));
                        }

                    }
                    yaz.Close();
                    dosyaYaz.Close();
                    dosyaYaz = new FileStream(Application.StartupPath.ToString() + "\\temporary.tmp", FileMode.Truncate);
                    yaz = new StreamWriter(dosyaYaz);
                    yaz.Write(File.ReadAllText(Application.StartupPath.ToString() + "\\temporaryDel.tmp"));

                    yaz.Close();
                    dosyaYaz.Close();
                    Graphics graf = panels.CreateGraphics();
                    graf.Clear(Color.Gainsboro);
                    Kaydet.dosyaOku(panels);

                }
                catch (Exception)
                {

                    throw;
                }

            }

        }
        /*-------------------------------------------------------METOT AYRIMI--------------------------------------------------------------- */

    }
}
