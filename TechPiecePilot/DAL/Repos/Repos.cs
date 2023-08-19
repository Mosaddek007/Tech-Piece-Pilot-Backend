using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class Repos
    {
        internal TCPPContext db;
        internal Repos()
        {
            db = new TCPPContext();
        }
    }
}
