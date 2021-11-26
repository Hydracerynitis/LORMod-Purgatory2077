// Decompiled with JetBrains decompiler
// Type: Ark.BattleUnitBuf_breakNearCard
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using HarmonyLib;
using System;
using System.Reflection;

namespace Ark
{
    public class BattleUnitBuf_breakNearCard : BattleUnitBuf
    {
        public BattleUnitBuf_breakNearCard(BattleUnitModel model)
        {
            typeof (BattleUnitBuf).GetField("_bufIcon", AccessTools.all).SetValue(this, BaseMod.Harmony_Patch.ArtWorks["limitNear"]);
            typeof (BattleUnitBuf).GetField("_iconInit", AccessTools.all).SetValue(this, true);
            _owner = model;
            stack = 0;
        }
        public override void OnRoundEnd() => Destroy();
        protected override string keywordId => "limitNear";
    }
}
