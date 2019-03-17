using MyReview.Extensions;
using UIKit;

namespace MyReview.Views.Home
{
    public class HomeView : UIView
    {
        public DatePanelView DatePanel { get; private set; }

        public HomeView()
        {
            BuildView();
        }

        private void BuildView()
        {
            // create
            DatePanel = new DatePanelView();

            // styles
            BackgroundColor = UIColor.White;

            // hierarchy
            Add(DatePanel);

            // constraints
            DatePanel.AlignLeftAnchor(LeftAnchor, 5f);
            DatePanel.AlignTopAnchor(this, 20f);
            DatePanel.AlignRightAnchor(RightAnchor, 5f);
        }
    }
}