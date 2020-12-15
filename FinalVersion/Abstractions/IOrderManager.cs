using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalVersion.Entities;

namespace FinalVersion.Abstractions
{
    public interface IOrderManager
    {
        List<Adat> Adats { get; }
        
        Adat CreateAdat(Adat adat);
    }
}
