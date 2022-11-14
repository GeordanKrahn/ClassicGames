namespace Dice
{
    /// <summary>
    /// Represents a dice hand for a player
    /// </summary>
    public class DiceHand
    {

        /// <summary>
        /// The dice the player possesses
        /// </summary>
        public List<Die> Dice;

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public DiceHand() => Dice = new List<Die>();

        /// <summary>
        /// Constructor taking a list of dice
        /// </summary>
        /// <param name="dice">ListofDice for the hand</param>
        public DiceHand(List<Die> dice)
        {
            Dice = new List<Die>();
            Dice = dice;
        }

        /// <summary>
        /// Randomly reassigns the FaceValue of the Die.
        /// </summary>
        public void Roll()
        { 
            foreach(Die die in Dice)
            {
                die.Roll();
            }
        }

        /// <summary>
        /// ToString(): string representation of this object
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            string str = "";
            foreach(Die die in Dice) { str += die.ToString() + "\n"; }
            return $"DiceHand: \n{str}";
        }
    }
}