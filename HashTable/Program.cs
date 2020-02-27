using System;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
    class Node
    {
        public int Key;
        public Node Next;

        public Node(int Key)
        {
            this.Key = Key;
            Next = null;
        }
        public override string ToString()
        {
            return Key.ToString();
        }
    }
    class HashTable
    {
        public const int MAX = 10;
        public Node[] Data = new Node[MAX];

        public HashTable()
        {
            for (int i = 0; i < MAX; i++)
            {
                Data[i] = null;
            }
        }

        public void Push(int Key)
        {
            Node pNew = new Node(Key);
            int mod = Key % MAX;

            if (Data[mod] == null)
            {
                Data[mod] = pNew;
                return;
            }
            Node pTemp = Data[mod];

            while (pTemp.Next != null)
                pTemp = pTemp.Next;

            pTemp.Next = pNew;
        }
        public Node Get(int Key)
        {
            int mod = Key % MAX;
            Node pTemp = Data[mod];

            while (pTemp != null)
            {
                if (pTemp.Key == Key)
                    return pTemp;
                pTemp = pTemp.Next;
            }
            return null;
        }
        public bool Remove(int Key)
        {
            int Mode = Key % MAX;

            if (Data[Mode] == null) return false;

            //Sondan siler.
            if (Data[Mode].Next == null)
            {
                if (Data[Mode].Key == Key)
                {
                    Data[Mode] = null;
                    return true;
                }
                return false;
            }
            //Baştan siler.
            if (Data[Mode].Key == Key)
            {
                Data[Mode] = Data[Mode].Next;
                return true;
            }
            //Aranan eleman diğer iki eleman arasındaysa, aradan siler.
            Node pTemp = Data[Mode];

            while (pTemp.Next != null)
            {
                if (pTemp.Next.Key == Key)
                {
                    pTemp.Next = pTemp.Next.Next;
                    return true;
                }
                pTemp = pTemp.Next;
            }
            return false;
        }
        class Program
        {
            static void Main(string[] args)
            {
            }
        }
    }
}