using UIKit;

namespace MyReview.Extensions
{
    public static class LayoutHelper
    {
        public static NSLayoutConstraint AlignLeftAnchor(this UIView view, NSLayoutXAxisAnchor anchor, float constant)
        {
            var constraint = view.LeftAnchor.ConstraintEqualTo(anchor, constant);
            constraint.Active = true;
            return constraint;
        }
        public static NSLayoutConstraint AlignRightAnchor(this UIView view, NSLayoutXAxisAnchor anchor, float constant)
        {
            var constraint = view.RightAnchor.ConstraintEqualTo(anchor, -constant);
            constraint.Active = true;
            return constraint;
        }
        public static NSLayoutConstraint AlignTopAnchor(this UIView view, UIView parent, float constant)
        {
            var constraint = view.TopAnchor.ConstraintEqualTo(parent.TopAnchor, constant);
            constraint.Active = true;
            return constraint;
        }
        public static NSLayoutConstraint AlignBottomAnchor(this UIView view, UIView parent, float constant)
        {
            var constraint = view.BottomAnchor.ConstraintEqualTo(parent.BottomAnchor, -constant);
            constraint.Active = true;
            return constraint;
        }
        public static NSLayoutConstraint AlignWidthAnchor(this UIView view, float constant)
        {
            var constraint = view.WidthAnchor.ConstraintEqualTo(constant);
            constraint.Active = true;
            return constraint;
        }
        public static NSLayoutConstraint AlignHeightAnchor(this UIView view, float constant)
        {
            var constraint = view.HeightAnchor.ConstraintEqualTo(constant);
            constraint.Active = true;
            return constraint;
        }
    }
}