using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree
{
    class BSTNode
    {
        public int data;
        public BSTNode right;
        public BSTNode left;

        public BSTNode(int data)
        {
            this.data = data;
            right = left = null;
        }
        public void Add(int item)
        {
            if (item < data)
            {
                if (left != null)
                {
                    left.Add(item);
                    return;
                }
                BSTNode newItem = new BSTNode(item);
                left = newItem;
            }
            else if (item > data)
            {
                if (right != null)
                {
                    right.Add(item);
                    return;
                }
                BSTNode newItem = new BSTNode(item);
                right = newItem;
            }
        }
        public void Remove(int item,BSTNode parent = null)
        {
            if (item < data)
            {
                if (left != null) 
                    left.Remove(item, this);
                    return;
            }
            else if (item > data)
            {
                if (right != null) 
                    right.Remove(item, this);
                    return;
            }

            if ((left == null) && (right == null))
            {
                if (parent.left == this) 
                    parent.left = null;
                else 
                    parent.right = null;
            }
            else if ((right != null) && (left != null))
            {
                data = right.MinValue();
                right.Remove(data, this);
                return;
            }
            else if (right != null)
            {
                if (parent.left == this)
                    parent.left = right;
                else 
                    parent.right = right;
            }
            else if (left != null)
            {
                if (parent.left == this) 
                    parent.left = right;
                else 
                    parent.right = left;
            }
        }
        public bool Search(int item)
        {
            if (item < data)
            {
                if (left != null) 
                    return left.Search(item);
                else 
                    return false;
            }
            else if (item > data)
            {
                if (right != null) 
                    return right.Search(item);
                else
                    return false;
            }
            return true;
        }
        public int MinValue()
        {
            if (left != null) return left.MinValue();
            return data;
        }
        public int MaxValue()
        {
            if (right != null) return right.MaxValue();
            return data;
        }
        public void Inorder(BSTNode tree)
        {
            if (tree == null)
                return;
            Inorder(tree.left);
            Console.Write(tree.data + " ");
            
            Inorder(tree.right);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BSTNode bst = new BSTNode(23);
            bst.Add(12);
            bst.Add(35);
            bst.Add(46);
            bst.Add(5);
            bst.Add(98);
            bst.Add(76);
            bst.Add(24);
            bst.Add(65);
           
           // Console.WriteLine(bst.Search(55));
            //Console.WriteLine(bst.MinValue());
            bst.Inorder(bst);
            bst.Remove(23);
            Console.WriteLine("\n");
            bst.Inorder(bst);

        }
    }
}
