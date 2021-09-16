using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SortsVisualisation.Models
{

    public class Sorts : INotifyPropertyChanged
    {
        private static Sorts instance;
        public static Sorts getInstance() => Sorts.instance ?? (Sorts.instance = new Sorts());

        #region sorts
        public void BubbleSort(RenderObject[] arr, CancellationToken token)
        {
            var n = arr.Length;

            for (int i = 0; i < n; i++)
            {
                if (token.IsCancellationRequested)
                    return;

                var min = arr[i].value;
                RenderObject.PivotIndex = i;
                System.Threading.Thread.Sleep(100);

                var minIndex = i;
                for (int k = i + 1; k < n; k++)
                {
                    if (token.IsCancellationRequested)
                        return;

                    RenderObject.ComparableIndex = k;
                    System.Threading.Thread.Sleep(100);

                    if (arr[k].value < min)
                    {
                        min = arr[k].value;
                        RenderObject.PivotIndex = k;
                        RenderObject.ComparableIndex = -1;
                        System.Threading.Thread.Sleep(500);

                        minIndex = k;
                    }
                }
                RenderObject.ComparableIndex = -1;
                RenderObject.PivotIndex = -1;

                Swap(arr, i, minIndex);
            }
        }

        public void QuickSort(RenderObject[] arr, int low, int high, CancellationToken token)
        {
            if (token.IsCancellationRequested)
                return;

            if (low < high)
            {
                int pivot = Partition(arr, low, high, token);

                QuickSort(arr, low, pivot - 1, token);
                QuickSort(arr, pivot + 1, high, token);

            }
        }
        #endregion

        #region auxillary methods
        private int Partition(RenderObject[] arr, int low, int high, CancellationToken token)
        {
            int pi = arr[high].value;
            int index = low - 1;

            RenderObject.PivotIndex = high;
            System.Threading.Thread.Sleep(100);


            for (int i = low; i < high; i++)
            {
                if (token.IsCancellationRequested)
                    return 0;

                RenderObject.ComparableIndex = i;
                System.Threading.Thread.Sleep(100);

                if (arr[i].value < pi)
                {
                    index++;
                    RenderObject.ComparableIndex = -1;
                    Swap(arr, index, i);
                }
            }
            RenderObject.ComparableIndex = -1;
            RenderObject.PivotIndex = -1;

            Swap(arr, index + 1, high);
            return index + 1;
        }

        private void Swap(RenderObject[] arr, int ai, int bi)
        {
            RenderObject.FirstSwapIndex = ai;
            RenderObject.SecondSwapIndex = bi;
            System.Threading.Thread.Sleep(1000);

            var tmp = arr[ai].value;
            arr[ai].value = arr[bi].value;
            arr[bi].value = tmp;

            RenderObject.FirstSwapIndex = bi;
            RenderObject.SecondSwapIndex = ai;
            System.Threading.Thread.Sleep(1000);

            RenderObject.FirstSwapIndex = -1;
            RenderObject.SecondSwapIndex = -1;
        }
        #endregion

        #region PropertyChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

}
