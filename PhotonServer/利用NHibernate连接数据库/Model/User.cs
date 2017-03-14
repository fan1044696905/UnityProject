using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPhotonServer.Model
{
    class User
    {
        public virtual int Id { get; set; }
        public virtual int Username { get; set; }
        public virtual int Password { get; set; }
        public virtual DateTime Registerdate { get; set; }
    }
}
