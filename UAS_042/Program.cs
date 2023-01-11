using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_042
{
    class Node
    {
        public int nomor;
        public string name;
        public string judul;
        public int tahun;
        public Node next;
    }
    class List
    {
        Node START;
        public List()
        {
            START = null;
        }
        public void addBuku()
        {
            int no, th;
            string jd, nm;
            Console.Write("\nMasukkan Nomor Buku     : ");
            no = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan Judul Buku     : ");
            jd = Console.ReadLine();
            Console.Write("\nMasukkan Nama Pengarang : ");
            nm = Console.ReadLine();
            Console.Write("\nMasukkan Tahun Terbit   : ");
            th = Convert.ToInt32(Console.ReadLine());

            Node nodeBaru = new Node();
            nodeBaru.nomor = no;
            nodeBaru.name = nm;
            nodeBaru.judul = jd;
            nodeBaru.tahun = th;

            if ((START == null || no <= START.nomor))
            {
                if ((START != null) && (no == START.nomor))
                {
                    Console.WriteLine("\nNomer buku sama tidak diijinkan\n");
                    return;
                }
                nodeBaru.next = START;
                START = nodeBaru;
                return;

                
            }

            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (no >= current.nomor))
            {
                if (no == current.nomor)
                {
                    Console.WriteLine("\nNomer buku sama tidak diijinkan\n");
                    return;
                }
                previous = current;
                current = current.next;
            }

            nodeBaru.next = current;
            previous.next = nodeBaru;
        }
        
        public void Search()
        {
            Node previous, current;
            previous = current = START;

            Console.Write("\nMasukkan Tahun Terbit Buku yang akan di cari: ");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num == current.tahun)
                Console.WriteLine("\nTahun Terbit " + num + " ditemukan.");
            else
                Console.WriteLine("\nTahun Terbit " + num + " tidak ditemukan.");

            while (current != null)
            {
                if(num == current.tahun)
                {
                    Console.WriteLine("Nomor Buku     : " + current.nomor);
                    Console.WriteLine("Judul Buku     : " + current.judul);
                    Console.WriteLine("Nama Pengarang : " + current.name);
                    Console.WriteLine("Tahun Terbit   : " + current.tahun);
                    Console.WriteLine("");
                }               
                current = current.next;
            }        
        }
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList Kosong. \n");
            else
            {
                Console.WriteLine("\nData didalam list adalah \n");
                Console.WriteLine("Nomor Buku\tJudul Buku\tNama Pengarang\tTahun Terbit");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.nomor + "\t" + currentNode.judul + 
                        "\t" + currentNode.name + "\t" + currentNode.tahun+ "\n");
                Console.WriteLine();
            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            List obj = new List();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu\n");
                    Console.WriteLine("1. Menambah data buku kedalam list");
                    Console.WriteLine("2. Mencari data buku berdasarkan tahun terbit");
                    Console.WriteLine("3. Melihat semua data buku didalam list");
                    Console.WriteLine("4. Exit");
                    Console.Write("\nMasukan Pilihan Anda (1-4): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addBuku();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList Kosong. \n");
                                    break;
                                }
                                else
                                    obj.Search();
                            }
                            break;
                        case '3':
                            {
                                obj.traverse();

                            }
                            break;
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("\nPilihan tidak valid");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nCheck nomor pilihan yang anda masukkan.");
                }
            }
        }
    }
}

//2. Singly Linked List karena pada soal kebutuhan udin yang sangat banyak untuk mendata buku yang ada dan kemungkinan
//   dalam memasukan nomor buku akan secara acak sehingga membutuhkan pengurutan. Adapula kebutuhan udin untuk mencari
//   buku berdasarkan tahun terbit dari buku
//3. Push dan Pop
//4. REAR dan FRONT
//5. a. Kedalaman pohon tersebut 5
//   b. Inorder membaca sebelah kiri dari root hingga visit root tidak memiliki subtree kiri, lalu membaca visit root
//      jika punya subtree kanan maka di baca terlebih dahulu lalu kembali ke visit root sebelumnya dan akan berulang
//      hingga subtree kanan tidak ada.
//      cara membacanya 1,5,8,10,12,15,20,22,25,28,30,36,38,40,45,48,50
