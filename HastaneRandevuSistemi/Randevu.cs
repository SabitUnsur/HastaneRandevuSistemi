using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HastaneRandevuSistemi
{
    internal class Randevu
    {
        /* DOSYA AÇMA TÜRLERİ 
         * READ MODU (StreamReader)
         * WRİTE MODU = HER YENİ EKLEMEDE MEVCUT İÇERİK SİLİNİR,SON YAZILAN TUTULUR (StreamWriter)
         * APPEND MODU= HER YENİ EKLEMEDE MEVCUT İÇERİK KORUNUR VE YENİ EKLENEN DOSYANIN SONUNA EKLENİR. (StreamWriter) */
        
        
        
        static string dosyaYolu = @"randevu.txt"; //@:Escape Karakteridir.
        public static void Ekle(string satir)
        {
            StreamWriter yazmaNesnesi = new StreamWriter(dosyaYolu, true);
            try
            {
                yazmaNesnesi.WriteLine(satir);
                System.Windows.Forms.MessageBox.Show("EKLENDİ");
            }

            catch
            {
                System.Windows.Forms.MessageBox.Show("EKLENEMEDİ");
                
            }

            finally
            {
                yazmaNesnesi.Close();
            }

        }

        public static string tumRandevular()
        {
            StreamReader okumaNesnesi=new StreamReader(dosyaYolu);
            // string icerik=okumaNesnesi.ReadToEnd();
            string icerik = "";
            while (okumaNesnesi.EndOfStream == false)
            {
                icerik+=okumaNesnesi.ReadLine()+Environment.NewLine;
            }
            okumaNesnesi.Close();
            return icerik;
        }


        public static bool RandevuVarMi(string bolum,string tarih,string saat)
        {
            StreamReader okumaNesnesi= new StreamReader(dosyaYolu);
            string a= "";
            bool sonuc = false;
            while (okumaNesnesi.EndOfStream == false&&sonuc==false)
            {
                a=okumaNesnesi.ReadLine();
                string[] parcalar = a.Split('*');

                if((parcalar[3]==bolum)&&(parcalar[4]==tarih)&&(parcalar[5]==saat))
                {  
                    sonuc=true;
                
                }

            }
            okumaNesnesi.Close();
            return sonuc;
        } 



    }
}
