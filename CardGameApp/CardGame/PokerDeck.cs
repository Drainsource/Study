using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class PokerDeck : Deck
    {
        public PokerDeck()
        {
            CreateDeck();
            ShuffleDeck();
        }
        public override List<PlayingCardModel> DealCard()
        {
            List<PlayingCardModel> output = new List<PlayingCardModel>();

            for (int i = 0; i < 5; i++)
            {
                output.Add(DrawOneCard());
            }

            return output;
        }
        public List<PlayingCardModel> RequestCards(List<PlayingCardModel> cardsToDisCard)
        {
            List<PlayingCardModel> output = new();

            foreach (var card in cardsToDisCard)
            {
                output.Add(DrawOneCard());
                _discardPile.Add(card);
            }

            return output;
        }
    }
}
