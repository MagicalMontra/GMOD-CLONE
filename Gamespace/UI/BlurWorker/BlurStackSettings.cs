using System;
using System.Collections.Generic;
using LeTai.Asset.TranslucentImage;

namespace Gamespace.UI
{
    [Serializable]
    public class BlurStackSettings
    {
        public List<ScalableBlurConfig> blurConfigs = new List<ScalableBlurConfig>();
    }
}