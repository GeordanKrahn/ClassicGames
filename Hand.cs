namespace PlayingCards
{
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
}