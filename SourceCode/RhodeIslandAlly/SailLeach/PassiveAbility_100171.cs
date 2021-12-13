// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100069
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //精神感召  自身使用3费书页时随机使一名友方单位恢复1点光芒
    public class PassiveAbility_100171 : PassiveAbilityBase
    {
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            if (curCard.card.GetCost() == 3)
            {
                foreach (BattleUnitModel unit in BattleObjectManager.instance.GetAliveList_random(owner.faction, 1))
                    unit.cardSlotDetail.RecoverPlayPoint(1);
            }
        }
    }
}
