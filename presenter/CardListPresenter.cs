using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using model;
using System.IO;
using System.Xml.Serialization;

namespace presenter
{
    public class CardListPresenter : CardPresenter
    {
        Card random = null;
        ICardListView view;

        public CardListPresenter(ICardListView view)
        {
            this.view = view;
        }
        
        protected override void  RefreshView()
        {
            view.Datasource = model.Cards;
            view.Refresh();
        }

        public void SaveXML(string path)
        {
            model.SaveXML(path);

            view.SetStatus("Saved");
        }

        public void LoadXML(string path)
        {
            model.LoadXML(path);

            view.SetStatus("Loaded");
            RefreshView();
        }

        public void SaveFB2(string path)
        {
            model.SaveFB2(path);
        }

        public void SaveHTM(string path)
        {
            model.SaveHTM(path);
        }

        public void Sort()
        {
            model.Sort();
            RefreshView();
        }

        public void Filter()
        {
            if (!string.IsNullOrWhiteSpace(view.FilterValue))
            {
                view.Datasource = model.Filter(view.FilterValue);
                view.Refresh();

                view.SetStatus(string.Format("Filtered with \"{0}\"", view.FilterValue));
            }
            else
            {
                RefreshView();
                view.SetStatus("");
            }
        }

        public void GetNewRandom()
        {
            random = model.GetRandom();

            view.ShowBaloon(random.Eng, string.Format("{0}\r\n{1}", random.Transcription, random.EngDesc), random.Rus);
        }

        public void TranslateRandom()
        {
            if (random != null)
            {
                random.Rank++;
                view.ShowBaloon(random.Rus, random.RusDesc, random.EngDesc);
            }
        }

        public void SortRank()
        {
            model.SortRank();
            RefreshView();
        }

        public void SaveDatabase()
        {
            model.SaveDatabase();
        }
    }
}
