using System;
using System.Collections.Generic;

namespace Datastructure
{
    public class Node<T>
    {
        public T value;
        public Node<T> next;

        public Node(T value)
        {
            this.value = value;
            this.next = null;
        }
    }

    public class Queue<T>
    {
        private Node<T> front;
        private Node<T> back;

        public Queue()
        {
            front = null;
            back = null;
        }

        public void Enqueue(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (back == null)
            {
                front = newNode;
                back = newNode;
            }
            else
            {
                back.next = newNode;
                back = newNode;
            }
        }

        public T Dequeue()
        {
            if (front == null)
            {
                throw new System.Exception("큐가 비어 있습니다.");
            }
            T value = front.value;
            front = front.next;
            if (front == null)
            {
                back = null;
            }
            return value;
        }

        public int Count()
        {
            int count = 0;
            Node<T> current = front;
            while (current != null)
            {
                count++;
                current = current.next;
            }
            return count;
        }
    }

    public class Stack<T>
    {
        private List<T> list;

        public Stack()
        {
            list = new List<T>();
        }

        public void Push(T data)
        {
            list.Add(data);
        }

        public T Pop()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            T data = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return data;
        }

        public bool IsEmpty()
        {
            return list.Count == 0;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // 스택 생성
            Stack<int> stack = new Stack<int>();

            // 사용자로부터 입력 받아 스택에 추가
            Console.WriteLine("스택에 넣을 숫자를 입력하세요 (각 숫자 입력 후 Enter, '완료'를 입력하면 종료):");
            string input;
            while ((input = Console.ReadLine()) != "완료")
            {
                int number;
                if (int.TryParse(input, out number))
                {
                    stack.Push(number);
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 유효한 숫자를 입력하거나 '완료'를 입력하세요.");
                }
            }

            // 스택에서 데이터 제거 및 출력
            Console.WriteLine("\n스택에서 숫자를 꺼내 출력합니다:");
            Stack<int> tempStack = new Stack<int>();
            while (!stack.IsEmpty())
            {
                tempStack.Push(stack.Pop());
            }
            while (!tempStack.IsEmpty())
            {
                Console.WriteLine("꺼낸 숫자: " + tempStack.Pop());
            }
            // 스택이 비어있는지 확인
            if (stack.IsEmpty())
            {
                Console.WriteLine("스택이 비어 있습니다.");
            }
        }
    }
}