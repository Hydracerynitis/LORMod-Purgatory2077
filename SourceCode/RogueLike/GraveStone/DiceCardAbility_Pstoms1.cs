// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;
using HarmonyLib;
using LOR_DiceSystem;

namespace Ark
{
    //[命中时]下一幕中对其施加1层[墓标]
    public class DiceCardAbility_Pstoms1 : DiceCardAbilityBase 
    {
        public static string Desc = "[命中时]下一幕中对其施加1层[墓标]";
        public override void OnSucceedAttack()
        {
            BattleUnitBuf_tomsEX.AddBuff(card.target, 1, owner, true);
        }
    }
}
