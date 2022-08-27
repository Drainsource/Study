

public abstract class Deck
{
    protected List<PlayingCardModel> _fullDeck = new();
    protected List<PlayingCardModel> _drawPile = new();
    protected List<PlayingCardModel> _discardPile = new();
    protected void CreateDeck(int deckSize = 1)
    {
        _fullDeck.Clear();

        for (int i = 0; i < deckSize; i++)
        {
            for (int suit = 0; suit < Enum.GetNames(typeof(CardSuit)).Length; suit++)
            {
                for (int val = 0; val < Enum.GetNames(typeof(CardValue)).Length; val++)
                {
                    _fullDeck.Add(new PlayingCardModel { Suit = (CardSuit)suit, Value = (CardValue)val });
                }
            } 
        }
    }
    public virtual void ShuffleDeck()
    {
        var random = new Random();
        _drawPile = _fullDeck.OrderBy(x => random.Next()).ToList();
    }
    public abstract List<PlayingCardModel> DealCard();
    protected virtual PlayingCardModel DrawOneCard()
    {
        PlayingCardModel output = _drawPile.Take(1).First();
        _drawPile.Remove(output);
        return output;
    }
}
