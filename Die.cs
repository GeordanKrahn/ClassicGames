namespace Dice
{
    /// <summary>Represents the number of faces for a die</summary>
    public enum DieType
    {
        /// <summary> Four Sided Die </summary>
        D4 = 4,
        /// <summary> Six Sided Die </summary>
        D6 = 6,
        /// <summary> Eight Sided Die </summary>
        D8 = 8,
        /// <summary> Ten Sided Die </summary>
        D10 = 10,
        /// <summary> Twelve Sided Die </summary>
        D12 = 12,
        /// <summary> Sixteen Sided Die </summary>
        D16 = 16,
        /// <summary> Twenty Sided Die </summary>
        D20 = 20
    }

    /// <summary>3D Geometrical object whose faces count from 1 - nSides</summary>
    public class Die
    {
        private System.Random rand;

        /// <summary>
        /// roll reassigns the face value
        /// </summary>
        public void Roll() => FaceValue = rand.Next(1, Sides + 1);

        /// <summary>
        /// Number of sides this die has
        /// </summary>
        public int Sides { get; private set; }

        /// <summary>
        /// The current face, or top, value of the die
        /// </summary>
        public int FaceValue { get; private set; }

        /// <summary>
        /// Empty Constructor, set to D6
        /// </summary>
        public Die() : this(DieType.D6) { }

        /// <summary>
        /// Constructor taking DieType argument
        /// </summary>
        /// <param name="type">DieType, indicates number of faces</param>
        public Die(DieType type)
        {
            rand = new Random();
            switch(type)
            {
                case DieType.D4:
                case DieType.D6:
                case DieType.D8:
                case DieType.D10:
                case DieType.D12:
                case DieType.D16:
                case DieType.D20:
                    Sides = (int)type;
                    break;
                default:
                    Sides = 6;
                break;
            }
            Roll();
        }

        /// <summary>
        /// ToString(): string representation of this object
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return $"D{Sides}-Value: {FaceValue}";
        }
    }

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