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
using System.Configuration;

namespace Wordcards_Stack_Gadget
{
    /// <summary>
    /// Logic of gadget
    /// </summary>
    public partial class Gadget : Window, presenter.ICardInvokeableStackView
    {
        /// <summary>
        /// Configuration
        /// </summary>
        Configuration cfg;
        /// <summary>
        /// Presenter
        /// </summary>
        CardStackPresenter presenter;
        /// <summary>
        /// Cursor position of Edit Transcription textbox.
        /// </summary>
        int editTranscriptionIndex = 0;

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

            cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            Left = Int32.Parse(cfg.AppSettings.Settings["LocationX"].Value);
            Top = Int32.Parse(cfg.AppSettings.Settings["LocationY"].Value);
            Width = Int32.Parse(cfg.AppSettings.Settings["Width"].Value);
            Height = Int32.Parse(cfg.AppSettings.Settings["Height"].Value);

            string symbols = cfg.AppSettings.Settings["Symbols"].Value;
            if (!string.IsNullOrWhiteSpace(symbols))
            {
                string[] arr = symbols.Split(new char[] { ';' });
                cbSymbols.ItemsSource = arr;
            }

            SourceInitialized += new EventHandler(Gadjet_SourceInitialized);

            int defaultCardRank = Int32.Parse(cfg.AppSettings.Settings["DefaultRank"].Value);
            if (defaultCardRank < 0) defaultCardRank = 10;
            presenter = new CardStackPresenter(this, defaultCardRank);
            presenter.NextCard();
        }

        #region ICardStackView

        public void ShowEngSide(string Eng, string EngDesc, string transcription)
        {
            tbWord.Style = GetStyle(Eng);

            tbWord.Text = Eng;
            tbDescriprion.Text = EngDesc;
            lTracsription.Text = transcription;

            edit_Word.Text = Eng;
            edit_Transcription.Text = transcription;
            edit_Descriprion.Text = EngDesc;
        }

        public void ShowRusSide(string Rus, string Eng, string RusDesc)
        {
            tbWord.Style = GetStyle(Rus);

            tbWord.Text = Rus;
            tbDescriprion.Text = RusDesc;
            lTracsription.Text = Eng;

            edit_RusWord.Text = Rus;
            edit_RusDescriprion.Text = RusDesc;
        }

        private Style GetStyle(string word)
        {
            if (word.Length <= 14)
                return (Style)this.Resources["wordField"];
            else
                return (Style)this.Resources["wordFieldSmall"];
        }

        public void SetBgColor(byte r, byte g, byte b)
        {
            rectangle2.Fill = new SolidColorBrush(Color.FromRgb(r, g, b));
            gridToolbar.Background = rectangle2.Fill;
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
            presenter.NextCard();
            //don't set active window cos of we shouldn't steal user focus.
            this.Topmost = true;
            this.Topmost = false;
        }

        public string EditEng           { get { return edit_Word.Text; } }
        public string EditEngDesc       { get { return edit_Descriprion.Text; } }
        public string EditTranscription { get { return edit_Transcription.Text; } }
        public string EditRus           { get { return edit_RusWord.Text; } }
        public string EditRusDesc       { get { return edit_RusDescriprion.Text; } }
        public bool IsPlayMode { get; set; }

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
            //TODO: Close request.
            presenter.RemoveCurentCard();
        }

        private void iPla_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            presenter.PlayMode();
        }

        private void iFlip_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (EditRusContent.Visibility != Visibility.Visible)
            {
                presenter.ShowBackSide();
                this.ShowGrid(EditRusContent);
                edit_RusWord.Focus();
            }
            else
            {
                presenter.ShowForwardSide();
                this.ShowGrid(EditEngContent);
                edit_Word.Focus();
            }
        }

        private void iSave_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            presenter.Save();
            iCancel_MouseLeftButtonDown(sender, e);
        }

        private void iCancel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.ShowGrid(CardContent);
            gridStatusbar.Visibility = System.Windows.Visibility.Hidden;

            presenter.SwitchDisplay();
        }

        #endregion

        private void ShowGrid(Grid grid)
        {
            CardContent.Visibility = Visibility.Hidden;
            EditEngContent.Visibility = Visibility.Hidden;
            EditRusContent.Visibility = Visibility.Hidden;

            grid.Visibility = Visibility.Visible;
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            gridToolbar.Background = 
                new Random().Next(0,2) == 1 ?
                (Brush)new LinearGradientBrush(Color.FromArgb(125, 210, 180, 140), Color.FromRgb(210, 180, 140), 0) :
                (Brush) new SolidColorBrush(Color.FromRgb(210, 180, 140));

            iPla.Opacity = 1;
            iEdt.Opacity = 1;
            iNew.Opacity = 1;
            iDel.Opacity = 1;
            iClo.Opacity = 1;
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            gridToolbar.Background = rectangle2.Fill;

            if (!IsPlayMode)
                iPla.Opacity = 0;

            iEdt.Opacity = 0;
            iNew.Opacity = 0;
            iDel.Opacity = 0;
            iClo.Opacity = 0;
        }

        private void gridToolbar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void CardContent_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            presenter.NextCard();
        }

        private void CardContent_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            presenter.Flip();
        }

        private void iPrevCard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            presenter.PreviouseCard();
        }

        private void iNextCard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            presenter.NextCard();
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

        private void Window_LocationChanged(object sender, EventArgs e)
        {
            cfg.AppSettings.Settings["LocationX"].Value = Left.ToString();
            cfg.AppSettings.Settings["LocationY"].Value = Top.ToString();
            cfg.Save();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            cfg.AppSettings.Settings["Width"].Value = Width.ToString();
            cfg.AppSettings.Settings["Height"].Value = Height.ToString();
            cfg.Save();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            switch (((MenuItem)sender).Name)
            {
                case "prvCard":
                    iPrevCard_MouseLeftButtonDown(sender, null);
                    break;
                case "nxtCard":
                    iNextCard_MouseLeftButtonDown(sender, null);
                    break;
                case "sv":
                    //presenter.ExportAs("export.xml");
                    MessageBox.Show("Not implemented yet.");
                    break;
                case "ld":
                    //presenter.LoadFrom("import.xml");
                    MessageBox.Show("Not implemented yet.");
                    break;
                case "plyMode":
                    iPla_MouseLeftButtonDown(sender, null);
                    break;
                case "addCard":
                    iNew_MouseLeftButtonDown(sender, null);
                    break;
                case "chgCard":
                    iEdt_MouseLeftButtonDown(sender, null);
                    break;
                case "delCard":
                    iDel_MouseLeftButtonDown(sender, null);
                    break;
                case "abt":
                    MessageBox.Show("Simple WPF gadget for learning words and phrases.\r\nFor mor infotmation you should visit \r\nhttps://github.com/paveltimofeev/Wordcards");
                    break;
                case "cls":
                    iClo_MouseLeftButtonDown(sender, null);
                    break;
            }
        }

        /// <summary>
        /// [TEST]
        /// Text scalability
        /// </summary>
        private void edit_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox refer = (TextBox)sender;

            if (refer.LineCount != 1)
                refer.FontSize--;
            else
            {
                Rect rect = refer.GetRectFromCharacterIndex(refer.Text.Length);
                if (rect.BottomRight.X / 2 < refer.ActualWidth / 2)
                    refer.FontSize++;
            }
        }

        private void cbSymbols_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            edit_Transcription.Text = string.Format("{0}{1}{2}", edit_Transcription.Text.Substring(0, editTranscriptionIndex), cbSymbols.SelectedValue, edit_Transcription.Text.Substring(editTranscriptionIndex));
            edit_Transcription.Focus();
            edit_Transcription.CaretIndex = editTranscriptionIndex;
        }

        /// <summary>
        /// Handle change of cursor position in the Edit Transcription textbox
        /// </summary>
        private void edit_Transcription_SelectionChanged(object sender, RoutedEventArgs e)
        {
            editTranscriptionIndex = edit_Transcription.CaretIndex;
        }
    }
}
