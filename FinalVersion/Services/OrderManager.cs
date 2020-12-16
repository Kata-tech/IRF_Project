using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalVersion.Abstractions;
using FinalVersion.Entities;

namespace FinalVersion.Services
{
    public class OrderManager : IOrderManager
    {
        public List<Adat> Adats { get; } = new List<Adat>();

        public Adat CreateAdat(Adat adat)
        {
            var regiadat = (from a in Adats
                              where a.Sorszam.Equals(adat.Sorszam)
                              select a).FirstOrDefault();

            if (regiadat != null)
                throw new ApplicationException(
                    "Már létezik rendelés ilyen sorszámmal!");

            Adats.Add(adat);

            return adat;
        }
    }
}
