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
using System.Windows.Media.Animation;
using presenter;
using System.Windows.Interop;
using System.Runtime.InteropServices;

namespace Wordcards_Stack_Gadjet
{
    /// <summary>
    /// Логика взаимодействия для test.xaml
    /// </summary>
    public partial class test : Window, presenter.ICardStackView
    {
        CardStackPresenter presenter;
        Brush forwardColour;
        Brush backColour;
        bool isEdit = false;

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

        public test()
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

            tbWord.Text = Eng;
            tbDescriprion.Text = EngDesc;
            lTracsription.Text = transcription;

            if (!isEdit)
            {
                edit_Word.Text = Eng;
                edit_Transcription.Text = transcription;
                edit_Descriprion.Text = EngDesc;
            }
        }

        public void ShowRusSide(string Rus, string Eng, string RusDesc)
        {
            rectangle2.Fill = backColour;

            tbWord.Text = Rus;
            tbDescriprion.Text = RusDesc;
            lTracsription.Text = Eng;

            if (!isEdit)
            {
                edit_RusWord.Text = Rus;
                edit_RusDescriprion.Text = RusDesc;
            }
        }

        public void ShowAdditionalInfo(int wordType, int Rank)
        {
            lRank.Content = string.Format("Rank: {0}", Rank);
        }

        public void Refresh()
        {
            this.UpdateLayout();
        }

        public string EditEng           { get { return edit_Word.Text; } }
        public string EditEngDesc       { get { return edit_Descriprion.Text; } }
        public string EditTranscription { get { return edit_Transcription.Text; } }
        public string EditRus           { get { return edit_RusWord.Text; } }
        public string EditRusDesc       { get { return edit_RusDescriprion.Text; } }

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
            isEdit = true;

            this.ShowGrid(EditEngContent);
            gridStatusbar.Visibility = System.Windows.Visibility.Visible;

            edit_Word.Text = "";
            edit_Transcription.Text = "";
            edit_Descriprion.Text = "";
            edit_RusWord.Text = "";
            edit_RusDescriprion.Text = "";
            edit_Word.Focus();
        }

        private void iEdt_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isEdit = true;
            this.ShowGrid(EditEngContent);
            gridStatusbar.Visibility = System.Windows.Visibility.Visible;

            presenter.ShowForwardSide();
            edit_Word.Focus();
        }

        private void iDel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            presenter.RemoveCurentCard();
        }

        private void iSide1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            presenter.ShowForwardSide();
            this.ShowGrid(EditEngContent);
        }

        private void iSide2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            presenter.ShowBackSide();
            this.ShowGrid(EditRusContent);
            edit_RusWord.Focus();
        }

        private void iSave_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            presenter.Save();
            isEdit = false;
            this.ShowGrid(CardContent);

            presenter.ShowForwardSide();
        }

        private void ShowGrid(Grid grid)
        {
            CardContent.Visibility = System.Windows.Visibility.Hidden;
            EditEngContent.Visibility = System.Windows.Visibility.Hidden;
            EditRusContent.Visibility = System.Windows.Visibility.Hidden;
            gridStatusbar.Visibility = System.Windows.Visibility.Hidden;

            grid.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
