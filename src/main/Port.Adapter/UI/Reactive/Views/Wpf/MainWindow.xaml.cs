﻿/************************************************************************

   AvalonDock

   Copyright (C) 2007-2013 Xceed Software Inc.

   This program is provided to you under the terms of the New BSD
   License (BSD) as published at http://avalondock.codeplex.com/license 

   For more features, controls, and fast professional support,
   pick up AvalonDock in Extended WPF Toolkit Plus at http://xceed.com/wpf_toolkit

   Stay informed: follow @datagrid on Twitter or Like facebook.com/datagrids

  **********************************************************************/
// Modifications copyright(C) 2018 ei8/Elmer Bool

using ReactiveUI;
using System.Windows;
using works.ei8.Cortex.Diary.Port.Adapter.UI.Reactive.ViewModels.Docking;

namespace works.ei8.Cortex.Diary.Port.Adapter.UI.Reactive.Views.Wpf
{
    public partial class MainWindow : Window, IViewFor<Workspace>
    {
        public MainWindow()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                d(this.BindCommand(this.ViewModel, vm => vm.NewNeuronGraph, v => v.NewNeuronGraph));
                d(this.OneWayBind(this.ViewModel, vm => vm.Tools, v => v.dockManager.AnchorablesSource));
                d(this.OneWayBind(this.ViewModel, vm => vm.Panes, v => v.dockManager.DocumentsSource));
                d(this.Bind(this.ViewModel, vm => vm.ActiveDocument, v => v.dockManager.ActiveContent));
            });
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (Workspace)value; }
        }

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            "ViewModel", typeof(Workspace), typeof(MainWindow), new PropertyMetadata(default(Workspace)));

        public Workspace ViewModel
        {
            get { return (Workspace)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        private void OnDumpToConsole(object sender, RoutedEventArgs e)
        {
            // Uncomment when TRACE is activated on AvalonDock project
            //dockManager.Layout.ConsoleDump(0);
        }

        // TODO: public MainWindow()
        //{
        //    InitializeComponent();

        //    this.DataContext = Workspace.This;

        //    this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        //    this.Unloaded += new RoutedEventHandler(MainWindow_Unloaded);
        //}

        //void MainWindow_Loaded(object sender, RoutedEventArgs e)
        //{
        //    var serializer = new Xceed.Wpf.AvalonDock.Layout.Serialization.XmlLayoutSerializer(dockManager);
        //    serializer.LayoutSerializationCallback += (s, args) =>
        //    {
        //        args.Content = args.Content;
        //    };

        //    if (File.Exists(@".\AvalonDock.config"))
        //        serializer.Deserialize(@".\AvalonDock.config");
        //}

        //void MainWindow_Unloaded(object sender, RoutedEventArgs e)
        //{
        //    var serializer = new Xceed.Wpf.AvalonDock.Layout.Serialization.XmlLayoutSerializer(dockManager);
        //    serializer.Serialize(@".\AvalonDock.config");
        //}

        //#region LoadLayoutCommand
        //RelayCommand _loadLayoutCommand = null;
        //public ICommand LoadLayoutCommand
        //{
        //    get
        //    {
        //        if (_loadLayoutCommand == null)
        //        {
        //            _loadLayoutCommand = new RelayCommand((p) => OnLoadLayout(p), (p) => CanLoadLayout(p));
        //        }

        //        return _loadLayoutCommand;
        //    }
        //}

        //private bool CanLoadLayout(object parameter)
        //{
        //    return File.Exists(@".\AvalonDock.Layout.config");
        //}

        //private void OnLoadLayout(object parameter)
        //{
        //    var layoutSerializer = new XmlLayoutSerializer(dockManager);
        //    //Here I've implemented the LayoutSerializationCallback just to show
        //    // a way to feed layout desarialization with content loaded at runtime
        //    //Actually I could in this case let AvalonDock to attach the contents
        //    //from current layout using the content ids
        //    //LayoutSerializationCallback should anyway be handled to attach contents
        //    //not currently loaded
        //    layoutSerializer.LayoutSerializationCallback += (s, e) =>
        //    {
        //        //if (e.Model.ContentId == FileStatsViewModel.ToolContentId)
        //        //    e.Content = Workspace.This.FileStats;
        //        //else if (!string.IsNullOrWhiteSpace(e.Model.ContentId) &&
        //        //    File.Exists(e.Model.ContentId))
        //        //    e.Content = Workspace.This.Open(e.Model.ContentId);
        //    };
        //    layoutSerializer.Deserialize(@".\AvalonDock.Layout.config");
        //}

        //#endregion 

        //#region SaveLayoutCommand
        //RelayCommand _saveLayoutCommand = null;
        //public ICommand SaveLayoutCommand
        //{
        //    get
        //    {
        //        if (_saveLayoutCommand == null)
        //        {
        //            _saveLayoutCommand = new RelayCommand((p) => OnSaveLayout(p), (p) => CanSaveLayout(p));
        //        }

        //        return _saveLayoutCommand;
        //    }
        //}

        //private bool CanSaveLayout(object parameter)
        //{
        //    return true;
        //}

        //private void OnSaveLayout(object parameter)
        //{
        //    var layoutSerializer = new XmlLayoutSerializer(dockManager);
        //    layoutSerializer.Serialize(@".\AvalonDock.Layout.config");
        //}

        //#endregion 
    }
}
