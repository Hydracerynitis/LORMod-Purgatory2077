// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100069
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //每一幕开始使自身所有的debuff层数-1
    public class PassiveAbility_BlazePix2 : PassiveAbilityBase
    {
        public override void OnRoundStartAfter()
        {
            owner.bufListDetail.GetActivatedBufList().FindAll(x => x.positiveType == BufPositiveType.Negative).ForEach(x => ReduceStack(x));
        }
        private void ReduceStack(BattleUnitBuf buf)
        {
            if (buf.stack <= 1)
                buf.Destroy();
            else
                buf.stack -= 1;
        }
    }
}
