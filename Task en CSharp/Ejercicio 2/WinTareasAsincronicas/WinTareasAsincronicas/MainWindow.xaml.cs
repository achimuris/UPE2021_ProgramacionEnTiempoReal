using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace WinTareasAsincronicas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnActivaDesactivaImagen_Click(object sender, RoutedEventArgs e)
        {
            if (this.btnUnaFoto.Content.Equals("SIN TEXTO"))
                this.btnUnaFoto.Content = "CON TEXTO";
            else
                this.btnUnaFoto.Content = "SIN TEXTO";
        }
        private int ProcesoSincronico()
        {

            btnProcesoPesadoSincronico.Background = Brushes.Red;
            Mouse.OverrideCursor = Cursors.Wait;
            Thread.Sleep(10000);
            Mouse.OverrideCursor = Cursors.Arrow;
            btnProcesoPesadoSincronico.Background = Brushes.LightGray;
            return 1;
        }

        private async Task<int> ProcesoAsincronoAsync()
        {
            //SolidColorBrush colorAnterior = btnProcesoPesadoAsincronico.Background();
            //new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
            btnProcesoPesadoAsincronico.Background = Brushes.Red;
            await Task.Run(() => {
                
                Thread.Sleep(10000);
            });
            btnProcesoPesadoAsincronico.Background = Brushes.LightGray;

            return 1;
        }

        private void BtnProcesoPesadoSincronico_Click(object sender, RoutedEventArgs e)
        {
            ProcesoSincronico();
        }

        private async void BtnProcesoPesadoAsincronico_Click(object sender, RoutedEventArgs e)
        {
            await ProcesoAsincronoAsync();
        }
    }
}
