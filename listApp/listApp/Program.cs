﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace list
{
    class Program
    {
        class Node<T>
        {
            public T Data { get; set; }
            public Node<T> vNext;

            public Node(T data, Node<T> nextNode = null)
            {
                Data = data;
                vNext = nextNode;
            }

        }

        class LinkList<T>
        {
            private Node<T> node;
            private List<Node<T>> list;

            public LinkList()
            {
                node = null;
                list = new List<Node<T>>();
            }

            public void AddLast(T value)
            {
                if (list.Count == 0)
                {
                    list.Add(new Node<T>(value));
                    return;
                }
                list.Add(new Node<T>(value));
                list[list.Count - 2].vNext = list[list.Count - 1];
            }

            public void Remove(T value)
            {
                int index = list.FindIndex(x => x.Data.Equals(value));
                Console.WriteLine(index);
                try
                {
                    list.RemoveAt(index);
                    if (index != 0 && index != (list.Count))
                    {
                        list[index - 1].vNext = list[index];
                    }
                    else if (index == list.Count)
                    {
                        list[index - 1].vNext = null;
                    }
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine($"Элемент {value} отсутстует в списке");
                }
            }

            public void AppendFirst(T value)
            {
                list.Insert(0, new Node<T>(value));
                list[0].vNext = list[1];
            }

            public void ReverseList()
            {
                Node<T> current=list[0];

                list[0] = list[list.Count-1];
                list[list.Count-1] = current;

                current = list[list.Count-1];
                while (current.vNext != null)
                {
                    current = current.vNext;
                }
                
            }

            public void ShowList()
            {
                Node<T> current = list[0];
                while (current.vNext!=null)
                {
                    Console.Write(current.Data+" ");
                    current = current.vNext;
                }
                //для вывода последнего значения
                Console.Write(current.Data + " ");
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            Random rand=new Random();
            LinkList<int> linkList = new LinkList<int>();
            for (int i = 1; i < 11; i++)
                linkList.AddLast(rand.Next(1000));

            linkList.ShowList();
            linkList.ReverseList();
        }
    }
}
