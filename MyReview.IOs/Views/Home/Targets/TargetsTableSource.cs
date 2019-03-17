using System;
using System.Collections.Generic;
using Foundation;
using MyReview.Core.Models;
using UIKit;

namespace MyReview.Views.Home.Targets
{
    public class TargetsTableSource : UITableViewSource
    {
        public List<TargetModel> DataSource { get; set; }
        private const string CellIdentifier = "TargetCell";

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CellIdentifier) ?? new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
            var targetItem = DataSource[indexPath.Row];
            
            cell.TextLabel.Text = targetItem.Name;

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return DataSource?.Count ?? 0;
        }
    }
}