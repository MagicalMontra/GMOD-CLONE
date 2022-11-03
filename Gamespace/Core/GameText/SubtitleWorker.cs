using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

 public class ShowSubtitleSignal 
 {
      public string talkerName;
      public string message;
      public float time;

    public Action action;
      public ShowSubtitleSignal(string talkerName, string message,float time)
      {
          this.talkerName = talkerName;
          this.message = message;
          this.time = time;
          this.action = null;
      }
         public ShowSubtitleSignal(string talkerName, string message,float time,Action action)
      {
          this.talkerName = talkerName;
          this.message = message;
          this.time = time;
          this.action = action;
      }
 }
public class SubtitleWorker :ITickable
{
   
    [Inject] SubtitleSetting _subtitleSetting;
    private Action _action;

    public void Tick()
    {
        if (_subtitleSetting.timer > 0)
        {
            _subtitleSetting.timer -= Time.deltaTime;
            _subtitleSetting.subtitleGameObject.SetActive(true);
        }
        else
        {
            if(_action!=null)
            {
                _action.Invoke();
                _action= null;
            }
            _subtitleSetting.subtitleGameObject.SetActive(false);
        }
    }
    public void SetSubtitle(ShowSubtitleSignal signal)
    {
        if (_subtitleSetting.timer > 0)
        {
            return;
        }
        //DO STACK
        string textMessage = null;
        _subtitleSetting.timer = signal.time;

        _action = signal.action;
        
        
        if ( signal.talkerName.Length >0)
        {
           
            textMessage = signal.talkerName + ": " + signal.message;
            _subtitleSetting.subtitleUGUI.text = textMessage;
        }
        else
        {
            _subtitleSetting.subtitleUGUI.text = signal.message;
        }

       
        float textCalculte = TextBGCalculate(_subtitleSetting.subtitleUGUI.text.Length);
        RectTransformExtensions.SetLeft(_subtitleSetting.subtitleBackGround, textCalculte);
        RectTransformExtensions.SetRight(_subtitleSetting.subtitleBackGround, textCalculte);
    }

    float TextBGCalculate(float len)
    {
        if (len <= 10)
        {
            return 700;
        }
        else if (len > 10 && len < 20)
        {
            return 500;
        }
        else if(len >= 20 && len <45)
        {
            return 400;
        }
        else if (len >= 45)
        {
            return 300;
        }
        else
        {
            return 120;
        }
    }


}
