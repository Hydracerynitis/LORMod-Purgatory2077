// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100089
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;
using System.Collections.Generic;

namespace Ark
{
    //破碎之蔓     无法更改战斗书页 体力低于50永久陷入混乱 舞台切换时体力恢复至100 ,每一幕开始获得2颗招架(4-8)骰子
    public class PassiveAbility_100093 : PassiveAbilityBase
    {
        public override void OnWaveStart()
        {
            if (owner.hp <= 100)
                owner.SetHp(100);
        }
        public override void OnRoundStart()
        {
            if (owner.hp <= 50)
            {
                owner.breakDetail.breakGauge = 0;
                owner.breakDetail.breakLife = 0;
                owner.breakDetail.DestroyBreakPoint();
                owner.view.ChangeSkin("CPS2");
            }
        }
        public override void OnStartBattle()
        {
            DiceCardXmlInfo cardItem = ItemXmlDataList.instance.GetCardItem(new LorId("Purgatory2077",236));
            int num = 0;
            List<BattleDiceBehavior> behaviourList = new List<BattleDiceBehavior>();
            foreach (DiceBehaviour diceBehaviour2 in cardItem.DiceBehaviourList)
            {
                BattleDiceBehavior battleDiceBehavior = new BattleDiceBehavior();
                battleDiceBehavior.behaviourInCard = diceBehaviour2.Copy();
                battleDiceBehavior.SetIndex(num++);
                behaviourList.Add(battleDiceBehavior);
            }
            owner.cardSlotDetail.keepCard.AddBehaviours(cardItem, behaviourList);
        }
    }
}
