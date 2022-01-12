using System;
using System.Windows;
using System.Windows.Input;
using TwoPointsLib;
using TwoPointsLib.Interfaces;

namespace TwoPointsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IPixelManager _pixelManager;

        public MainWindow()
        {
            InitializeComponent();
            _pixelManager = PixelManager.CreateInstance(canvas);
        }
        
        private void User_click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                _pixelManager.UserClick(e.GetPosition((IInputElement)sender));
            }
            catch (Exception exception)
            {
                ShowAlert(exception);
            }
        }

        private void ShowAlert(Exception exception)
        {
            MessageBox.Show(exception.Message);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _pixelManager.ClearCanvas();
            _pixelManager = PixelManager.CreateInstance(canvas);
        }
    }
}
