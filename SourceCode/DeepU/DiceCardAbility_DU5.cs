// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardAbility_DU5
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //本骰子受到自身[守护]层数的威力增加
    public class DiceCardAbility_DU5 : DiceCardAbilityBase
    {
        public override void BeforeRollDice()
        {   
            int kewordBufStack = owner.bufListDetail.GetKewordBufStack(KeywordBuf.Protection);
            if (kewordBufStack <= 0)
                return;
            behavior.ApplyDiceStatBonus(new DiceStatBonus(){ power = kewordBufStack });
        }
    }
}
