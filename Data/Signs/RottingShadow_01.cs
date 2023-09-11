using LDC.EnoaLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDC.EnoaLibrary.Classes.Signs
{
    public class RottingShadow_01 : Sign
    {
        public RottingShadow_01()
        {
            Name = "1. Гниющая тень";
            Description = "Увидеть, как грызуны и паразиты пустыни шкрябают чью-то тень, — знак беды и скорой смерти.";
            Effect = "Каждый искатель в вашей группе получает автоматический провал одного спасброска от смерти до следующего знамения.";
            Success = "Ваша группа не получает эффект, а также, когда искатель становится стабилизированным, он восстанавливает 1 хит.";
            Failure = "Каждый искатель в группе получает еще один провал спасброска от смерти до следующего знамения. ";
            Difficult = 16;
            Bunti = 4;
            Ayur = 0;
            Dodor = 0;
            Takhar = 0;
         }
    }
}
