namespace Gaming
{
    /// <summary>
    /// Game Session State
    /// </summary>
    public enum GameSessionState
    {
        /// <summary> Default </summary>
        NONE,
        /// <summary> Configures Game Start </summary>
        Initialize,
        /// <summary> Main Loop </summary>
        Playing,
        /// <summary> Finished Game state </summary>
        End,
        /// <summary> Quitting the game</summary>
        Quit,
        /// <summary> Error state </summary>
        Error
    }
}
