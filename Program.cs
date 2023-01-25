using System;
using System.Threading;

namespace ALG_LAB_3
{
    class Program
    {
        static void Main()
        { 
            Knygarnya bibliotechna_karta = new Knygarnya(6);
            bibliotechna_karta.Put(new Key("Kvity_dlya_Eldzherona", 10), 10);
            bibliotechna_karta.Put(new Key("Lovets_u_zhyti", 350), 350);
            bibliotechna_karta.Put(new Key("Vono", 23), 23);
            bibliotechna_karta.Put(new Key("Malenkuy_prynts", 230), 230);
            bibliotechna_karta.Put(new Key("Atlant_rozpravyv_plechi",30), 30);
            bibliotechna_karta.Put(new Key("Volodar_muh", 100), 11);
            
            bibliotechna_karta.Show();

            Console.WriteLine(bibliotechna_karta.Get(new Key("Atlant_rozpravyv_plechi", 30)));
            Console.WriteLine(bibliotechna_karta.Get(new Key("Kvity_dlya_Eldzherona", 10)));
            Console.WriteLine(bibliotechna_karta.ConstKey(new Key("Volodar_muh", 100)));
            Console.WriteLine(bibliotechna_karta.Remove(new Key("Vono", 23)));
            Console.WriteLine(bibliotechna_karta.Size());
            bibliotechna_karta.Show();
            Console.ReadKey();
        }
    }
    class Key
    {
        string stock;
        int DayOfTheYear;
        public Key(string stock, int DayOfTheYear)
        {
            this.stock = stock;
            this.DayOfTheYear = DayOfTheYear;
        }
        public int Hash()
        {
            int hash = DayOfTheYear;
            for (int i = 0; i < stock.Length; i++)
            {
                hash += stock[i] * 3;
            }
            return hash;
        }
        public bool Equals(Key other)
        {
            return this.DayOfTheYear == other.DayOfTheYear && this.stock == other.stock;
        }
    }
    class Node
    {
        public double value;
        public Key key;
        public Node next;
        public Node(Key key, double value, Node next)
        {
            this.key = key;
            this.value = value;
            this.next = next;

        }
    }
    class Knygarnya
    {
        Node[] nodes;
        public Knygarnya(int length)
        {
            nodes = new Node[length];
        }
        public void Put(Key key, double value)
        {
            int index = Math.Abs(key.Hash() % nodes.Length);
            if (nodes[index] == null)
            {
                nodes[index] = new Node(key, value, null);
            }
            else
            {
                for (Node node = nodes[index]; nodes != null; node = node.next)
                {
                    if (node.key.Equals(key))
                    {
                        nodes[index] = new Node(key, value, nodes[index]);
                    }
                    return;
                }

            }
        }
        public double Get(Key key)
        {
            int index = Math.Abs(key.Hash() % nodes.Length);
            for (Node node = nodes[index]; node != null; node = node.next)
            {
                if (node.key.Equals(key))
                {
                    return node.value;

                }
            }
            return 0;
        }
        public bool ConstKey(Key key)
        {
            int index = Math.Abs(key.Hash() % nodes.Length);
            for (Node node = nodes[index]; node != null; node = node.next)
            {
                if (node.key.Equals(key))
                {
                    return true;

                }
            }
            return false;
        }
        public double Remove(Key key)
        {
            int index = Math.Abs(key.Hash() % nodes.Length);
            for (Node node = nodes[index]; node != null; node = node.next)
            {
                if (node.key.Equals(key))
                {
                    nodes[index] = node.next;

                    return node.value;
                }
            }
            return 0;
        }
        public int Size()
        {

            return nodes.Length;
        }

        public void Show()
        {
            for (int i = 0; i < nodes.Length; i++)
            {
                Console.WriteLine("Index [" + i + "]: ");

                for (Node node = nodes[i]; node != null; node = node.next)
                {
                    Console.WriteLine(node.value + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }

}


                               