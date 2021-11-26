// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100081
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //高热充能      每一幕开始时将自身的“烧伤”层数转换为对应层数的“充能”
    public class PassiveAbility_100081 : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            BattleUnitBuf activatedBuf = owner.bufListDetail.GetActivatedBuf(KeywordBuf.Burn);
            if (activatedBuf.stack <= 0)
                return;
            owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.WarpCharge, activatedBuf.stack);
            activatedBuf.stack = 0;
        }
    }
}
