using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace InvoiceApp
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            var form = new Form();
            form.Text = "نظام الفواتير وعروض الأسعار";
            form.Width = 1200;
            form.Height = 800;

            var webView = new WebView2();
            webView.Dock = DockStyle.Fill;
            form.Controls.Add(webView);

            // Initialize WebView2
            async void InitializeWebView()
            {
                try
                {
                    // Create WebView2 environment
                    var env = await CoreWebView2Environment.CreateAsync();
                    await webView.EnsureCoreWebView2Async(env);

                    // Get path to HTML file
                    string exePath = Assembly.GetExecutingAssembly().Location;
                    string exeDir = Path.GetDirectoryName(exePath);
                    string htmlPath = Path.Combine(exeDir, "main.html");

                    if (File.Exists(htmlPath))
                    {
                        webView.CoreWebView2.Navigate(htmlPath);
                    }
                    else
                    {
                        MessageBox.Show($"Error: main.html not found at {htmlPath}", "File Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error initializing WebView2: {ex.Message}", "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            form.Load += (sender, e) => InitializeWebView();
            Application.Run(form);
        }
    }
}