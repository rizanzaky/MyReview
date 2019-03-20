using MyReview.Extensions;
using MyReview.Views.Home.Targets;
using UIKit;

namespace MyReview.Views.Home
{
    public class HomeView : UIView
    {
        public DatePanelView DatePanel { get; private set; }
        public TargetsTableView TargetsTable { get; private set; }
        public AddTargetView AddTarget { get; set; }

        public HomeView()
        {
            BuildView();
        }

        private void BuildView()
        {
            // create
            DatePanel = new DatePanelView();
            TargetsTable = new TargetsTableView();
            AddTarget = new AddTargetView();

            // styles
            BackgroundColor = UIColor.White;

            // hierarchy
            Add(DatePanel);
            Add(TargetsTable);
            Add(AddTarget);

            // constraints
            DatePanel.AlignLeftAnchor(LeftAnchor, 5f);
            DatePanel.AlignTopAnchor(TopAnchor, 20f);
            DatePanel.AlignRightAnchor(RightAnchor, 5f);

            TargetsTable.AlignTopAnchor(DatePanel.BottomAnchor, 15f);
            TargetsTable.AlignLeftAnchor(LeftAnchor, 5f);
            TargetsTable.AlignRightAnchor(RightAnchor, 5f);
            TargetsTable.AlignBottomAnchor(AddTarget.TopAnchor, 15f);

            AddTarget.AlignLeftAnchor(LeftAnchor, 0f);
            AddTarget.AlignRightAnchor(RightAnchor, 0f);
            TargetViewBottomAnchor = AddTarget.AlignBottomAnchor(BottomAnchor, 0f);
        }

        public NSLayoutConstraint TargetViewBottomAnchor { get; private set; }
    }
}