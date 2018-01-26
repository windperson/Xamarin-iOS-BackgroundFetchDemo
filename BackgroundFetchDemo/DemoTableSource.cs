using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace BackgroundFetchDemo
{
    class DemoTableSource : UITableViewSource
    {
        private static readonly NSString CellIdentifier = new NSString("DataSourceCell");

        private readonly List<object> _objects = new List<object>();
        public IList<object> Objects => _objects;

        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _objects.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
            cell.TextLabel.Text = _objects[indexPath.Row].ToString();
            return cell;
        }

        public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
        {
            return false;
        }
    }
}