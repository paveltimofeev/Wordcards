using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace presenter
{
    public interface ICardListView
    {
        IList Datasource { get; set; }
        string FilterValue { get; }

        void Refresh();
        void SetStatus(string message);
        void ShowBaloon(string title, string text, string tooltip);
    }
}
