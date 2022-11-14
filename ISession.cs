using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaming
{
    /// <summary> Interface Session </summary>
    interface ISession
    {
        /// <summary> The name of the Game </summary>
        public string GameName { get; set; }

        /// <summary> Current Session State </summary>
        public GameSessionState SessionState { get; set; }
        void Initialize();
        void GameLoop();
        void EndGame();

    }
}
