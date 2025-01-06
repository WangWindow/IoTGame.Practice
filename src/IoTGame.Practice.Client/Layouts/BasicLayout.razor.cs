using System.Globalization;
using System.Net.Http.Json;
using AntDesign.Extensions.Localization;
using AntDesign.ProLayout;
using Microsoft.AspNetCore.Components;

namespace IoTGame.Practice.Layouts
{
    public partial class BasicLayout : LayoutComponentBase, IDisposable
    {
        private MenuDataItem[] _menuData;

        [Inject]
        private ReuseTabsService TabService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _menuData = new[]
            {
                new MenuDataItem
                {
                    Path = "/",
                    Name = "home",
                    Key = "home",
                    Icon = "home",
                },
                new MenuDataItem
                {
                    Path = "/chart",
                    Name = "chart",
                    Key = "chart",
                    Icon = "line-chart",
                },
                new MenuDataItem
                {
                    Path = "/history",
                    Name = "history",
                    Key = "history",
                    Icon = "history",
                },
                new MenuDataItem
                {
                    Path = "/monitor",
                    Name = "monitor",
                    Key = "monitor",
                    Icon = "monitor",
                },
                new MenuDataItem
                {
                    Path = "/service",
                    Name = "service",
                    Key = "service",
                    Icon = "unordered-list",
                },
                new MenuDataItem
                {
                    Path = "/settings",
                    Name = "settings",
                    Key = "settings",
                    Icon = "setting",
                },
            };
        }

        void Reload()
        {
            TabService.ReloadPage();
        }

        public void Dispose() { }
    }
}
