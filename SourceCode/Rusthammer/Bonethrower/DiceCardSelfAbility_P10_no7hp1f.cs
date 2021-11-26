// Decompiled with JetBrains decompiler
// Type: Purgatory.DiceCardSelfAbility_P10_no7hp1f
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[使用时]自身减少7点体力，并获得1层[流血]
    public class DiceCardSelfAbility_P10_no7hp1f : DiceCardSelfAbilityBase
    {
        public override void OnUseCard()
        {
            owner.TakeDamage(7, DamageType.Card_Ability, owner);
            owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Bleeding, 1, owner);
        }
    }
}
