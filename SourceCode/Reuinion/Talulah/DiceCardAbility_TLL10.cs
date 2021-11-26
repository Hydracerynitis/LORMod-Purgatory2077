// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System;

namespace Ark
{
    //[拼点失败] 使自身失去2层[烧伤]
    public class DiceCardAbility_TLL10 :DiceCardAbilityBase 
    {
        public static string Desc = "[拼点失败] 使自身失去2层[烧伤]";
        public override void OnLoseParrying()
        {
            BattleUnitBuf burn = owner.bufListDetail.GetActivatedBuf(KeywordBuf.Burn);
            if (burn == null)
                return;
            burn.stack = Math.Max(burn.stack - 2, 0);
        }
    }
}
