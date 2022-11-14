using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaming
{
    /// <summary> Running Session for the game. Static with while loop to enforce a dirty singleton </summary>
    public static class Session
    {
        /// <summary> Creates a runtime instance </summary>
        /// <param name="session">GameSession instance</param>
        public static void RunGameSession(GameSession session)
        {
            Console.WriteLine("Session Started");
            session.SessionState = GameSessionState.Initialize;
            bool isExiting = false;
            while (!isExiting)
            {
                var state = session.SessionState;
                switch (state)
                { 
                    case GameSessionState.NONE:
                    case GameSessionState.Error:
                    case GameSessionState.Quit:
                    default:
                        isExiting = true;
                        break;
                    case GameSessionState.Initialize:
                        session.Initialize();
                        session.SessionState = GameSessionState.Playing;
                        break;
                    case GameSessionState.Playing:
                        session.GameLoop();
                        break;
                    case GameSessionState.End:
                        session.EndGame();
                        break;
                }
            }
        }
    }
}
