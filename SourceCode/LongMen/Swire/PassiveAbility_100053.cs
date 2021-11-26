// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100053
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //高贵风范      使用费用不低于6的书页时恢复4点光芒
    public class PassiveAbility_100053 : PassiveAbilityBase
    {
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        { 
            if (curCard.card.GetOriginCost() < 6)
                return;
            owner.cardSlotDetail.RecoverPlayPoint(4);
        }
    }
}
