using LDC.EnoaLibrary.Classes.Signs;
using LDC.EnoaLibrary.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDC.EnoaLibrary.Classes
{
    /// <summary>
    /// Базовый класс для инициализации базы знамений
    /// </summary>
    public class SignContextInitializer
    {
        private List<Sign> signs;

        public SignContextInitializer()
        {
            signs = new List<Sign>();
        }

        private void Update(SignContext signContext, List<Sign> signs)
        {
            var t = signContext.Database.GetConnectionString();
            var r = signContext.Database.ExecuteSqlRaw("DELETE FROM Signs");
            for (int i = 0; i < signs.Count; i++)
            {
                Sign sign = signs[i];
                signContext.Signs.Add(sign);
            }
            signContext.SaveChanges();
        }

        /// <summary>
        /// Доступный для переопледения метод, инициализирующий список знамений
        /// 
        /// При переопределении метода необходимо после объявления списка знамений
        /// вызвать конструкцию
        /// using (signContext) { Update(signContext, signs); }
        /// </summary>
        internal virtual void Initialize(SignContext signContext)
        {
            signs.Add(new RottingShadow_01());

            using (signContext)
            {
                Update(signContext, signs);
            }
        }
    }
}
