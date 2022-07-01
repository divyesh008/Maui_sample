using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using poc_maui.Models;

namespace poc_maui.ViewModels
{
	public class HomePageViewModel : BaseViewModel
	{
		public HomePageViewModel()
		{
            GetTabs();
        }

        private bool _isParentRecordTabVisible = true;
        private bool _isAdditionalInfoTabVisible;
        private ObservableCollection<TabViewModel> _tabs { get; set; }

        public bool IsParentRecordTabVisible
        {
            get => _isParentRecordTabVisible;
            set { _isParentRecordTabVisible = value; OnPropertyChanged(nameof(IsParentRecordTabVisible)); }
        }

        public bool IsAdditionalInfoTabVisible
        {
            get => _isAdditionalInfoTabVisible;
            set { _isAdditionalInfoTabVisible = value; OnPropertyChanged(nameof(IsAdditionalInfoTabVisible)); }
        }

        public ObservableCollection<TabViewModel> Tabs
        {
            get => _tabs;
            set { _tabs = value; OnPropertyChanged(nameof(Tabs)); }
        }

        private void GetTabs()
        {
            Tabs = new ObservableCollection<TabViewModel>();
            Tabs.Add(new TabViewModel { TabId = 1, IsSelected = true, TabTitle = "Parent record" });
            Tabs.Add(new TabViewModel { TabId = 2, TabTitle = "Additional Info" });
            Tabs.Add(new TabViewModel { TabId = 3, TabTitle = "Contacts" });
            Tabs.Add(new TabViewModel { TabId = 4, TabTitle = "Previous inspections" });
            Tabs.Add(new TabViewModel { TabId = 5, TabTitle = "Attachments" });
        }

        private void ChangeTabClick(TabViewModel tab)
        {
            try
            {
                var tabs = new ObservableCollection<TabViewModel>(Tabs);

                foreach (var item in tabs)
                {
                    if (item.TabId == tab.TabId)
                    {
                        item.IsSelected = true;
                    }
                    else
                    {
                        item.IsSelected = false;
                    }
                }

                Tabs.Clear();
                Tabs = new ObservableCollection<TabViewModel>(tabs);

                switch (tab.TabId)
                {
                    case 1:
                        IsParentRecordTabVisible = true;
                        IsAdditionalInfoTabVisible = false;
                        break;
                    case 2:
                        IsParentRecordTabVisible = false;
                        IsAdditionalInfoTabVisible = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}

