// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100076
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //莱茵护服      使用书页消耗“充能”时返还1层”充能“(仅给予自己)
    public class PassiveAbility_100076 : PassiveAbilityBase
    {
        public override void OnUseChargeStack()
        {
            owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.WarpCharge, 1);
            owner.battleCardResultLog?.SetPassiveAbility(this);
        }
    }
}
