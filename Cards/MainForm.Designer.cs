namespace Cards
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dgvGrid = new System.Windows.Forms.DataGridView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WordType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsRowCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsFind = new System.Windows.Forms.ToolStripLabel();
            this.tsFindText = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.ofdImport = new System.Windows.Forms.OpenFileDialog();
            this.sfdExport = new System.Windows.Forms.SaveFileDialog();
            this.ilWordType = new System.Windows.Forms.ImageList(this.components);
            this.sfdFD2 = new System.Windows.Forms.SaveFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.nf = new System.Windows.Forms.NotifyIcon(this.components);
            this.sfdHTML = new System.Windows.Forms.SaveFileDialog();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Ico = new System.Windows.Forms.DataGridViewImageColumn();
            this.tsAdd = new System.Windows.Forms.ToolStripButton();
            this.tsRemove = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.tsImport = new System.Windows.Forms.ToolStripButton();
            this.tsExport = new System.Windows.Forms.ToolStripButton();
            this.tsToFB2 = new System.Windows.Forms.ToolStripButton();
            this.tsToHTML = new System.Windows.Forms.ToolStripButton();
            this.tsGetCards = new System.Windows.Forms.ToolStripButton();
            this.tsSort = new System.Windows.Forms.ToolStripButton();
            this.tsSortRank = new System.Windows.Forms.ToolStripButton();
            this.tsFilter = new System.Windows.Forms.ToolStripButton();
            this.tsRemoveFilter = new System.Windows.Forms.ToolStripButton();
            this.tsStartBaloons = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvGrid
            // 
            this.dgvGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrid.ColumnHeadersVisible = false;
            this.dgvGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ico,
            this.Column1,
            this.Column3,
            this.Column2,
            this.Column4,
            this.Column5,
            this.WordType,
            this.Rank});
            this.dgvGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrid.GridColor = System.Drawing.SystemColors.Control;
            this.dgvGrid.Location = new System.Drawing.Point(0, 25);
            this.dgvGrid.Name = "dgvGrid";
            this.dgvGrid.RowHeadersVisible = false;
            this.dgvGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
            this.dgvGrid.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            this.dgvGrid.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrid.Size = new System.Drawing.Size(854, 300);
            this.dgvGrid.TabIndex = 0;
            this.dgvGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvGrid_CellFormatting);
            // 
            // contextMenu
            // 
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.DataPropertyName = "Eng";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "ENG";
            this.Column1.MinimumWidth = 100;
            this.Column1.Name = "Column1";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.DataPropertyName = "Transcription";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column3.HeaderText = "Trans";
            this.Column3.Name = "Column3";
            this.Column3.Width = 21;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.DataPropertyName = "Rus";
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "RUS";
            this.Column2.MinimumWidth = 100;
            this.Column2.Name = "Column2";
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.DataPropertyName = "EngDesc";
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column4.HeaderText = "";
            this.Column4.MinimumWidth = 200;
            this.Column4.Name = "Column4";
            this.Column4.Width = 200;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.DataPropertyName = "RusDesc";
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column5.HeaderText = "";
            this.Column5.MinimumWidth = 200;
            this.Column5.Name = "Column5";
            // 
            // WordType
            // 
            this.WordType.DataPropertyName = "WordType";
            this.WordType.HeaderText = "WordType";
            this.WordType.Name = "WordType";
            this.WordType.Visible = false;
            this.WordType.Width = 5;
            // 
            // Rank
            // 
            this.Rank.DataPropertyName = "Rank";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.Rank.DefaultCellStyle = dataGridViewCellStyle6;
            this.Rank.FillWeight = 30F;
            this.Rank.HeaderText = "Rank";
            this.Rank.MinimumWidth = 22;
            this.Rank.Name = "Rank";
            this.Rank.ReadOnly = true;
            this.Rank.Width = 22;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsRowCount,
            this.tsStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 325);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(854, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsRowCount
            // 
            this.tsRowCount.Name = "tsRowCount";
            this.tsRowCount.Size = new System.Drawing.Size(46, 17);
            this.tsRowCount.Text = "Rows: 0";
            // 
            // tsStatus
            // 
            this.tsStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(4, 17);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAdd,
            this.tsRemove,
            this.toolStripSeparator1,
            this.tsSave,
            this.tsImport,
            this.tsExport,
            this.tsToFB2,
            this.tsToHTML,
            this.toolStripSeparator2,
            this.tsGetCards,
            this.toolStripSeparator3,
            this.tsSort,
            this.tsSortRank,
            this.toolStripSeparator5,
            this.tsFind,
            this.tsFindText,
            this.tsFilter,
            this.tsRemoveFilter,
            this.toolStripSeparator6,
            this.tsStartBaloons,
            this.toolStripSeparator4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(854, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tsFind
            // 
            this.tsFind.Name = "tsFind";
            this.tsFind.Size = new System.Drawing.Size(31, 22);
            this.tsFind.Text = "Filter";
            // 
            // tsFindText
            // 
            this.tsFindText.Name = "tsFindText";
            this.tsFindText.Size = new System.Drawing.Size(100, 25);
            this.tsFindText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tsFindText_KeyDown);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // ofdImport
            // 
            this.ofdImport.Filter = "XML files|*.xml|All| *.*";
            this.ofdImport.Title = "Import";
            // 
            // sfdExport
            // 
            this.sfdExport.FileName = "cards.xml";
            this.sfdExport.Filter = "XML files|*.xml|All| *.*";
            this.sfdExport.Title = "Export";
            // 
            // ilWordType
            // 
            this.ilWordType.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilWordType.ImageStream")));
            this.ilWordType.TransparentColor = System.Drawing.Color.Transparent;
            this.ilWordType.Images.SetKeyName(0, "Clear");
            this.ilWordType.Images.SetKeyName(1, "Noun");
            this.ilWordType.Images.SetKeyName(2, "Verb");
            this.ilWordType.Images.SetKeyName(3, "Adj");
            this.ilWordType.Images.SetKeyName(4, "Polite form");
            this.ilWordType.Images.SetKeyName(5, "Tabu");
            this.ilWordType.Images.SetKeyName(6, "Mark");
            // 
            // sfdFD2
            // 
            this.sfdFD2.FileName = "cards.fb2";
            this.sfdFD2.Filter = "FB2 files|*.fb2|All| *.*";
            this.sfdFD2.Title = "Export to FB2";
            // 
            // timer1
            // 
            this.timer1.Interval = 300000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // nf
            // 
            this.nf.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.nf.Icon = ((System.Drawing.Icon)(resources.GetObject("nf.Icon")));
            this.nf.Text = "Cards";
            this.nf.Visible = true;
            this.nf.DoubleClick += new System.EventHandler(this.nf_DoubleClick);
            this.nf.MouseClick += new System.Windows.Forms.MouseEventHandler(this.nf_MouseClick);
            // 
            // sfdHTML
            // 
            this.sfdHTML.FileName = "cards.html";
            this.sfdHTML.Filter = "HTML files|*.html|All| *.*";
            this.sfdHTML.Title = "Export to FB2";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.ContextMenuStrip = this.contextMenu;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::Cards.Properties.Resources.walk;
            this.dataGridViewImageColumn1.MinimumWidth = 22;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn1.ToolTipText = "Word type";
            this.dataGridViewImageColumn1.Width = 22;
            // 
            // Ico
            // 
            this.Ico.ContextMenuStrip = this.contextMenu;
            this.Ico.HeaderText = "";
            this.Ico.Image = global::Cards.Properties.Resources.space;
            this.Ico.MinimumWidth = 22;
            this.Ico.Name = "Ico";
            this.Ico.ReadOnly = true;
            this.Ico.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Ico.ToolTipText = "Word type";
            this.Ico.Width = 22;
            // 
            // tsAdd
            // 
            this.tsAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsAdd.Image = global::Cards.Properties.Resources.add;
            this.tsAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAdd.Name = "tsAdd";
            this.tsAdd.Size = new System.Drawing.Size(23, 22);
            this.tsAdd.Text = "Add";
            this.tsAdd.Click += new System.EventHandler(this.tsAdd_Click);
            // 
            // tsRemove
            // 
            this.tsRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsRemove.Image = global::Cards.Properties.Resources.delete;
            this.tsRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsRemove.Name = "tsRemove";
            this.tsRemove.Size = new System.Drawing.Size(23, 22);
            this.tsRemove.Text = "Remove";
            this.tsRemove.Click += new System.EventHandler(this.tsRemove_Click);
            // 
            // tsSave
            // 
            this.tsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSave.Image = global::Cards.Properties.Resources.database_save;
            this.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSave.Name = "tsSave";
            this.tsSave.Size = new System.Drawing.Size(23, 22);
            this.tsSave.Text = "Save";
            this.tsSave.Click += new System.EventHandler(this.tsSave_Click);
            // 
            // tsImport
            // 
            this.tsImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsImport.Image = global::Cards.Properties.Resources.card_import;
            this.tsImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsImport.Name = "tsImport";
            this.tsImport.Size = new System.Drawing.Size(23, 22);
            this.tsImport.Text = "Import";
            this.tsImport.Click += new System.EventHandler(this.tsImport_Click);
            // 
            // tsExport
            // 
            this.tsExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsExport.Image = global::Cards.Properties.Resources.card_export;
            this.tsExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsExport.Name = "tsExport";
            this.tsExport.Size = new System.Drawing.Size(23, 22);
            this.tsExport.Text = "Export";
            this.tsExport.Click += new System.EventHandler(this.tsExport_Click);
            // 
            // tsToFB2
            // 
            this.tsToFB2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsToFB2.Image = global::Cards.Properties.Resources.book_next;
            this.tsToFB2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsToFB2.Name = "tsToFB2";
            this.tsToFB2.Size = new System.Drawing.Size(23, 22);
            this.tsToFB2.Text = "Export to FB2";
            this.tsToFB2.Click += new System.EventHandler(this.tsToFB2_Click);
            // 
            // tsToHTML
            // 
            this.tsToHTML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsToHTML.Image = global::Cards.Properties.Resources.newspaper;
            this.tsToHTML.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsToHTML.Name = "tsToHTML";
            this.tsToHTML.Size = new System.Drawing.Size(23, 22);
            this.tsToHTML.Text = "Export to HTML";
            this.tsToHTML.Click += new System.EventHandler(this.tsToHTML_Click);
            // 
            // tsGetCards
            // 
            this.tsGetCards.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsGetCards.Enabled = false;
            this.tsGetCards.Image = global::Cards.Properties.Resources.document_comment_above;
            this.tsGetCards.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsGetCards.Name = "tsGetCards";
            this.tsGetCards.Size = new System.Drawing.Size(23, 22);
            this.tsGetCards.Text = "Get cards";
            this.tsGetCards.Click += new System.EventHandler(this.tsGetCards_Click);
            // 
            // tsSort
            // 
            this.tsSort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSort.Image = global::Cards.Properties.Resources.application_put;
            this.tsSort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSort.Name = "tsSort";
            this.tsSort.Size = new System.Drawing.Size(23, 22);
            this.tsSort.Text = "Sort by Eng";
            this.tsSort.Click += new System.EventHandler(this.tsSort_Click);
            // 
            // tsSortRank
            // 
            this.tsSortRank.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSortRank.Image = global::Cards.Properties.Resources.application_key;
            this.tsSortRank.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSortRank.Name = "tsSortRank";
            this.tsSortRank.Size = new System.Drawing.Size(23, 22);
            this.tsSortRank.Text = "Sort by rank";
            this.tsSortRank.Click += new System.EventHandler(this.tsSortRank_Click);
            // 
            // tsFilter
            // 
            this.tsFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsFilter.Image = global::Cards.Properties.Resources.filter_add;
            this.tsFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFilter.Name = "tsFilter";
            this.tsFilter.Size = new System.Drawing.Size(23, 22);
            this.tsFilter.Text = "Filter";
            this.tsFilter.Click += new System.EventHandler(this.tsFilter_Click);
            // 
            // tsRemoveFilter
            // 
            this.tsRemoveFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsRemoveFilter.Image = global::Cards.Properties.Resources.filter_delete;
            this.tsRemoveFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsRemoveFilter.Name = "tsRemoveFilter";
            this.tsRemoveFilter.Size = new System.Drawing.Size(23, 22);
            this.tsRemoveFilter.Text = "Remove filter";
            this.tsRemoveFilter.Click += new System.EventHandler(this.tsRemoveFilter_Click);
            // 
            // tsStartBaloons
            // 
            this.tsStartBaloons.CheckOnClick = true;
            this.tsStartBaloons.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsStartBaloons.Image = global::Cards.Properties.Resources.comment;
            this.tsStartBaloons.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsStartBaloons.Name = "tsStartBaloons";
            this.tsStartBaloons.Size = new System.Drawing.Size(23, 22);
            this.tsStartBaloons.Text = "Start baloons game";
            this.tsStartBaloons.CheckStateChanged += new System.EventHandler(this.tsStartBaloons_CheckStateChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 347);
            this.Controls.Add(this.dgvGrid);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(637, 374);
            this.Name = "MainForm";
            this.Text = "Cards";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGrid;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsAdd;
        private System.Windows.Forms.ToolStripButton tsRemove;
        private System.Windows.Forms.ToolStripButton tsExport;
        private System.Windows.Forms.ToolStripButton tsImport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsGetCards;
        private System.Windows.Forms.ToolStripButton tsSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripTextBox tsFindText;
        private System.Windows.Forms.ToolStripButton tsSort;
        private System.Windows.Forms.ToolStripStatusLabel tsRowCount;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.ToolStripStatusLabel tsStatus;
        private System.Windows.Forms.OpenFileDialog ofdImport;
        private System.Windows.Forms.SaveFileDialog sfdExport;
        private System.Windows.Forms.ImageList ilWordType;
        private System.Windows.Forms.ToolStripButton tsToFB2;
        private System.Windows.Forms.SaveFileDialog sfdFD2;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsStartBaloons;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon nf;
        private System.Windows.Forms.ToolStripButton tsToHTML;
        private System.Windows.Forms.SaveFileDialog sfdHTML;
        private System.Windows.Forms.ToolStripButton tsFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripLabel tsFind;
        private System.Windows.Forms.ToolStripButton tsRemoveFilter;
        private System.Windows.Forms.DataGridViewImageColumn Ico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn WordType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rank;
        private System.Windows.Forms.ToolStripButton tsSortRank;

    }
}

