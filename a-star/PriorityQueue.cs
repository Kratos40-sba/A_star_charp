using System;
using System.Collections.Generic;

namespace a_star
{
    public class PriorityQueue<T>
    {
        private List<Tuple<T,double>> q = new List<Tuple<T,double>>();

        public int Count
        {
            get { return q.Count; }
        }

        public void Enqueue(T item, double priority)
        {
            q.Add(Tuple.Create(item,priority));
        }

        public T Dequeue()
        {
            int bestIndex = 0;
            for (int i = 0; i < q.Count; i++)
            {
                if (q[i].Item2 < q[bestIndex].Item2)
                {
                    bestIndex = i;
                }
            }

            T bestItem = q[bestIndex].Item1;
            q.RemoveAt(bestIndex);
            return bestItem;
        }
    }
}