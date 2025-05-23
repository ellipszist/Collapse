﻿using Hi3Helper;
using Hi3Helper.SentryHelper;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.Web.WebView2.Core;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using static Hi3Helper.Logger;
using static Hi3Helper.Shared.Region.LauncherConfig;
// ReSharper disable RedundantExtendsListEntry
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable StringLiteralTypo

#nullable enable
namespace CollapseLauncher
{
    public sealed partial class WebView2FramePage : Page, IDisposable
    {
        public static  Uri? WebView2URL { get; set; }

        private bool      _disposed;
        private WebView2? _webView2Runtime;

        public WebView2FramePage()
        {
            if (string.IsNullOrWhiteSpace(WebView2URL?.ToString()))
                throw new ArgumentNullException(nameof(WebView2URL), "WebView2URL cannot be null or empty.");
            
            InitializeComponent();
            _ = SpawnWebView2Panel(WebView2URL);
        }
        
        ~WebView2FramePage()
        {
            Dispose();
        }

        private async Task SpawnWebView2Panel(Uri url)
        {
            try
            {
                Environment.SetEnvironmentVariable("WEBVIEW2_USER_DATA_FOLDER", Path.Combine(AppGameFolder, "_webView2"));
                
                _webView2Runtime = new WebView2
                {
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment   = VerticalAlignment.Stretch
                };
            
                _webView2Runtime.CoreWebView2Initialized += WebView2Window_CoreWebView2Initialized;
                _webView2Runtime.NavigationStarting      += WebView2Window_PageLoading;
                _webView2Runtime.NavigationCompleted     += WebView2Window_PageLoaded;
                
                WebViewWindowTitle.Text = Locale.Lang._MainPage.Initializing;
                
                await _webView2Runtime.EnsureCoreWebView2Async();
                
                WebView2WindowContainer.Children.Clear();
                WebView2WindowContainer.Children.Add(_webView2Runtime);

                WebView2Panel.Visibility  =  Visibility.Visible;
                WebView2Panel.Translation += Shadow32;

                SetWebView2Bindings();
                _webView2Runtime.Source = url;

                ChangeTitleDragArea.Change(DragAreaTemplate.Full);
            }
            catch (Exception ex)
            {
                SentryHelper.ExceptionHandler(ex, SentryHelper.ExceptionType.UnhandledOther);
                LogWriteLine($"Error while initialize WebView2. Open it to browser instead!\r\n{ex}", LogType.Error, true);
                OpenInExternalBrowser(WebView2URL?.ToString());
                
                SpawnWebView2.SpawnWebView2Window(null, Content);
            }
        }

        private void SetWebView2Bindings()
        {
            BindingOperations.SetBinding(WebView2BackBtn, IsEnabledProperty, new Binding
            {
                Source = _webView2Runtime,
                Path = new PropertyPath("CanGoBack"),
                Mode = BindingMode.OneWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            });
            BindingOperations.SetBinding(WebView2ForwardBtn, IsEnabledProperty, new Binding
            {
                Source = _webView2Runtime,
                Path = new PropertyPath("CanGoForward"),
                Mode = BindingMode.OneWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            });
            BindingOperations.SetBinding(WebView2URLBox, TextBox.TextProperty, new Binding
            {
                Source = _webView2Runtime,
                Path = new PropertyPath("Source"),
                Mode = BindingMode.OneWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            });
        }

        private void OpenInExternalBrowser(string? uri)
        {
            if (string.IsNullOrWhiteSpace(uri)) return;
            
            new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    FileName        = uri
                }
            }.Start();
        }

        private void CoreWebView2_DocumentTitleChanged(CoreWebView2 sender, object args) => WebViewWindowTitle.Text = sender.DocumentTitle;
        private void WebView2Window_CoreWebView2Initialized(WebView2 sender, CoreWebView2InitializedEventArgs args)
        {
            try
            {
                sender.CoreWebView2.DocumentTitleChanged += CoreWebView2_DocumentTitleChanged;
            }
            catch (Exception ex)
            {
                SentryHelper.ExceptionHandler(ex, SentryHelper.ExceptionType.UnhandledOther);
                if (ex is NotSupportedException nsEx)
                {
                    LogWriteLine($"Half-baked NativeAOT Bug (nice MSFT!) :) https://github.com/MicrosoftEdge/WebView2Feedback/issues/4783\r\n{nsEx}", LogType.Error, true);
                }
            }
        }
        private void WebView2Window_PageLoaded(WebView2 sender, CoreWebView2NavigationCompletedEventArgs args) => WebView2LoadingStatus.IsIndeterminate = false;
        private void WebView2Window_PageLoading(WebView2 sender, CoreWebView2NavigationStartingEventArgs args) => WebView2LoadingStatus.IsIndeterminate = true;
        private void WebView2BackBtn_Click(object sender, RoutedEventArgs e) => _webView2Runtime?.GoBack();
        private void WebView2ForwardBtn_Click(object sender, RoutedEventArgs e) => _webView2Runtime?.GoForward();
        private void WebView2ReloadBtn_Click(object sender, RoutedEventArgs e) => _webView2Runtime?.Reload();
        private void WebView2OpenExternalBtn_Click(object sender, RoutedEventArgs e) => OpenInExternalBrowser(_webView2Runtime?.Source.ToString());
        private void WebView2CloseBtn_Click(object sender, RoutedEventArgs e) => SpawnWebView2.SpawnWebView2Window(null, Content);

        private void WebView2Unload(object sender, RoutedEventArgs e)
        {
            ChangeTitleDragArea.Change(DragAreaTemplate.Default);
            WebView2Panel.Visibility  =  Visibility.Collapsed;
            WebView2Panel.Translation -= Shadow32;
            
            Dispose();
        }

        public void Dispose()
        {
            if (_disposed) return;
            
            if (_webView2Runtime != null)
            {
                _webView2Runtime.Visibility = Visibility.Collapsed;
            
                _webView2Runtime.CoreWebView2Initialized -= WebView2Window_CoreWebView2Initialized;
                _webView2Runtime.NavigationStarting      -= WebView2Window_PageLoading;
                _webView2Runtime.NavigationCompleted     -= WebView2Window_PageLoaded;
            }
            
            _webView2Runtime?.Close();
            _webView2Runtime = null;
            _disposed        = true;
            GC.SuppressFinalize(this);
        }
    }
}
