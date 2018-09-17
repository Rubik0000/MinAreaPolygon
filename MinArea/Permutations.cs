using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinArea
{
    public interface IPermutations<T>
    {
        void Generate(T[] set, Action<T[]> callback);
    }

    class Permutations<T> : IPermutations<T>
    {
        private T[] _set;
        private Action<T[]> _callback;

        public void Generate(T[] set, Action<T[]> callback)
        {
            _set = set;
            _callback = callback;
            GenerateRec(0);
        }

        private void GenerateRec(int k)
        {
            if (k == _set.Length)
            {
                _callback(_set);
            }
            else
            {
                for (int i = k; i < _set.Length; ++i)
                {
                    Swap(ref _set[i], ref _set[k]);
                    GenerateRec(k + 1);
                    Swap(ref _set[i], ref _set[k]);
                }
            }
        }

        private void Swap(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }
    }
}
