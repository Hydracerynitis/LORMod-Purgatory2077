// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100069
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll
using LOR_DiceSystem;
namespace Ark
{
    //草原牧歌  若有一名友方单位拼点胜利则使其额外获得1点正面情感硬币(每幕至多触发3次)
    public class PassiveAbility_100175 : PassiveAbilityBase
    {
        public int TriggerCount = 3;
        public override void OnRoundStart()
        {
            TriggerCount = 3;
        }
        public void OnAllyWinParry(BattleUnitModel ally)
        {
            if (TriggerCount > 0)
            {
                TriggerCount--;
                ally.emotionDetail.CreateEmotionCoin(EmotionCoinType.Positive, 1);
            }
        }
    }
}
