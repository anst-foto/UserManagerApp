using System.Windows;
using System.Windows.Controls;

namespace UserManagerApp.Desktop.Components;

public partial class InputComponent : UserControl
{
    public static readonly DependencyProperty LabelProperty = 
        DependencyProperty.Register(nameof(Label), typeof(object), typeof(InputComponent));
    public object Label
    {
        get => GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }
    
    public static readonly DependencyProperty ValueProperty = 
        DependencyProperty.Register(nameof(Value), typeof(string), typeof(InputComponent));
    public string Value
    {
        get => (string)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }
    
    public InputComponent()
    {
        InitializeComponent();
    }
}