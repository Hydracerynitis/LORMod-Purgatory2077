﻿// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100089
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll
using System.Collections.Generic;
using LOR_DiceSystem;

namespace Ark
{
    //鲍勃之力    速度骰子数量锁定为1 且自身所有进攻型骰子受到的威力增减效果x1.5 防御骰子无法受"忍耐"加成
    public class PassiveAbility_100180 : PassiveAbilityBase
    {
        public int GetSpeedDiceNumLast() => 1;
        public override bool IsImmune(KeywordBuf buf)
        {
            return buf==KeywordBuf.Endurance;
        }
    }
}
