using Blank.Extensions;
using Blank.Views;
using UIKit;

namespace Blank.Controllers
{
    public class HomeController : UIViewController
    {
        private readonly HomeView _homeView;

        public HomeController()
        {
            _homeView = new HomeView();
        }

        public override void LoadView()
        {
            View = _homeView;
        }
    }
}