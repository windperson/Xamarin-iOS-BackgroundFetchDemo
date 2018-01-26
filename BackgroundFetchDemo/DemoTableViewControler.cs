using Foundation;
using System;
using UIKit;

namespace BackgroundFetchDemo
{
    public sealed partial class DemoTableViewControler : UITableViewController
    {
        private readonly DemoTableSource dataSource;


        public DemoTableViewControler(IntPtr handle) : base(handle)
        {
            Title = NSBundle.MainBundle.LocalizedString("Master", "Master");
            TableView.Source = dataSource = new DemoTableSource();
        }

        public void AddNewItem()
        {
            dataSource.Objects.Insert(0, DateTime.Now);

            var indexPath = NSIndexPath.FromRowSection(0, 0);
            TableView.InsertRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Automatic);
        }

        public void InsertNewObjectForFetch(Action<UIBackgroundFetchResult> completionhandler)
        {
            AddNewItem();
            completionhandler(UIBackgroundFetchResult.NewData);
        }
    }
}