using UIKit;

namespace Blank.Extensions
{
    public static class LayoutHelper
    {
        public static void AlignLeftAnchor(this UIView view, UIView parent, float constant)
        {
            view.LeftAnchor.ConstraintEqualTo(parent.LeftAnchor, constant);
        }
        public static void AlignRightAnchor(this UIView view, UIView parent, float constant)
        {
            view.RightAnchor.ConstraintEqualTo(parent.RightAnchor, -constant);
        }
        public static void AlignTopAnchor(this UIView view, UIView parent, float constant)
        {
            view.TopAnchor.ConstraintEqualTo(parent.TopAnchor, constant);
        }
        public static void AlignBottomAnchor(this UIView view, UIView parent, float constant)
        {
            view.BottomAnchor.ConstraintEqualTo(parent.BottomAnchor, -constant);
        }
    }
}