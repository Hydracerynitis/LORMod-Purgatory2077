// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;
using HarmonyLib;

namespace Ark
{
    //[使用时]若本书页为本幕最后使用的书页则使书页中所有骰子重复投掷2次
    public class DiceCardSelfAbility_GreyThroat2 : DiceCardSelfAbilityBase 
    {
        public static string Desc = "[使用时]若本书页为本幕最后使用的书页则使书页中所有骰子重复投掷2次";
        public override void OnUseCard()
        {
            if (!Singleton<StageController>.Instance.GetAllCards().Exists(x => x.owner == owner && x != card))
                foreach (BattleDiceBehavior dice in card.GetDiceBehaviorList())
                {
                    dice.abilityList.Add(new Repeat2() { behavior = dice });
                }
        }
        public class Repeat2 : DiceCardAbilityBase
        {
            private int _repeatCount;
            public override void AfterAction()
            {
                if (owner.IsBreakLifeZero() || _repeatCount > 1)
                    return;
                ++_repeatCount;
                ActivateBonusAttackDice();
            }
        }
        public class Trigger: BattleUnitBuf
        {
            public override void OnRoundEnd()
            {
                Destroy();
            }
        }
    }
}
