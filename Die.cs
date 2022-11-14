namespace Dice
{
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
}