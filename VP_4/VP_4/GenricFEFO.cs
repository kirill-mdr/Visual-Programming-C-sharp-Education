using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_4
{
    class GenricFEFO<T> where T : IExpired
    {
        
        Node head; // головной/первый элемент
        Node tail; // последний/хвостовой элемент
        int count;  // количество элементов в списке

        public int Count { get => count; }

        public class Node
        {
            
            public Node(T data)
            {
                Data = data;
            }
            public T Data { get; set; }
            public Node Previous { get; set; }
            public Node Next { get; set; }
            

        }
        public void Add(T data)
        {

            Node node = new Node(data);

            if (node.Data.GetExpireDays() >= 0)//Проверка на дату создания
            {
                Node current = head;
                if (head == null)
                {
                    head = node;
                    tail = node;
                }

                else
                {
                    while (current != null)
                    {
                        if (node.Data.GetExpireDays() >= tail.Data.GetExpireDays()) //добавление в конец
                        {
                            tail.Next = node;
                            node.Previous = tail;
                            tail = node;

                            break;
                        }
                        else if (node.Data.GetExpireDays() <= head.Data.GetExpireDays()) //добавление в начало
                        {
                            head.Previous = node;
                            node.Next = head;
                            head = node;

                            break;
                        }
                        else if (node.Data.GetExpireDays() <= current.Data.GetExpireDays()) //добавление по дате
                        {
                            node.Next = current;
                            node.Previous = current.Previous;
                            current.Previous.Next = node;
                            current.Previous = node;

                            break;

                        }
                        else
                        {
                            current = current.Next;
                        }
                    }
                }


                count++;
            }
            else throw new Exception("Срок годности уже истек");

            
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        public T PopBad()
        {
            T temp = head.Data;
            
            if (head.Next != null)
            {
                head = head.Next;
                head.Previous = null;
            }
            else //если это был единственный элемент
            {
                head = null;
                tail = null;
            }
            count--;
            return temp;
        }
        public T PopFresh()
        {
            T temp = tail.Data;
            
            if (tail.Previous != null)
            {
                tail = tail.Previous;
                tail.Next = null;
            }
            else //если это был единственный элемент
            {
                tail = null;
                head = null;
            }
            count--;
            return temp;
        }


    }
}
