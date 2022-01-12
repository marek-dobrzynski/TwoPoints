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
                var point = e.GetPosition((IInputElement)sender);
                SetLabels(point);
                _pixelManager.UserClick(point);

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

        private void SetLabels(Point point)
        {
            if (point1.Content == null || point2.Content != null)
            {
                point1.Content = $"x: {point.X} y: {point.Y}";
                point2.Content = null;
            }
            else if (point2.Content == null)
            {
                point2.Content = $"x: {point.X} y: {point.Y}";
            }

        }

        private void ClearLabels()
        {
            point1.Content = null;
            point2.Content = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClearLabels();
            _pixelManager.ClearCanvas();
            _pixelManager = PixelManager.CreateInstance(canvas);

        }
    }
}
