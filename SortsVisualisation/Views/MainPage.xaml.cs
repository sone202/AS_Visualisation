using SortsVisualisation.ViewModels;
using SortsVisualisation.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Windows.UI;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Effects;
using Microsoft.Graphics.Canvas.Brushes;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SortsVisualisation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private RenderObject[] arr;

        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainVM();

            arr = (DataContext as MainVM).Arr;
        }

        private void ChartCanvas_Draw(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {

            var canvas = sender;
            var canvasHeight = canvas.Size.Height - 200;
            var canvasWidth = canvas.Size.Width;

            const int GAP = 5;

            var n = arr.Length;
            var heightStep = canvasHeight / (arr.Select(x => x.value).Max() - arr.Select(x => x.value).Min());
            var rectWidth = (canvasWidth - (GAP * (n + 1))) / n;

            for (int i = 0; i < n; i++)
            {
                var rect = new Rect
                {
                    Height = heightStep * arr[i].value,
                    Width = rectWidth,
                    X = (GAP * (i + 1)) + (rectWidth * i),
                    Y = 0
                };

                args.DrawingSession.DrawRectangle(rect, ColorPalette.Sunray);

                if (RenderObject.PivotIndex == i)
                {
                    args.DrawingSession.FillRectangle(rect, ColorPalette.MediumAquamarine);
                }
                else if (RenderObject.ComparableIndex == i)
                {
                    args.DrawingSession.FillRectangle(rect, ColorPalette.LightCoral);
                }
                else if (RenderObject.FirstSwapIndex == i)
                {
                    args.DrawingSession.FillRectangle(rect, ColorPalette.QueenBlue);
                }
                else if (RenderObject.SecondSwapIndex == i)
                {
                    args.DrawingSession.FillRectangle(rect, ColorPalette.LightCoral);
                }
            }
        }

        // TODO: Refactor
        private void ArraySizeChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var mainVM = (DataContext as MainVM);

                var n = int.Parse((sender as TextBox).Text);
                if (n >= 200)
                {
                    n = 200;
                    (sender as TextBox).Text = 200.ToString();
                }

                mainVM.Arr = mainVM.GetArray(n);
                arr = mainVM.Arr;
            }
            catch { }
        }

     
    }
}
