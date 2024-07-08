using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class HideBackCommand : Command
    {
        private Coroutine _coroutine;
        
        public HideBackCommand(CommandData data) : base(data)
        {
        }

        public override void Execute(UnityAction onCompleted)
        {
            GameData.BlackPanel.gameObject.SetActive(true);
            _coroutine = GameData.CoroutineRunner.StartCoroutine(AwaitHide(onCompleted));
        }
        
        public override void Cancel()
        {
            GameData.CoroutineRunner.StopCoroutine(_coroutine);
            GameData.BlackPanel.color = GameData.BlackPanel.color.SetA(0);
        }
        
        private IEnumerator AwaitHide(UnityAction onCompleted)
        {
            var alpha = GameData.BlackPanel.color.a;
            
            while (Math.Abs(alpha) > 0.01f)
            {
                GameData.BlackPanel.color = GameData.BlackPanel.color.SetA(alpha);
                alpha -= Time.deltaTime * 2;
                yield return null;
            }
            
            GameData.BlackPanel.color = GameData.BlackPanel.color.SetA(0);
            GameData.BlackPanel.gameObject.SetActive(false);
            onCompleted.Invoke();
        }
    }
}