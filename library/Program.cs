using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication22
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList raf = new LinkedList(new Kutuphane("Aldatma Sanati","Kevin Mitnack",null));
            raf.Add(new Kutuphane("Suc ve Ceza", "Doystevski", raf.Current));
            raf.Add(new Kutuphane("Ol der ve olur", "Tugce Isinsu", raf.Current));
            raf.Add(new Kutuphane("Nutuk", "Ataturk", raf.Current));
            raf.Add(new Kutuphane("Araba Sevdası", "Mehmet Arif", raf.Current));
            raf.ArayaAdd(new Kutuphane("Eylul", "Polat Alemdar", raf.Current), 3);
           // raf.AradanSil(3);
            //raf.Show();
            //raf.KitapBul(3);
            //Console.WriteLine(raf.Counts());
            int a = 5*(2^3);
            Console.WriteLine(a);

            Console.ReadLine();
        }
        class Kutuphane
        { 
            public string KitapAdi;
            public string yazar;
            public Kutuphane pNode;
            public Kutuphane nNode;

            public Kutuphane(string KitapAdi, string yazar ,Kutuphane pNode)
            {
                this.KitapAdi = KitapAdi;
                this.yazar = yazar;
                this.pNode = pNode;
            }
        }
        class LinkedList
        {
            public Kutuphane Head;
            public Kutuphane Current;
            public Kutuphane Tail;
            public int count = 0;

            public LinkedList(Kutuphane fNode)
            {
                Head = fNode;
                Current = fNode;
                Tail = fNode;
            }
            public void Add(Kutuphane kitap)
            {
                Current.nNode = kitap;
                Current = Current.nNode;
                Tail = kitap;
            }
            public void Show()
            {
                Current = Head;
                while (Current != null)
                {
                    Console.WriteLine("Kitap Adi:"+Current.KitapAdi+" ---> "+"Yazar:"+Current.yazar);
                    Current = Current.nNode;
                }
            }
            public void KitapBul(int bul)
            {
                Current = Head;
                for (int i = 0; i < bul; i++)
                {
                    Current = Current.nNode;
                }
                Console.WriteLine("Kitap Adi:" + Current.KitapAdi + " ---> " + "Yazar:" + Current.yazar);
            }
            public int Counts()
            {
                Current = Head;
                while (Current.nNode != null)
                {
                    Current = Current.nNode;
                    count++;
                }
                return count;
            }
            public void ArayaEkle(Kutuphane ykitap, int ekle)
            {
                Current = Head;
                for (int i = 0; i < ekle; i++)
                {
                    Current = Current.nNode;
                }

                Kutuphane temp;
                temp = Current;
                Current = ykitap;
                Current.pNode = temp.pNode;
                Current.pNode.nNode = ykitap;
                Current.nNode = temp;
                temp.pNode = ykitap;
                Current = Head;

            }
            public void AradanSil(int sil)
            {
                Current = Head;
                for (int i = 0; i < sil; i++)
                {
                    Current = Current.nNode;
                }
                Kutuphane temp;
                temp = Current;
                Current.pNode.nNode = temp.nNode;
                temp.nNode = Current.pNode;
            }
        }
        
    }    
}
