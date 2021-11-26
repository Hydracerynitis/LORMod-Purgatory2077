// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100110
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //狂暴    体力低于50%时所有骰子威力+2且每一幕开始自身都将获得1层“束缚”    
    public class PassiveAbility_100110 : PassiveAbilityBase
    {
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (owner.hp > owner.MaxHp / 2)
                return;
            behavior.ApplyDiceStatBonus(new DiceStatBonus(){ power = 2 });
        }
        public override void OnRoundStart()
        {
            if (owner.hp > owner.MaxHp / 2)
                return;
            owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Binding, 1);
        }
    }
}
