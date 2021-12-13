// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100089
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll
using System.Collections.Generic;
using LOR_DiceSystem;

namespace Ark
{
    //源石活化    命中目标时有5%在下一幕中对目标施加1层“腐蚀”
    public class PassiveAbility_100179 : PassiveAbilityBase
    {
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            if (RandomUtil.valueForProb <= 0.05)
                behavior.card.target.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Decay, 1);
        }
    }
}
