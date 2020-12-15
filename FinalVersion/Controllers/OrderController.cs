using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FinalVersion.Abstractions;
using FinalVersion.Entities;
using FinalVersion.Services;

namespace FinalVersion.Controllers
{
    public class OrderController
    {
        public IOrderManager OrderManager { get; set; }

        public OrderController()
        {
            OrderManager = new OrderManager();
        }

        public Adat Register(string telepules, string hotelnev, string sorszam, int ejszaka, int forint)
        {
            if (!ValidateTelepules(telepules))
                throw new ValidationException(
                    "A megadott e-mail cím nem megfelelő!");
            if (!ValidateHotelnev(hotelnev))
                throw new ValidationException(
                    "A megadottt jelszó nem megfelelő!" +
                    "A jelszó legalább 8 karakter hosszú kell legyen, csak az angol ABC betűiből és számokból állhat, és tartalmaznia kell legalább egy kisbetűt, egy nagybetűt és egy számot.");

            var account = new Adat()
            {
                Telepules = telepules,
                Hotelnev = hotelnev,
                Sorszam =sorszam,
                Ejszaka = ejszaka,
                Forint = forint
            };

            var newAccount = OrderManager.CreateAdat(account);

            return newAccount;
        }

        public bool ValidateTelepules(string email)
        {
            return Regex.IsMatch(
                email,
                @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
        }

        public bool ValidateHotelnev(string password)
        {
            return Regex.IsMatch(
                password,
                @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$");
        }
    }
}
