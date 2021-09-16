using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SortsVisualisation.Models;

namespace SortsVisualisation.ViewModels
{
    public class MainVM : INotifyPropertyChanged
    {

        // private
        private string selectedSortType;
        private RenderObject[] arr;
        private Sorts sorts;
        private int n;
        private CancellationTokenSource tokenSource;
        private CancellationToken token;
        private bool isSorting;

        // public
        public string SelectedSortType
        {
            get => selectedSortType;
            set
            {
                selectedSortType = value;
                OnPropertyChanged(nameof(SelectedSortType));
            }
        }
        public RenderObject[] Arr
        {
            get => arr;
            set
            {
                arr = value;
                OnPropertyChanged(nameof(Arr));
            }
        }
        public int N
        {
            get => n;
            set
            {
                n = value;
                OnPropertyChanged(nameof(N));
            }
        }
        public bool IsSorting
        {
            get => isSorting;
            set
            {
                isSorting = value;
                OnPropertyChanged(nameof(IsSorting));
            }
        }

        public ObservableCollection<string> SortTypes { get; set; }

        // commands
        public RelayCommand ShuffleCommand { get; private set; }
        public RelayCommand SortCommand { get; private set; }
        public RelayCommand StopSortingCommand { get; private set; }

        // methods
        public MainVM()
        {
            SortTypes = new ObservableCollection<string> { "Bubble", "Quick" };
            SelectedSortType = "Bubble";

            N = 20;
            Arr = GetArray(N);



            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;

            sorts = Sorts.getInstance();
            RenderObject.ResetIndexes();

            IsSorting = false;
            ShuffleCommand = new RelayCommand(Shuffle);
            SortCommand = new RelayCommand(SortAsync);
            StopSortingCommand = new RelayCommand(StopSorting);
        }

        public RenderObject[] GetArray(int n)
        {
            var arr = new RenderObject[n];
            var rand = new Random();
            for (int i = 0; i < n; i++)
            {
                arr[i].value = rand.Next(5, 100);
            }

            return arr;
        }

        private async void SortAsync()
        {
            IsSorting = true;
            switch (SelectedSortType)
            {
                case "Bubble":
                    {
                        await Task.Run(() => { sorts.BubbleSort(Arr, token); });
                        break;
                    }
                case "Quick":
                    {
                        await Task.Run(() => { sorts.QuickSort(Arr, 0, N - 1, token); });
                        break;
                    }
            }
            IsSorting = false;
        }

        public void Shuffle()
        {
            var n = Arr.Length;
            var rand = new Random();
            while (n > 1)
            {
                var k = rand.Next(n--);
                var temp = Arr[n];
                Arr[n] = Arr[k];
                Arr[k] = temp;
            }
        }
        public void StopSorting()
        {
            tokenSource.Cancel();
            IsSorting = false;

            RenderObject.ResetIndexes();

            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;
        }

        #region PropertyChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
