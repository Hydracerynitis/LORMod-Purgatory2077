// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100109
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //活性粉尘      每一幕开始对所有敌方单位造成自身“束缚”层数的伤害，自身的“束缚”层数不会自动减少
    public class PassiveAbility_100109 : PassiveAbilityBase
    {
        private int bindStack;
        public override void OnRoundEnd()
        {
            bindStack = 0;
            foreach (BattleUnitBuf activatedBuf in owner.bufListDetail.GetActivatedBufList())
            {
                if (activatedBuf.bufType == KeywordBuf.Binding)
                {
                    int stack = activatedBuf.stack;
                    bindStack = stack;
                }
            }
        }
        public override void OnRoundStart()
        {
            if (bindStack <= 0)
                return;
            owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Binding, bindStack);
            foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveList_opponent(owner.faction))
                battleUnitModel.TakeDamage(bindStack, DamageType.Passive);
        }
    }
}
