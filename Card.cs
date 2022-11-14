namespace PlayingCards
{
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
}