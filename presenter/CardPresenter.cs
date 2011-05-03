using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace presenter
{
    public class CardPresenter
    {
        protected CardFacade model;

        public CardPresenter()
        {
            model = new CardFacade();
        }

        protected virtual void RefreshView()
        {
            ;
        }

        public void AddCard(string eng, string engDesc, string transcription, string rus, string rusDesc)
        {
            model.AddCard(eng, engDesc, transcription, rus, rusDesc);
            RefreshView();
        }

        public void RemoveCard(string eng, string engDesc, string transcription, string rus, string rusDesc)
        {
            model.RemoveCard(eng, engDesc, transcription, rus, rusDesc);
            RefreshView();
        }

        public void Clear()
        {
            model.Clear();
            RefreshView();
        }

    }
}
