# PrismMahAppsSample

forked from [steve600/PrismMahAppsSample] (https://github.com/steve600/PrismMahAppsSample)

```
1.Prism
2.MahApps.Metro
3.Unity
4.WPFLocalizeExtension
5.NLog
```

## Update
Update .NET Framework 4.8
### branch prism6
git branch prism6
Update NuGet-Packages
- Prism 6.3.0
- Unity 4.0.1
- Nlog  5.3.4
- WPFLocalizeExtension 3.10.0
- XAMLMarkupExtensions 2.1.3
- MahApp.Metro 1.2.4
- MahApps.Metro.Resources 0.6.1


Update  
```
xmlns:prism="http://www.codeplex.com/prism"
xmlns:lex="http://wpflocalizeextension.codeplex.com"
```
to 
```
xmlns:prism="http://prismlibrary.com/"
xmlns:lex="https://github.com/XAMLMarkupExtensions/WPFLocalizationExtension"
```

### branch prism7
git branch prism7
Add NuGet-Packages
- System.ValueTuple 4.5.0
- System.Threading.Tasks.Extensions 4.5.2
- System.Runtime.CompilerServices.Unsafe 4.5.2
- Unity.Abstractions 5.11.1
- Unity.Container 5.11.1

Update NuGet-Packages
- Prism.Core 7.2.0.1422
- Prism.Wpf  7.2.0.1422
- CommonServiceLocator 2.0.4
- Unity 5.11.1

namespace changed
```
Microsoft.Practices.ServiceLocation
Microsoft.Practices.Unity
```
to
```
CommonServiceLocator
Unity
```

Prism.Modularity.IModule interface changed 
```
Initialize
```
to Implemented
``` 
RegisterTypes(IContainerRegistry containerRegistry);
OnInitialized(IContainerProvider containerProvider);
```

remove 
``` 
Bootstrapper.cs
```

``` App.cs
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
           base.OnStartup(e);
           Bootstrapper bootstrapper = new Bootstrapper();
           bootstrapper.Run();
       }
    }
```
to 
``` App.cs implemented PrismApplication

    public partial class App:PrismApplication
    {
        protected override Window CreateShell()
        {
           return base.Container.Resolve<MainWindow>();
        }
    }
```


``` App.xaml
<Application x:Class="PrismMahAppsSample.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:local="clr-namespace:PrismMahAppsSample">
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>

                <!-- Custom-Styles -->
                <ResourceDictionary Source="/PrismMahAppsSample.Styling;component/LookAndFeel.xaml"/>

                <!-- MahApps-Styles -->
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Controls.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Fonts.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Colors.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Accents/Blue.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Accents/BaseLight.xaml" />

                <!-- ModernUI-Icons -->
                <ResourceDictionary Source="/Resources/Icons.xaml" />

            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
</Application>

```


``` App.xaml
<Application x:Class="PrismMahAppsSample.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:prism="http://prismlibrary.com/"
             xmlns:local="clr-namespace:PrismMahAppsSample">
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>

                <!-- Custom-Styles -->
                <ResourceDictionary Source="/PrismMahAppsSample.Styling;component/LookAndFeel.xaml"/>

                <!-- MahApps-Styles -->
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Controls.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Fonts.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Colors.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Accents/Blue.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Accents/BaseLight.xaml" />

                <!-- ModernUI-Icons -->
                <ResourceDictionary Source="/Resources/Icons.xaml" />

            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
</Application>

```

Add NuGet-Packages

- ControlzEx 4.4.0
- Microsoft.Xaml.Behaviors.Wpf.1.1.135
- MahApps.Metro.IconPacks.Modern 5.1.0
- Unity.Abstractions 5.11.1
- Unity.Container 5.11.1

Update NuGet-Packages
- MahApps.Metro 2.4.10
- CommonServiceLocator 2.0.7
- Unity.Abstractions 5.11.10
- Unity.Container 5.11.11

remove NuGet-Packages
- MahApps.Metro.Resources 0.6.1


``` App.xaml
<Application x:Class="PrismMahAppsSample.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:prism="http://prismlibrary.com/"
             xmlns:local="clr-namespace:PrismMahAppsSample">
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>

                <!-- Custom-Styles -->
                <ResourceDictionary Source="/PrismMahAppsSample.Styling;component/LookAndFeel.xaml"/>

                <!-- MahApps.Metro resource dictionaries. Make sure that all file names are Case Sensitive! -->
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Controls.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Fonts.xaml" />
                <!-- Theme setting -->
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Themes/Light.Blue.xaml" />

                <!-- ModernUI-Icons -->
                <ResourceDictionary Source="/Resources/Icons.xaml" />

            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
</Application>

```