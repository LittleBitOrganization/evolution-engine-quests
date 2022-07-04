using System;
using LittleBit.Modules.CoreModule;
using LittleBitGames.QuestsModule.Quests.Metadata;
using UnityEngine;

namespace LittleBitGames.QuestsModule.Quests.Memento
{
    [Serializable]
    public class QuestModelMemento : Data
    {
        [SerializeField]
        private string stringState;

        public QuestModelMemento() {}

        public QuestState State => (QuestState) Enum.Parse(typeof(QuestState), stringState);

        public QuestModelMemento(QuestState state)
            => SetState(state);

        public void SetState(QuestState state) 
            => stringState = state.ToString();

    }
}