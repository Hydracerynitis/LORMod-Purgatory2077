// Decompiled with JetBrains decompiler
// Type: Purgatory.PassiveAbility_HDK4
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //源石恶化      每一幕开始减少自身当前体力的10%以抽取1张书页并恢复1点光芒且可以使用专属书页[锈锤之战](不可转移)
    public class PassiveAbility_HDK4 : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            owner.LoseHp((int)owner.hp / 10);
            owner.allyCardDetail.DrawCards(1);
            owner.cardSlotDetail.RecoverPlayPointByCard(1);
        }
    }
}
