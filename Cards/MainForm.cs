using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using presenter;
using System.Collections;
using System.IO;

namespace Cards
{
    public partial class MainForm : Form, ICardListView
    {
        CardListPresenter presenter;
        BindingSource bs = new BindingSource();
        int wtId = -1;

        public MainForm()
        {
            InitializeComponent();

            for (int i = 0; i < ilWordType.Images.Count; i++)
            {
                ToolStripMenuItem tsm = new ToolStripMenuItem(ilWordType.Images.Keys[i], ilWordType.Images[i]);
                tsm.Tag = i.ToString();
                tsm.Click += new EventHandler(tsm_Click);
                contextMenu.Items.Add(tsm);
            }

            bs.BindingComplete += new BindingCompleteEventHandler(bs_BindingComplete);

            dgvGrid.DataSource = bs;
            presenter = new CardListPresenter(this);
        }

        void bs_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            tsRowCount.Text = string.Format("Rows: {0}", dgvGrid.Rows.Count);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("default.xml"))
                presenter.LoadXML("default.xml");
        }

        #region ICardListView Members

        public IList Datasource
        {
            get
            {
                return (IList)bs.DataSource;
            }
            set
            {
                bs.DataSource = value;
                tsRowCount.Text = string.Format("Rows: {0}", bs.Count);
                wtId = dgvGrid.Columns.Contains("WordType") ? dgvGrid.Columns["WordType"].Index : -1;
            }
        }

        public string FilterValue
        {
            get { return tsFindText.Text; }
        }

        public void SetStatus(string message)
        {
           tsStatus.Text = message;
        }

        public void ShowBaloon(string title, string text, string tooltip)
        {
            nf.BalloonTipTitle = string.IsNullOrWhiteSpace(title) ? "n/a" : title;
            nf.BalloonTipText = string.IsNullOrWhiteSpace(text) ? "n/a" : text;
            nf.Text = string.IsNullOrWhiteSpace(tooltip) ? "n/a" : tooltip.Length < 63 ? tooltip : tooltip.Substring(0, 63);
            nf.ShowBalloonTip(5000);
        }

        #endregion

        private void tsAdd_Click(object sender, EventArgs e)
        {
            bs.AddNew();
        }

        private void tsRemove_Click(object sender, EventArgs e)
        {
            if (bs.Count > 0)
                bs.RemoveCurrent();
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            presenter.SaveDatabase();
        }

        private void tsExport_Click(object sender, EventArgs e)
        {
            if (sfdExport.ShowDialog() == DialogResult.OK)
                presenter.SaveXML(sfdExport.FileName);
        }

        private void tsImport_Click(object sender, EventArgs e)
        {
            if (ofdImport.ShowDialog() == DialogResult.OK)
                presenter.LoadXML(ofdImport.FileName);
        }

        private void tsGetCards_Click(object sender, EventArgs e)
        {

        }

        private void tsSort_Click(object sender, EventArgs e)
        {
            presenter.Sort();
        }

        private void dgvGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (wtId > 0 && e.ColumnIndex == 0 & wtId < dgvGrid.Columns.Count)
            {
                object val = (dgvGrid.Rows[e.RowIndex].Cells[wtId]).Value;

                int id = (val != null) ? Int32.Parse(val.ToString()) : -1;

                if (id > 0)
                    e.Value = ilWordType.Images[id];
            }
        }

        private void tsToFB2_Click(object sender, EventArgs e)
        {
            if (sfdFD2.ShowDialog() == DialogResult.OK)
                presenter.SaveFB2(sfdFD2.FileName);
        }

        private void tsm_Click(object sender, EventArgs e)
        {
            dgvGrid.SelectedRows[0].Cells[wtId].Value = ((ToolStripMenuItem)sender).Tag;
            dgvGrid.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            presenter.GetNewRandom();
            timer1.Interval = new Random().Next(60000, 300000);
        }

        private void tsStartBaloons_CheckStateChanged(object sender, EventArgs e)
        {
            timer1.Enabled = tsStartBaloons.Checked;

            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = !tsStartBaloons.Checked;
            this.Visible = !tsStartBaloons.Checked;

            timer1_Tick(timer1, EventArgs.Empty);
        }

        private void nf_DoubleClick(object sender, EventArgs e)
        {
            tsStartBaloons.Checked = false;
        }

        private void nf_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                presenter.GetNewRandom();
            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
                presenter.TranslateRandom();
        }

        private void tsToHTML_Click(object sender, EventArgs e)
        {
            if (sfdHTML.ShowDialog() == DialogResult.OK)
                presenter.SaveHTM(sfdHTML.FileName);
        }

        private void tsFilter_Click(object sender, EventArgs e)
        {
            presenter.Filter();
        }

        private void tsRemoveFilter_Click(object sender, EventArgs e)
        {
            tsFindText.Text = "";
            presenter.Filter();
        }

        private void tsFindText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Control)
                tsFilter_Click(null, EventArgs.Empty);
            else if (e.KeyCode == Keys.Enter && e.Control)
                tsRemoveFilter_Click(null, EventArgs.Empty);
        }

        private void tsSortRank_Click(object sender, EventArgs e)
        {
            presenter.SortRank();
        }
    }
}
