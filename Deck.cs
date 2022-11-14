namespace PlayingCards
{
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