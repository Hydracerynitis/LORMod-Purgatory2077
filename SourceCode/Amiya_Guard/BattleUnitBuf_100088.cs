// Decompiled with JetBrains decompiler
// Type: Ark.BattleUnitBuf_100088
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System;

namespace Ark
{
    public class BattleUnitBuf_100088 : BattleUnitBuf
    {
        public BattleUnitBuf_100088(BattleUnitModel model)
        {
            _owner = model;
            stack = 0;
        }
        public override void OnRoundEnd() => Destroy();
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            foreach (BattleUnitModel alive in BattleObjectManager.instance.GetAliveList(_owner.faction))
            {
                if (alive.passiveDetail.HasPassive<PassiveAbility_100088>())
                {
                    if (alive.bufListDetail.GetKewordBufStack(KeywordBuf.Strength) >= 3)
                        behavior.ApplyDiceStatBonus(new DiceStatBonus(){ power = -2 });
                    return;
                }
            }
        }
    }
}
