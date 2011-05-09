using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace presenter
{
    public interface ICardInvokeableStackView : ICardStackView
    {
        System.Windows.Threading.Dispatcher Dispatcher { get; }
    }
}
