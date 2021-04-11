using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace FreecellLib
{
    public interface ICard
    {
        string DisplayName { get; }
        string ShortName { get; }
        int ID { get; }
        CardSuit Suit { get; }
        CardValue Value { get; }

        Color TextColor { get; }
        Color BackgroundColor { get; }

        bool Selected { get; set; }
    }
}
