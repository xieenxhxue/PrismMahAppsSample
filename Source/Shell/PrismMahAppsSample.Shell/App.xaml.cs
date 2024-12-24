using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Unity;
using Prism.Unity;
using PrismMahAppsSample.Infrastructure.Constants;
using PrismMahAppsSample.Shell;
using PrismMahAppsSample.Shell.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity.Lifetime;
using PrismMahAppsSample.Infrastructure.Interfaces;
using PrismMahAppsSample.Infrastructure.Services;
using System.ComponentModel;
using PrismMahAppsSample.Infrastructure;
using System.Xml.Linq;
using Unity.Injection;
using MahApps.Metro.Controls;

namespace PrismMahAppsSample
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App 
    {
        //使用容器创建主窗体
        //protected override Window CreateShell() =>
        //     base.Container.Resolve<Window>(WindowNames.MainWindowName);
        protected override Window CreateShell()
        {
            var shell =  base.Container.Resolve<Window>(WindowNames.MainWindowName);
            return shell;
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //通过代码的方式添加模块
            moduleCatalog.AddModule<ModuleA.ModuleA>();
            moduleCatalog.AddModule<ModuleB.ModuleB>();
            //将MedicineModule模块设置为按需加载
            base.ConfigureModuleCatalog(moduleCatalog);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterInstance("zh-CN", "culture");


            // Application commands
            containerRegistry.Register<IApplicationCommands, ApplicationCommandsProxy>();
            // Flyout service
            containerRegistry.RegisterSingleton<IFlyoutService, FlyoutService>();
            // Localizer service
            //containerRegistry.RegisterSingleton<ILocalizerService, LocalizerService>(new InjectionConstructor("zh-CN"));
            containerRegistry.RegisterSingleton<ILocalizerService, LocalizerService>(ServiceNames.LocalizerService);
            containerRegistry.RegisterSingleton<IMetroMessageDisplayService, MetroMessageDisplayService>();


            containerRegistry.RegisterSingleton<Window,MainWindow>(WindowNames.MainWindowName);
        }


        protected override IModuleCatalog CreateModuleCatalog()
        {
            ConfigurationModuleCatalog configurationModuleCatalog = new ConfigurationModuleCatalog();
            configurationModuleCatalog.Load();

            //通过Xaml配置文件读取模块加载信息

            return configurationModuleCatalog;
            //return directoryModuleCatalog;
        }

        /// <summary>
        /// 注册适配器（区域容器:Region）
        /// </summary>
        /// <param name="regionAdapterMappings"></param>
        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
        }
    }
}
