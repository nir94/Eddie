// <airvpn_source_header>
// This file is part of AirVPN Client software.
// Copyright (C)2014-2014 AirVPN (support@airvpn.org) / https://airvpn.org )
//
// AirVPN Client is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// AirVPN Client is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with AirVPN Client. If not, see <http://www.gnu.org/licenses/>.
// </airvpn_source_header>

using System;
using System.Drawing;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;

namespace AirVPN.UI.Osx
{
	public partial class AppDelegate : NSApplicationDelegate
	{
		MainWindowController mainWindowController;



		WindowAboutController windowAbout;
		WindowPreferencesController windowPreferences;

		public AppDelegate ()
		{
		}

		public override bool ApplicationShouldTerminateAfterLastWindowClosed (NSApplication sender)
		{
			return true;
		}

		public override void FinishedLaunching (NSObject notification)
		{
			//CreateMenu (); // TOCLEAN

			mainWindowController = new MainWindowController ();
			mainWindowController.Window.MakeKeyAndOrderFront (this);

			MenuEvents ();

		}



		void MenuEvents()
		{
			MnuMainAbout.Activated += (object sender, EventArgs e) =>
			{
				if(windowAbout == null)
					windowAbout = new WindowAboutController();
				windowAbout.ShowWindow(this);
			};

			MnuMainPreferences.Activated += (object sender, EventArgs e) =>
			{
				if(windowPreferences == null)
					windowPreferences = new WindowPreferencesController();
				windowPreferences.ShowWindow(this);
			};

			MnuMainHome.Activated += (object sender, EventArgs e) =>
			{
				AirVPN.Core.UI.Actions.OpenUrlWebsite();
			};

			MnuMainClientArea.Activated += (object sender, EventArgs e) =>
			{
				AirVPN.Core.UI.Actions.OpenUrlClient();
			};

			MnuMainForwardingPorts.Activated += (object sender, EventArgs e) =>
			{
				AirVPN.Core.UI.Actions.OpenUrlPorts();
			};

			MnuMainSpeedTest.Activated += (object sender, EventArgs e) =>
			{
				AirVPN.Core.UI.Actions.OpenUrlSpeedTest();
			};

			MnuMainQuit.Activated += (object sender, EventArgs e) => {
				Engine.Instance.RequestStop();
			};
		}
	}
}

