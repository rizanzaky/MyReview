using MyReview.Extensions;
using MyReview.Views.Home.Targets;
using UIKit;

namespace MyReview.Views.Home
{
    public class HomeView : UIView
    {
        public DatePanelView DatePanel { get; private set; }
        public TargetsTableView TargetsTable { get; private set; }

        public HomeView()
        {
            BuildView();
        }

        private void BuildView()
        {
            // create
            DatePanel = new DatePanelView();
            TargetsTable = new TargetsTableView();

            // styles
            BackgroundColor = UIColor.White;

            // hierarchy
            Add(DatePanel);
            Add(TargetsTable);

            // constraints
            DatePanel.AlignLeftAnchor(LeftAnchor, 5f);
            DatePanel.AlignTopAnchor(TopAnchor, 20f);
            DatePanel.AlignRightAnchor(RightAnchor, 5f);

            TargetsTable.AlignTopAnchor(DatePanel.BottomAnchor, 15f);
            TargetsTable.AlignLeftAnchor(LeftAnchor, 5f);
            TargetsTable.AlignRightAnchor(RightAnchor, 5f);
            TargetsTable.AlignBottomAnchor(this, 15f);
        }
    }
}