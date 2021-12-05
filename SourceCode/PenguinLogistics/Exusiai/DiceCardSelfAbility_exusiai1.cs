// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardAbility_exusiai1
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using UI;
using UnityEngine;

namespace Ark
{
    //当本书页骰子基础值骰出4时抽取1张书页并恢复1点光芒
    public class DiceCardSelfAbility_exusiai1 : DiceCardSelfAbilityBase
    {
        public static string Desc = "当本书页骰子基础值骰出4时抽取1张书页并恢复1点光芒";
        public override void OnUseCard()
        {
            foreach (BattleDiceBehavior dice in card.GetDiceBehaviorList())
            {
                dice.abilityList.Add(new Lucky() { behavior = dice });
            }
        }
        public class Lucky: DiceCardAbilityBase
        {
            public override void OnRollDice()
            {
                if (behavior.DiceVanillaValue != 4)
                    return;
                Debug.Log("骰出4了，应当抽卡和回光了");
                owner.battleCardResultLog.SetSucceedAtkEvent(() => UISoundManager.instance.PlayEffectSound(UISoundType.Dice_Click));
                owner.allyCardDetail.DrawCards(1);
                owner.cardSlotDetail.RecoverPlayPointByCard(1);
            }
        }

    }
}
