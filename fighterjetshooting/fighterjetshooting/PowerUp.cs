using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fighterjetshooting
{
    public class PowerUp
    {
        private string powerType;
        private bool obtainedPowerUp;

        public PowerUp(string type)
        {
            powerType = type;
            obtainedPowerUp = false;
            
        }

        public string PowerType
        {
            get { return powerType; }
            set { powerType = value; }
        }

        public bool ObtainedPowerUp
        {
            get { return obtainedPowerUp; }
            set { obtainedPowerUp = value; }
        }
    }
}
