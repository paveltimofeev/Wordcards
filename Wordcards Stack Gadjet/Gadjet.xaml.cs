using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using presenter;
using System.Windows.Interop;
using System.Runtime.InteropServices;

namespace Wordcards_Stack_Gadjet
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Gadjet : Window, presenter.ICardStackView
    {
        CardStackPresenter presenter;

        Brush forwardColour;
        Brush backColour;

        #region Resize border
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int ht_caption = 0X2;
        private const int WM_SYSCOMMAND = 0x112;
        private HwndSource hwndSource;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public enum ResizeDirection
        {
            BottomRight = 8
        }
        #endregion

        public Gadjet()
        {
            InitializeComponent();

            this.SourceInitialized += new EventHandler(Gadjet_SourceInitialized);

            forwardColour = rectangle2.Fill;
            backColour = new SolidColorBrush(Color.FromRgb(255, 219, 196));

            presenter = new CardStackPresenter(this);
            presenter.Next();
        }

        #region ICardStackView

        public void ShowEngSide(string Eng, string EngDesc, string transcription)
        {
            rectangle2.Fill = forwardColour;
            textBox1.Content = Eng;
            textBox2.Text = EngDesc;
            label1.Content = transcription;
        }

        public void ShowRusSide(string Rus, string Eng, string RusDesc)
        {
            rectangle2.Fill = backColour;
            textBox1.Content = Rus;
            textBox2.Text = RusDesc;
            label1.Content = Eng;
        }

        public void ShowAdditionalInfo(int wordType, int Rank)
        {
            label2.Content = string.Format("Rank: {0}", Rank);
        }

        public void Refresh()
        {
            this.UpdateLayout();
        }

        public string EditEng { get { return ""; } }
        public string EditEngDesc { get { return ""; } }
        public string EditTranscription { get { return ""; } }
        public string EditRus { get { return ""; } }
        public string EditRusDesc { get { return ""; } }

        #endregion

        #region Resize border

        private void Gadjet_SourceInitialized(object sender, EventArgs e)
        {
            hwndSource = PresentationSource.FromVisual((Visual)sender) as HwndSource;
        }

        private void ResizeWindow(ResizeDirection direction)
        {
            SendMessage(hwndSource.Handle, WM_SYSCOMMAND, (IntPtr)(61440 + direction), IntPtr.Zero);
        }

        private void Window_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (Mouse.LeftButton != MouseButtonState.Pressed)
                Cursor = Cursors.Arrow;
        }

        private void rResizePoint_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.SizeNWSE;
        }

        private void rResizePoint_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Cursor = Cursors.SizeNWSE;
            ResizeWindow(ResizeDirection.BottomRight);
        }

        #endregion

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                this.DragMove();
            else
                presenter.Next();
        }

        private void Grid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            presenter.Flip();
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            gridToolbar.Opacity = 1;
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            gridToolbar.Opacity = 0;
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void iNew_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void iEdt_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void iDel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            presenter.RemoveCurentCard();
        }

        #region ICardStackView Members


        public ViewState State
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
