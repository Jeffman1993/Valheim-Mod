using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepInv
{
    public abstract class CustomCommand : iCommand
    {
        public abstract void handle(string[] args);
    }
}
