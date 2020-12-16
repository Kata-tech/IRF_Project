using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalVersion.Entities;

namespace FinalVersion.Abstractions
{
    public interface IOrderManager
    {
        BindingList<Adat> Adats { get; }
        Adat CreateAdat(Adat adat);
    }
}
