// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;
using HarmonyLib;

namespace Ark
{
    //[使用时]若本书页为本幕第二张使用的书页则使书页中所有骰子重复投掷1次
    public class DiceCardSelfAbility_GreyThroat1 : DiceCardSelfAbilityBase 
    {
        public static string Desc = "[使用时]若本书页为本幕第二张使用的书页则使书页中所有骰子重复投掷1次";
        public override void OnUseCard()
        {
            if(owner.cardHistory.GetCurrentRoundCardList(Singleton<StageController>.Instance.RoundTurn).Count==2)
                foreach (BattleDiceBehavior dice in card.GetDiceBehaviorList())
                {
                    dice.abilityList.Add(new Repeat() { behavior = dice });
                }
        }
        public class Repeat : DiceCardAbilityBase
        {
            private bool HasRepeat=false;
            public override void AfterAction()
            {
                if (owner.IsBreakLifeZero() || HasRepeat)
                    return;
                HasRepeat=true;
                ActivateBonusAttackDice();
            }
        }
    }
}
