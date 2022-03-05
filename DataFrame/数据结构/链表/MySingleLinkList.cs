using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFrame.数据结构.链表
{
    /// <summary>
    /// 数据节点：数据，指针
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Node<T>
    {
        public T item;
        public Node<T> next;

        public Node()
        { }
        public Node(T data)
        {
            this.item = data;
        }

    }

    /// <summary>
    /// 单链表
    /// </summary>
    class MySingleLinkList<T>
    {
        public Node<T> head;
        public int count;

        public MySingleLinkList()
        {
            this.head = null;
            this.count = 0;
        }

        public MySingleLinkList(T value)
        {
            this.head = new Node<T>(value);
            this.count = 1;
        }

        // 查 改
        public T this[int index]
        {
            get
            {
                return this.getNode(index).item;
            }
            set 
            {
                this.getNode(index).item = value;
            }
        }

        public Node<T> getNode(int index)
        {
            Node<T> tempnode = this.head;
            if (index < 0 || index > this.count)
            {
                throw new ArgumentException("超索引");
            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    tempnode = tempnode.next;
                }
            }
            return tempnode;
        }
        
        // 增
        public void Add(T value)
        {
            Node<T> tempnode = new Node<T>(value);
            this.getNode(this.count).next = tempnode;
            this.count++;
        }

        public void Insert(T value, int index)
        {
            Node<T> newnode = new Node<T>(value);
            if (index < 0 || index > this.count)
            {
                throw new ArgumentException("超索引");
            }
            else if (index == 0)
            {
                if (this.head == null)
                {
                    this.head = new Node<T>(value);
                }
                else
                {
                    newnode.next = this.head;
                    this.head = newnode;
                    
                }
            }
            else
            {
                Node<T> prenode = this.getNode(index - 1);
                newnode.next = prenode.next;
                prenode.next = newnode;
            }
            this.count++;
        }

        // 删
        public void Pop()
        {
            this.getNode(this.count - 1).next = null;
            this.count--;
        }

        public void Remove(int index)
        {
            if (index < 0 || index > this.count)
            {
                throw new ArgumentException("超索引");
            }
            else if (index == 0)
            {
                this.head = this.head.next;
            }
            else if (index == this.count)
            {
                this.Pop();
            }
            else
            {
                Node<T> curNode = this.getNode(index);
                this.getNode(index - 1).next = curNode.next;
            }
        }

    }



}
