using LDC.EnoaLibrary.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDC.EnoaLibrary.Data
{
    /// <summary>
    /// Знамение
    /// </summary>
    public class Sign
    {
        /// <summary>
        /// Первичный ключ знамения
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Наименование знамения
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Описание знамения
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Эффект
        /// </summary>
        public string? Effect { get; set; }
        /// <summary>
        /// Успех
        /// </summary>
        public string? Success { get; set; }
        /// <summary>
        /// Провал
        /// </summary>
        public string? Failure { get; set; }
        /// <summary>
        /// Сложность
        /// </summary>
        public byte Difficult { get; set; }

        // Звери кочевников
        public byte Bunti { get; set; }
        public byte Ayur { get; set; }
        public byte Dodor { get; set; }
        public byte Takhar { get; set; }
    }
}
