﻿// <auto-generated>
// </auto-generated>
namespace BYteWare.XAF.ElasticSearch.Win.Template
{
    using DevExpress.ExpressApp;
    using DevExpress.ExpressApp.Templates;
    using DevExpress.ExpressApp.Templates.ActionControls;
    using DevExpress.ExpressApp.Utils;
    using DevExpress.ExpressApp.Win.Controls;
    using DevExpress.ExpressApp.Win.SystemModule;
    using DevExpress.ExpressApp.Win.Templates;
    using DevExpress.ExpressApp.Win.Templates.Utils;
    using DevExpress.Utils.Controls;
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;
    using DevExpress.XtraPrinting;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;

    [ToolboxItem(false)]
    [CLSCompliant(false)]
    public partial class NestedDynamicActionContainerV2 : XtraUserControl, IActionControlsSite, IFrameTemplate, ISupportActionsToolbarVisibility, IViewSiteTemplate, ISupportUpdate, IBarManagerHolder, ISupportViewChanged, IContextMenuHolder, IBasePrintableProvider, IViewHolder, IDynamicContainersTemplate
    {
        private static readonly object viewChanged = new object();
        private XtraResizableControlProxy resizableControlProxy;

        protected virtual void RaiseViewChanged(DevExpress.ExpressApp.View view)
        {
            ((EventHandler<TemplateViewChangedEventArgs>)Events[viewChanged])?.Invoke(this, new TemplateViewChangedEventArgs(view));
        }

        protected override IXtraResizableControl GetInnerIXtraResizableControl()
        {
            return resizableControlProxy;
        }

        public NestedDynamicActionContainerV2()
        {
            InitializeComponent();
            resizableControlProxy = new XtraResizableControlProxy(viewSitePanel, barManager.DockControls);
            barManager.ProcessShortcutsWhenInvisible = false;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        public Bar ToolBar
        {
            get
            {
                return standardToolBar;
            }
        }

        /// <summary>
        /// Returns the Action Container Manager
        /// </summary>
        public ActionContainersManager ActionContainersManager
        {
            get
            {
                return actionContainersManager;
            }
        }

        /// <summary>
        /// Event that is called if an Action Container was changed
        /// </summary>
        public event EventHandler<ActionContainersChangedEventArgs> ActionContainersChanged;

        /// <summary>
        /// Registers the Enumeration of Action Containers
        /// </summary>
        /// <param name="actionContainers">Enumeration of Action Containers</param>
        public void RegisterActionContainers(IEnumerable<IActionContainer> actionContainers)
        {
            if (actionContainers != null)
            {
                ActionContainersManager.ActionContainerComponents.AddRange(actionContainers);
                OnActionContainersChanged(new ActionContainersChangedEventArgs(actionContainers, ActionContainersChangedType.Added));
            }
        }

        /// <summary>
        /// Unregisters the Enumeration of Action Containers
        /// </summary>
        /// <param name="actionContainers">Enumeration of Action Containers</param>
        public void UnregisterActionContainers(IEnumerable<IActionContainer> actionContainers)
        {
            if (actionContainers != null)
            {
                foreach (IActionContainer actionContainer in actionContainers)
                {
                    ActionContainersManager.ActionContainerComponents.Remove(actionContainer);
                }
                OnActionContainersChanged(new ActionContainersChangedEventArgs(actionContainers, ActionContainersChangedType.Removed));
            }
        }

        /// <summary>
        /// Calls the Event Handlers of ActionContainersChanged
        /// </summary>
        /// <param name="e">The ActionContainersChanged Event Arguments to pass</param>
        protected virtual void OnActionContainersChanged(ActionContainersChangedEventArgs e)
        {
            ActionContainersChanged?.Invoke(this, e);
        }

        IEnumerable<IActionControl> IActionControlsSite.ActionControls
        {
            get
            {
                return barManager.ActionControls;
            }
        }

        IEnumerable<IActionControlContainer> IActionControlsSite.ActionContainers
        {
            get
            {
                return barManager.ActionContainers;
            }
        }

        IActionControlContainer IActionControlsSite.DefaultContainer
        {
            get
            {
                return actionContainerDefault;
            }
        }

        void IFrameTemplate.SetView(DevExpress.ExpressApp.View view)
        {
            viewSiteManager.SetView(view);
            if (view != null)
            {
                Tag = EasyTestTagHelper.FormatTestContainer(view.Caption);
            }
            RaiseViewChanged(view);
        }

        ICollection<IActionContainer> IFrameTemplate.GetContainers()
        {
            return actionContainersManager.GetContainers();
        }

        IActionContainer IFrameTemplate.DefaultContainer
        {
            get
            {
                return actionContainersManager.DefaultContainer;
            }
        }

        void ISupportUpdate.BeginUpdate()
        {
            barManager.BeginUpdate();
        }

        void ISupportUpdate.EndUpdate()
        {
            barManager.EndUpdate();
        }

        BarManager IBarManagerHolder.BarManager
        {
            get
            {
                return barManager;
            }
        }

        event EventHandler IBarManagerHolder.BarManagerChanged
        {
            add
            {
            }
            remove
            {
            }
        }

        object IViewSiteTemplate.ViewSiteControl
        {
            get
            {
                return viewSiteManager.ViewSiteControl;
            }
        }

        event EventHandler<TemplateViewChangedEventArgs> ISupportViewChanged.ViewChanged
        {
            add
            {
                Events.AddHandler(viewChanged, value);
            }
            remove
            {
                Events.RemoveHandler(viewChanged, value);
            }
        }

        void ISupportActionsToolbarVisibility.SetVisible(bool isVisible)
        {
            foreach (Bar bar in barManager.Bars)
            {
                bar.Visible = isVisible;
            }
        }

        PopupMenu IContextMenuHolder.ContextMenu
        {
            get
            {
                return contextMenu;
            }
        }

        object IBasePrintableProvider.GetIPrintableImplementer()
        {
            var view = viewSiteManager.View;
            return view != null ? view.Control : null;
        }

        DevExpress.ExpressApp.View IViewHolder.View
        {
            get
            {
                return viewSiteManager.View;
            }
        }
    }
}
