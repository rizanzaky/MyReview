using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MyReview.Extensions;
using UIKit;

namespace MyReview.Views.Home
{
    public class DatePanelView : UIView
    {
        private UIButton _leftButton;
        private UILabel _dateLabel;
        private UIButton _rightButton;

        public DatePanelView()
        {
            BuildView();
        }
        private void BuildView()
        {
            // create
            _leftButton = new UIButton { TranslatesAutoresizingMaskIntoConstraints = false };
            _leftButton.SetTitle("<", UIControlState.Normal);
            _leftButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            _leftButton.SetTitleColor(UIColor.Gray, UIControlState.Highlighted);
            _dateLabel = new UILabel { TranslatesAutoresizingMaskIntoConstraints = false };
            _dateLabel.Text = DateTime.Now.ToShortDateString();
            _dateLabel.TextAlignment = UITextAlignment.Center;
            _rightButton = new UIButton {TranslatesAutoresizingMaskIntoConstraints = false};
            _rightButton.SetTitle(">", UIControlState.Normal);
            _rightButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            _rightButton.SetTitleColor(UIColor.Gray, UIControlState.Highlighted);

            // styles

            // hierarchy
            Add(_leftButton);
            Add(_dateLabel);
            Add(_rightButton);

            // constraints
            TranslatesAutoresizingMaskIntoConstraints = false;

            _leftButton.AlignTopAnchor(this, 5f);
            _leftButton.AlignLeftAnchor(LeftAnchor, 10f);
            _leftButton.AlignBottomAnchor(this, 5f);
            _leftButton.AlignWidthAnchor(80f);
            _leftButton.AlignHeightAnchor(50f);

            _dateLabel.AlignTopAnchor(this, 5f);
            _dateLabel.AlignBottomAnchor(this, 5f);
            _dateLabel.AlignLeftAnchor(_leftButton.RightAnchor, 10f);
            _dateLabel.AlignRightAnchor(_rightButton.LeftAnchor, 10f);

            _rightButton.AlignTopAnchor(this, 5f);
            _rightButton.AlignRightAnchor(RightAnchor, 10f);
            _rightButton.AlignBottomAnchor(this, 5f);
            _rightButton.AlignWidthAnchor(80f);
            _rightButton.AlignHeightAnchor(50f);
        }
    }
}