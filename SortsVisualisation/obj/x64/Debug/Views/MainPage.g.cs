﻿#pragma checksum "C:\Users\timzl\source\repos\SortsVisualisation\AS_Visualisation\SortsVisualisation\Views\MainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9A4867D0BC6019101E69A08E7B29FF165898A8E63542ACBC6821A8A468B4DAB7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SortsVisualisation
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Views\MainPage.xaml line 73
                {
                    this.ChartCanvas = (global::Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedControl)(target);
                    ((global::Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedControl)this.ChartCanvas).Draw += this.ChartCanvas_Draw;
                }
                break;
            case 3: // Views\MainPage.xaml line 52
                {
                    this.StartSortButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 4: // Views\MainPage.xaml line 58
                {
                    this.StopButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 5: // Views\MainPage.xaml line 65
                {
                    this.MixArrayButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 6: // Views\MainPage.xaml line 44
                {
                    global::Windows.UI.Xaml.Controls.TextBox element6 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)element6).TextChanged += this.ArraySizeChanged;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

