﻿#pragma checksum "..\..\..\Pages\PageRegistration.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D3E37B3E08BF058CF2ED2DA716C6DF15C0806967C06D75ED0DF104FDCD6C569F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using TaskHill.Pages;


namespace TaskHill.Pages {
    
    
    /// <summary>
    /// PageRegistration
    /// </summary>
    public partial class PageRegistration : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\Pages\PageRegistration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImageBackToLogin;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Pages\PageRegistration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxUserEmail;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Pages\PageRegistration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxUserLogin;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Pages\PageRegistration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox TextBoxUserPassword;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Pages\PageRegistration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox TextBoxUserPassword2;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Pages\PageRegistration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonToKeepRegistration;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Pages\PageRegistration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonNewRegister;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TaskHill;component/pages/pageregistration.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\PageRegistration.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ImageBackToLogin = ((System.Windows.Controls.Image)(target));
            
            #line 26 "..\..\..\Pages\PageRegistration.xaml"
            this.ImageBackToLogin.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ImageBackToLogin_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TextBoxUserEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TextBoxUserLogin = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TextBoxUserPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 39 "..\..\..\Pages\PageRegistration.xaml"
            this.TextBoxUserPassword.PasswordChanged += new System.Windows.RoutedEventHandler(this.TextBoxPassword_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TextBoxUserPassword2 = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 40 "..\..\..\Pages\PageRegistration.xaml"
            this.TextBoxUserPassword2.PasswordChanged += new System.Windows.RoutedEventHandler(this.TextBoxPassword_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ButtonToKeepRegistration = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.ButtonNewRegister = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
