using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinArea
{
    /// <summary>
    /// Provides an interface to get permutations
    /// </summary>
    /// <typeparam name="T">Any type of elements of a set</typeparam>
    public interface IPermutations<T>
    {
        /// <summary>
        /// Generates a n! of permutations from given set and
        /// for every permutation calls a callback function
        /// </summary>
        /// <param name="set">
        /// a set of elements from which it needs to get permutations
        /// </param>
        /// <param name="callback">
        /// a function that is called for every permutation
        /// </param>
        void Generate(T[] set, Action<T[]> callback);
    }

    /// <summary>
    /// Implements the interface generating permutations recursivly
    /// </summary>
    /// <typeparam name="T">Any type of elements of a set</typeparam>
    public class Permutations<T> : IPermutations<T>
    {
        private T[] _set;
        private Action<T[]> _callback;

        /// <summary>
        /// Override
        /// </summary>
        public void Generate(T[] set, Action<T[]> callback)
        {
            _set = set;
            _callback = callback;
            GenerateRec(0, _set.Length);
        }

        /// <summary>
        /// generates an permutations recursivly
        /// </summary>
        /// <param name="k">from which index to start</param>
        /// <param name="n">count</param>
        private void GenerateRec(int k, int n)
        {
            if (k == n)
            {
                _callback(_set);
            }
            else
            {
                for (int i = k; i < n; ++i)
                {
                    Utils.Swap(ref _set[i], ref _set[k]);
                    GenerateRec(k + 1, n);
                    Utils.Swap(ref _set[i], ref _set[k]);
                }
            }
        }
    }
}
