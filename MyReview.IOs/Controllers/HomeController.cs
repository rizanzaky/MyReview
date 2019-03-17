using System;
using MyReview.Views.Home;
using UIKit;

namespace MyReview.Controllers
{
    public class HomeController : UIViewController
    {
        private readonly HomeView _homeView;
        private DateTime _panelDate;

        public HomeController()
        {
            _homeView = new HomeView();
        }

        public DateTime PanelDate
        {
            get => _panelDate;
            set
            {
                _panelDate = value;
                _homeView.DatePanel.DateLabel.Text = value.ToShortDateString();
            }
        }

        public override void LoadView()
        {
            View = _homeView;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            PanelDate = DateTime.Now;
            RegisterEvents();
        }

        public override void WillMoveToParentViewController(UIViewController parent)
        {
            base.WillMoveToParentViewController(parent);

            if (parent != null) UnregisterEvents();
        }

        private void OnRightButtonClicked(object sender, EventArgs args)
        {
            PanelDate = PanelDate.AddDays(1);
        }

        private void OnLeftButtonClicked(object sender, EventArgs args)
        {
            PanelDate = PanelDate.AddDays(-1);
        }

        private void RegisterEvents()
        {
            _homeView.DatePanel.LeftButton.TouchUpInside += OnLeftButtonClicked;
            _homeView.DatePanel.RightButton.TouchUpInside += OnRightButtonClicked;
        }

        private void UnregisterEvents()
        {
            _homeView.DatePanel.LeftButton.TouchUpInside -= OnLeftButtonClicked;
            _homeView.DatePanel.RightButton.TouchUpInside -= OnRightButtonClicked;
        }
    }
}