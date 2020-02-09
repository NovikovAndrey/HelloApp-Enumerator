using System;
using System.Collections;
using System.Collections.Generic;

namespace HelloApp_Enumerator
{
    class Week
    {
        string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        public IEnumerator<string> GetEnumerator()
        {
            return new WeekEnumerator(days);
        }
    }

    internal class WeekEnumerator : IEnumerator<string>
    {
        private string[] days;
        int position = -1;

        public WeekEnumerator(string[] days)
        {
            this.days = days;
        }

        public string Current
        {
            get
            {
                if (position==-1 || position>days.Length)
                {
                    throw new InvalidOperationException();
                }
                return days[position];
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            return;
        }

        public bool MoveNext()
        {
            if (position<days.Length-1)
            {
                position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Week week = new Week();
            foreach(var day in week)
            {
                Console.WriteLine(day);
            }
            Console.ReadKey();
        }
    }
}
