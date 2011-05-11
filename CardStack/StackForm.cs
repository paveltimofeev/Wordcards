using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using presenter;

namespace CardStack
{
    public partial class StackForm : Form, ICardStackView
    {
        CardStackPresenter presenter;

        public StackForm()
        {
            InitializeComponent();

            presenter = new CardStackPresenter(this);
            presenter.Next();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                presenter.Flip();
            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
                presenter.Next();
        }

        public void ShowEngSide(string Eng, string EngDesc, string transcription)
        {
            label1.Text = Eng;
            label2.Text = EngDesc;
            label3.Text = transcription;
        }

        public void ShowRusSide(string Rus, string Eng, string RusDesc)
        {
            label1.Text = Rus;
            label2.Text = RusDesc;
        }

        public void ShowAdditionalInfo(int wordType, int Rank)
        {
            label4.Text = string.Format("Rank: {0}", Rank);
        }
    }
}
