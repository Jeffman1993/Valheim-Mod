using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepInv
{
    public interface iCommand
    {
        void handle(string[] args);

    }
}
