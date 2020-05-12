using System;
using System.Collections.Generic;

namespace Basic_Tree_Data_Homework
{
    public class Tree<T>
    {
        public T Value { get; set; }
        public Tree<T> Parent { get; set; }
        public List<Tree<T>> Children { get; set; }

        public Tree(T value, params Tree<T>[] children )
        {
            this.Value = value;
            this.Children = new List<Tree<T>>();
            foreach (Tree<T> child in children)
            {
                this.Children.Add(child);
                child.Parent = this;
            }
        }

        public void Print(int ident = 0)
        {
            Console.WriteLine($"{new string(' ',ident)}{this.Value}");
            foreach (Tree<T> child in Children)
            {
                child.Print(ident+2);
            }
        }
    }
}