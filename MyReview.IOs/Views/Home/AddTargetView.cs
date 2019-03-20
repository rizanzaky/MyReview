using MyReview.Extensions;
using UIKit;

namespace MyReview.Views.Home
{
    public class AddTargetView : UIView
    {
        public UITextField NewTargetInput { get; private set; }
        public UIButton CancelTargetButton { get; private set; }

        public AddTargetView()
        {
            BuildView();
        }

        private void BuildView()
        {
            // create
            NewTargetInput = new UITextField {TranslatesAutoresizingMaskIntoConstraints = false};
            CancelTargetButton = new UIButton {TranslatesAutoresizingMaskIntoConstraints = false};
            CancelTargetButton.SetTitle("Cancel", UIControlState.Normal);

            // styles
            NewTargetInput.Placeholder = "Give a name to the target...";
            NewTargetInput.ClearButtonMode = UITextFieldViewMode.Always;
            NewTargetInput.BorderStyle = UITextBorderStyle.Line;
            NewTargetInput.ReturnKeyType = UIReturnKeyType.Done;
            CancelTargetButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            CancelTargetButton.SetTitleColor(UIColor.Gray, UIControlState.Highlighted);

            // hierarchy
            Add(NewTargetInput);
            Add(CancelTargetButton);

            // constraints
            TranslatesAutoresizingMaskIntoConstraints = false;

            NewTargetInput.AlignTopAnchor(TopAnchor, 10f);
            NewTargetInput.AlignLeftAnchor(LeftAnchor, 10f);
            NewTargetInput.AlignRightAnchor(CancelTargetButton.LeftAnchor, 20f);
            NewTargetInput.AlignBottomAnchor(BottomAnchor, 10f);

            CancelTargetButton.AlignTopAnchor(TopAnchor, 10f);
            CancelTargetButton.AlignRightAnchor(RightAnchor, 10f);
            CancelTargetButton.AlignBottomAnchor(BottomAnchor, 10f);
        }
    }
}