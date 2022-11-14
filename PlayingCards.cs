namespace PlayingCards
{
    /// <summary> Represents which suit a Card belongs to </summary>
    public enum CardSuit 
    { 
        /// <summary> </summary>
        Diamonds = 0,
        /// <summary> </summary>
        Hearts = 1,
        /// <summary> </summary>
        Spades = 2,
        /// <summary> </summary>
        Clubs = 3 
    }

    /// <summary> Represents the number/value of the card </summary>
    public enum FaceValue 
    {
        /// <summary> </summary>
        Ace = 1,
        /// <summary> </summary>
        Deuce = 2,
        /// <summary> </summary>
        Three = 3,
        /// <summary> </summary>
        Four = 4,
        /// <summary> </summary>
        Five = 5,
        /// <summary> </summary>
        Six = 6,
        /// <summary> </summary>
        Seven = 7,
        /// <summary> </summary>
        Eight = 8,
        /// <summary> </summary>
        Nine = 9,
        /// <summary> </summary>
        Ten = 10,
        /// <summary> </summary>
        Jack = 11,
        /// <summary> </summary>
        Queen = 12,
        /// <summary> </summary>
        King = 13 
    }

    /// <summary> A Card has a suit and a value. </summary>
    public class Card
    {
        /// <summary> Which suit this card belongs to </summary>
        public CardSuit Suit { get; private set; }

        /// <summary> Value for this card </summary>
        public FaceValue Value { get; private set; }

        /// <summary> Constructor taking CardSuit and FaceValue arguments </summary>
        /// <param name="suit">Suit to set</param>
        /// <param name="value">Value to set</param>
        public Card(CardSuit suit, FaceValue value)
        {
            Suit = suit;
            Value = value;
        }

        /// <summary> Empty Constructor. Does not set the card. </summary>
        public Card() { }

        /// <summary> Contructor taking a card argument. </summary>
        /// <param name="copy">Card of copy</param>
        public Card(Card copy)
        {
            Suit = copy.Suit;
            Value = copy.Value;
        }

        /// <summary> ToString(): string representation of card </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return $"{Enum.GetName(Value)} of {Enum.GetName(Suit)}";
        }
    }

    /// <summary> A hand is a collection of cards for a player </summary>
    public class Hand
    {
        /// <summary>The cards which belong to this hand.</summary>
        public List<Card> Cards { get; private set; }

        /// <summary>Constructor taking a ListCards as an argument</summary>
        /// <param name="cards">A List of Cards for this Hand</param>
        public Hand(List<Card> cards) => Cards = cards;

        /// <summary> Empty Constructor</summary>
        public Hand() => Cards = new List<Card>();

        /// <summary> Adds the specified Card to this Hand</summary>
        /// <param name="card">Card to add</param>
        public void AddCard(Card card)
        {
            Cards.Add(card);
        }

        /// <summary>Tries to remove the specified card.</summary>
        /// <param name="card">The card to remove</param>
        /// <param name="match">out parameter card if match is found, unchanged if fails.</param>
        /// <returns>bool</returns>
        public bool RemoveCard(Card card, out Card match)
        {
            bool success = false;
            Card copy = new Card();
            foreach (Card cd in Cards)
            {
                if(cd.Value == card.Value && cd.Suit == card.Suit)
                {
                    copy = cd;
                    success = true;
                    break;
                }
            }
            match = copy;
            return success;
        }

        /// <summary> ToString(): string representation of Hand</summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            string str = "";
            foreach (Card card in Cards)
            {
                str += card.ToString() + "\n";
            }
            return $"Player Hand has {Cards.Count} Cards\n{str}\n";
        }
    }

    /// <summary> A Deck contains 1 of each card. Should be 52 excluding jokers. </summary>
    public class Deck
    {
        /// <summary>The cards which belong to this deck.</summary>
        public List<Card> Cards { get; private set; }

        /// <summary> Empty Constructor </summary>
        public Deck() 
        {
            Cards = new List<Card>();
        }

        private void FillDeck()
        {
            foreach (var su in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (var va in Enum.GetValues(typeof(FaceValue)))
                {
                    AddCard(new Card((CardSuit)su, (FaceValue)va));
                }
            }
        }

        /// <summary>Fills the deck with 52 standard playing cards, un-shuffled </summary>
        public void Initialize()
        {
            Cards = new List<Card>();
            FillDeck();
        }

        /// <summary> Adds a card to this deck </summary>
        /// <param name="card">Card to add to this deck</param>
        public void AddCard(Card card)
        {
            Cards.Add(card);            
        }

        /// <summary> Removes a card from the top of the deck. Return the card. </summary>
        /// <returns>Card</returns>
        public Card RemoveCard()
        {
            Card card;
            card = Cards.ElementAt(Cards.Count - 1);
            Cards.RemoveAt(Cards.Count - 1);
            return card;
        }

        /// <summary> Randomly re orders the cards in this deck. </summary>
        public void ShuffleDeck()
        {
            for(int i = 0; i < Cards.Count; i++)
            {
                Card card = Cards[i];
                Cards.Remove(Cards[i]);
                System.Random rand = new System.Random();
                int index = rand.Next(0, Cards.Count);
                Cards.Insert(index, card);
            }
        }

        /// <summary> Randomly re orders the cards in this deck the number of times specified </summary>
        /// <param name="n">Number of times to reshuffle the deck</param>
        public void ShuffleDeck(int n)
        {
            for (int i = n-1; i >= 0; i--) 
            {
                ShuffleDeck();
            }
        }

        /// <summary> ToString(): string representation of Hand </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            string str = "";
            foreach (Card card in Cards)
            {
                str += card.ToString() + "\n";
            }
            return $"{Cards.Count} Cards in Deck\n{str}\n";
        }
    }
}