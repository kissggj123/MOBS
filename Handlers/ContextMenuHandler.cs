using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CefSharp;
using System.Windows.Forms;
using CefSharp.WinForms;
using System.IO;
using System.Threading;
using System.Security.Cryptography;
using System.Collections;
using System.Diagnostics;

namespace MBS {
	internal class ContextMenuHandler : IContextMenuHandler {

		private const int ShowDevTools = 26501;
		private const int CloseDevTools = 26502;
		private const int SaveImageAs = 26503;
		private const int SaveAsPdf = 26504;
		private const int SaveLinkAs = 26505;
		private const int CopyLinkAddress = 26506;
		private const int OpenLinkInNewTab = 26507;
		private const int CloseTab = 40007;
		private const int RefreshTab = 40008;
        private const int MOSinformation = 40009;
        private const int Cachedel = 40010;
		MainForm myForm;

		private string lastSelText = "";
        public static string Branding = "Menglolita Browser S 1.0.1 Beta";
		public ContextMenuHandler(MainForm form) {
			myForm = form;
		}

		public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model) {
			
			// clear the menu
			model.Clear();

			// save text
			lastSelText = parameters.SelectionText;

			// to copy text
			if (parameters.SelectionText.CheckIfValid()) {
				model.AddItem(CefMenuCommand.Copy, "复制");
				model.AddSeparator();
			}

			//Removing existing menu item
			//bool removed = model.Remove(CefMenuCommand.ViewSource); // Remove "View Source" option
			if (parameters.LinkUrl != "") {
				model.AddItem((CefMenuCommand)OpenLinkInNewTab, "在新标签页里打开");
				model.AddItem((CefMenuCommand)CopyLinkAddress, "复制链接");
				model.AddSeparator();
			}

			if (parameters.HasImageContents && parameters.SourceUrl.CheckIfValid()) {
				
				// RIGHT CLICKED ON IMAGE

			}

			if (parameters.SelectionText != null) {

				// TEXT IS SELECTED

			}

			//Add new custom menu items
			//#if DEBUG
			model.AddItem((CefMenuCommand)ShowDevTools, "开发者工具");
			model.AddItem(CefMenuCommand.ViewSource, "网页源代码");
			model.AddSeparator();
			//#endif

			model.AddItem((CefMenuCommand)RefreshTab, "刷新当前页");
			model.AddItem((CefMenuCommand)CloseTab, "关闭当前页");
            model.AddSeparator();
            //#endif
            model.AddItem((CefMenuCommand)Cachedel, "删除浏览器缓存");
            model.AddItem((CefMenuCommand)MOSinformation, "关于 MOBS");
		}

        public bool OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {

            int id = (int)commandId;

            if (id == ShowDevTools)
            {
                browser.ShowDevTools();
            }
            if (id == CloseDevTools)
            {
                browser.CloseDevTools();
            }
            if (id == MOSinformation)
            {
                new About().ShowDialog();
            }
            if (id == Cachedel)
            {
                string Path = AppDomain.CurrentDomain.BaseDirectory;
                MessageBox.Show("浏览器将在清理缓存前关闭，清理完成后可重新打开", "我要去做一下清理工作");
                Thread.Sleep(1000);
                MessageBox.Show("如遇上访问拒绝错误，等待或者关掉清理工具并再次打开", "提示");
                Process proc = new Process();
                proc.StartInfo.FileName = Path + "MOBS Cleaner.exe";
                proc.Start();
                //Thread.Sleep(10);
                Application.Exit();
                GC.Collect();
                GC.SuppressFinalize(this);

                
                
                
              
                //if (File.GetAttributes(Path).ToString().IndexOf("ReadOnly") != -1)
                    //File.SetAttributes(Path, FileAttributes.Normal);
                //File.Delete(Path);//删除缓存
                //MessageBox.Show("已删除MOBS缓存！","干净了好多");
            }
                    
                if (id == SaveImageAs)
                {
                    browser.GetHost().StartDownload(parameters.SourceUrl);
                }
                if (id == SaveLinkAs)
                {
                    browser.GetHost().StartDownload(parameters.LinkUrl);
                }
                if (id == OpenLinkInNewTab)
                {
                    ChromiumWebBrowser newBrowser = myForm.AddNewBrowserTab(parameters.LinkUrl, false);
                }
                if (id == CopyLinkAddress)
                {
                    Clipboard.SetText(parameters.LinkUrl);
                }
                if (id == CloseTab)
                {
                    myForm.InvokeOnParent(delegate()
                    {
                        myForm.CloseActiveTab();
                    });
                }
                if (id == RefreshTab)
                {
                    myForm.InvokeOnParent(delegate()
                    {
                        myForm.RefreshActiveTab();
                    });
                }

                return false;
            }
        

		public void OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame) {

		}

		public bool RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback) {

			// show default menu
			return false;
		}

    }
}
