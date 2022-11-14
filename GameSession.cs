using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaming
{
    /// <summary>
    /// Game Session, or manager. This will need to be inherited.
    /// 
    /// Keep track of number of players, number of decks, and the game rules
    /// This class here acts as a framework to create other game modes.
    /// </summary>
    public abstract class GameSession : ISession
    {
        public int PlayerCount { get; set; }
        public string GameName { get; set; }
        public GameSessionState SessionState { get; set; }

        public abstract void Initialize();

        public abstract void GameLoop();

        public abstract void EndGame();
    }
}
