using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppViewer.Entities.Enums
{
    public enum Transition
    {
        SlideFromLeft = 1,
        SlideFromRight = 2,
        SlideFromTop = 3,
        SlideFromBottom = 4,
        Appear = 5,
        FadeIn = 6,
        PushFromLeft = 7,
        PushFromRight = 8,
        PushSegueRight = 9,
        PushSegueLeft = 10,
        PushFromTop = 11,
        PushFromBottom = 12,
        SlideToLeft = 13,
        SlideToRight = 14,
        SlideToTop = 15,
        SlideToBottom = 16,
        SlideMenuLeft = 17,
        SlideMenuBack = 18,
        Flip = 19,
    }
}
