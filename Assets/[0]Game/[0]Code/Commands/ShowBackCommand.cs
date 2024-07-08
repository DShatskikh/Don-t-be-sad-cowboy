using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class ShowBackCommand : Command
    {
        private const float TargetAlpha = 0.8f;

        private Coroutine _coroutine;
        
        public ShowBackCommand(CommandData data) : base(data)
        {
        }

        public override void Execute(UnityAction onCompleted)
        {
            _coroutine = GameData.CoroutineRunner.StartCoroutine(AwaitShow(onCompleted));
            GameData.BlackPanel.gameObject.SetActive(true);
            GameData.BlackPanel.color = GameData.BlackPanel.color.SetA(TargetAlpha);
        }

        public override void Cancel()
        {
            GameData.CoroutineRunner.StopCoroutine(_coroutine);
        }
        
        private IEnumerator AwaitShow(UnityAction onCompleted)
        {
            var alpha = 0f;
            
            while (alpha != TargetAlpha)
            {
                GameData.BlackPanel.color = GameData.BlackPanel.color.SetA(alpha);
                alpha = Mathf.Clamp(alpha + Time.deltaTime * 2, 0, TargetAlpha);
                yield return null;
            }
            
            GameData.BlackPanel.color = GameData.BlackPanel.color.SetA(TargetAlpha);
            onCompleted.Invoke();
        }
    }
}