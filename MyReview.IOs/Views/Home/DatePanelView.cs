using System;
using MyReview.Extensions;
using UIKit;

namespace MyReview.Views.Home
{
    public class DatePanelView : UIView
    {
        public UIButton LeftButton { get; private set; }
        public UILabel DateLabel { get; private set; }
        public UIButton RightButton { get; private set; }

        public DatePanelView()
        {
            BuildView();
        }
        private void BuildView()
        {
            // create
            LeftButton = new UIButton { TranslatesAutoresizingMaskIntoConstraints = false };
            LeftButton.SetTitle("<", UIControlState.Normal);
            LeftButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            LeftButton.SetTitleColor(UIColor.Gray, UIControlState.Highlighted);
            DateLabel = new UILabel { TranslatesAutoresizingMaskIntoConstraints = false };
            DateLabel.TextAlignment = UITextAlignment.Center;
            RightButton = new UIButton {TranslatesAutoresizingMaskIntoConstraints = false};
            RightButton.SetTitle(">", UIControlState.Normal);
            RightButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            RightButton.SetTitleColor(UIColor.Gray, UIControlState.Highlighted);

            // styles

            // hierarchy
            Add(LeftButton);
            Add(DateLabel);
            Add(RightButton);

            // constraints
            TranslatesAutoresizingMaskIntoConstraints = false;

            LeftButton.AlignTopAnchor(this, 5f);
            LeftButton.AlignLeftAnchor(LeftAnchor, 10f);
            LeftButton.AlignBottomAnchor(this, 5f);
            LeftButton.AlignWidthAnchor(80f);
            LeftButton.AlignHeightAnchor(50f);

            DateLabel.AlignTopAnchor(this, 5f);
            DateLabel.AlignBottomAnchor(this, 5f);
            DateLabel.AlignLeftAnchor(LeftButton.RightAnchor, 10f);
            DateLabel.AlignRightAnchor(RightButton.LeftAnchor, 10f);

            RightButton.AlignTopAnchor(this, 5f);
            RightButton.AlignRightAnchor(RightAnchor, 10f);
            RightButton.AlignBottomAnchor(this, 5f);
            RightButton.AlignWidthAnchor(80f);
            RightButton.AlignHeightAnchor(50f);
        }
    }
}