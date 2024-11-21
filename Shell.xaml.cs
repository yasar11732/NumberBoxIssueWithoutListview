using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace NumberBoxIssueWithoutListview;

public partial class Item(int value, int min):ObservableObject
{
    [ObservableProperty]
    private int _value = value;

    public int Min { get; } = min;
}

public partial class ShellViewModel : ObservableObject
{
    [ObservableProperty]
    private Item _selected = new(0,0);

    [ObservableProperty]
    private ObservableCollection<Item> _items = [
        new(3,3),
        new(1,1),
        new(4,4),
        new(2,2)
    ];

    private int _counter = 0;

    [RelayCommand]
    private void Shift()
    {
        Selected = Items[_counter++ % Items.Count] ;
    }
}

public sealed partial class Shell : Page
{
    public ShellViewModel ViewModel { get; } = new();

    public Shell()
    {
        this.InitializeComponent();
    }
}
