using IntergalacticTravel.Contracts;
using System.Collections.Generic;

namespace IntergalacticTravel
{
    public class ExtendedTeleportStation : TeleportStation
    {
        public ExtendedTeleportStation(IBusinessOwner owner, IEnumerable<IPath> galacticMap, ILocation location)
           : base(owner, galacticMap, location)
        {
        }

        public IBusinessOwner Owner
        {
            get
            {
                return this.owner;
            }
        }

        public ILocation Location
        {
            get
            {
                return this.location;
            }
        }

        public IEnumerable<IPath> GalacticMap
        {
            get
            {
                return this.galacticMap;
            }
        }

        public IResources Resources
        {
            get
            {
                return this.resources;
            }
        }
    }
}
