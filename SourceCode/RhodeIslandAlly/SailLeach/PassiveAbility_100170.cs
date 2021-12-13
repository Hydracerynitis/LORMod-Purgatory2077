// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100069
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //不退之旗  每使用一张3费书页则在下一幕中使随机两名友方单位获得1层“迅捷”与“振奋”
    public class PassiveAbility_100170 : PassiveAbilityBase
    {
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            if (curCard.card.GetCost() == 3)
            {
                foreach(BattleUnitModel unit in BattleObjectManager.instance.GetAliveList_random(owner.faction, 2))
                {
                    unit.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Quickness, 1);
                    unit.bufListDetail.AddKeywordBufByEtc(KeywordBuf.BreakProtection, 1);
                }
            }
        }
    }
}
