using System.Collections.Generic;

using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;

namespace OlympicGames.Core.Providers
{
    public class OlympicCommittee : IOlympicCommittee
    {
        private static OlympicCommittee instance;

        private OlympicCommittee()
        {
            this.Olympians = new List<IOlympian>();
        }

        public ICollection<IOlympian> Olympians { get; private set; }

        public static OlympicCommittee Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new OlympicCommittee();
                }

                return instance;
            }
        }
    }
}
