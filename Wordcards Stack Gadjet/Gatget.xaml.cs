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
using System.Timers;

namespace Wordcards_Stack_Gadjet
{
    /// <summary>
    /// Логика взаимодействия для test.xaml
    /// </summary>
    public partial class Gadget : Window, presenter.ICardInvokeableStackView
    {
        CardStackPresenter presenter;

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

        public Gadget()
        {
            InitializeComponent();

            this.SourceInitialized += new EventHandler(Gadjet_SourceInitialized);

            presenter = new CardStackPresenter(this);
            presenter.Next();
        }

        #region ICardStackView

        public void ShowEngSide(string Eng, string EngDesc, string transcription)
        {
            tbWord.Text = Eng;
            tbDescriprion.Text = EngDesc;
            lTracsription.Text = transcription;

            edit_Word.Text = Eng;
            edit_Transcription.Text = transcription;
            edit_Descriprion.Text = EngDesc;
        }

        public void ShowRusSide(string Rus, string Eng, string RusDesc)
        {
            tbWord.Text = Rus;
            tbDescriprion.Text = RusDesc;
            lTracsription.Text = Eng;

            edit_RusWord.Text = Rus;
            edit_RusDescriprion.Text = RusDesc;
        }

        public void SetBgColor(byte r, byte g, byte b)
        {
            rectangle2.Fill = new SolidColorBrush(Color.FromRgb(r, g, b));
        }

        public void ShowAdditionalInfo(int totalWords, int Rank)
        {
            lRank.Content = string.Format("Words: {0} | Rank: {1}", totalWords, Rank);
        }

        public void Refresh()
        {
            this.UpdateLayout();
        }

        public void BringOnTop()
        {
            presenter.Next();
            this.Topmost = true;
            this.Topmost = false;
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

        #region Toolbar's handlers

        private void iClo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void iNew_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.ShowGrid(EditEngContent);
            gridStatusbar.Visibility = Visibility.Visible;

            presenter.SwitchNew();

            edit_Word.Text = "";
            edit_Transcription.Text = "";
            edit_Descriprion.Text = "";
            edit_RusWord.Text = "";
            edit_RusDescriprion.Text = "";
            edit_Word.Focus();
        }

        private void iEdt_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.ShowGrid(EditEngContent);
            gridStatusbar.Visibility = System.Windows.Visibility.Visible;

            presenter.SwitchEdit();

            edit_Word.Focus();
        }

        private void iDel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            presenter.RemoveCurentCard();
        }

        private void iPla_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            presenter.PlayMode();
        }

        private void iSide1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            presenter.ShowForwardSide();
            this.ShowGrid(EditEngContent);
            edit_Word.Focus();
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
            this.ShowGrid(CardContent);
            gridStatusbar.Visibility = System.Windows.Visibility.Hidden;

            presenter.SwitchDisplay();
        }

        #endregion

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            gridToolbar.Opacity = 1;
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            gridToolbar.Opacity = 0;
        }

        private void gridToolbar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void CardContent_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            presenter.Next();
        }

        private void CardContent_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            presenter.Flip();
        }

        private void ShowGrid(Grid grid)
        {
            CardContent.Visibility = Visibility.Hidden;
            EditEngContent.Visibility = Visibility.Hidden;
            EditRusContent.Visibility = Visibility.Hidden;

            grid.Visibility = Visibility.Visible;
        }

        private void iCancel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            presenter.SwitchDisplay();
        }

        private void iPrevCard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            presenter.PreviouseCard();
        }

        private void iNextCard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            presenter.NextCard();
        }

        private void rectangleGrid_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mouse.GetPosition(this).X > this.Width / 2)
            {
                iNextCard.Opacity = 1;
                iPrevCard.Opacity = 0;
            }
            else
            {
                iPrevCard.Opacity = 1;
                iNextCard.Opacity = 0;
            }
        }

        private void rectangleGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            iNextCard.Opacity = 0;
            iPrevCard.Opacity = 0;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    presenter.PreviouseCard();
                    break;
                case Key.Right:
                    presenter.NextCard();
                    break;
                case Key.Down:
                    presenter.ShowBackSide();
                    break;
                case Key.Up:
                    presenter.ShowForwardSide();
                    break;
                default:
                    break;
            }
        }
    }
}
