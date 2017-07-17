﻿// <eddie_source_header>
// This file is part of Eddie/AirVPN software.
// Copyright (C)2014-2016 AirVPN (support@airvpn.org) / https://airvpn.org
//
// Eddie is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// Eddie is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Eddie. If not, see <http://www.gnu.org/licenses/>.
// </eddie_source_header>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Eddie.Lib.Common;
using Eddie.Core;

namespace Eddie.Gui.Forms
{
    public partial class Login : Eddie.Gui.Form
    {
		public Credentials Credentials;
		
        public Login()
        {
            OnPreInitializeComponent();
            InitializeComponent();
            OnInitializeComponent();
        }

        public override void OnInitializeComponent()
        {
            base.OnInitializeComponent();
        }

        public override void OnApplySkin()
        {
            base.OnApplySkin();

			GuiUtils.FixHeightVs(txtUsername, lblUsername);
			GuiUtils.FixHeightVs(txtPassword, lblPassword);
			GuiUtils.FixHeightVs(lblRemember, cboRemember);
		}

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            CommonInit(Messages.WindowsLoginTitle);

			cboRemember.Items.Add(Messages.WindowsLoginRememberNo);
			cboRemember.Items.Add(Messages.WindowsLoginRememberRun);
			cboRemember.Items.Add(Messages.WindowsLoginRememberPermanent);
			cboRemember.Text = Messages.WindowsLoginRememberRun;

			EnableIde();
		}

		private void EnableIde()
		{

		}
		
		private void cmdOk_Click(object sender, EventArgs e)
		{
			Credentials = new Credentials();

			Credentials.Username = txtUsername.Text;
			Credentials.Password = txtPassword.Text;
			if (cboRemember.Text == Messages.WindowsLoginRememberNo)
				Credentials.Remember = "no";
			else if (cboRemember.Text == Messages.WindowsLoginRememberRun)
				Credentials.Remember = "run";
			else if (cboRemember.Text == Messages.WindowsLoginRememberPermanent)
				Credentials.Remember = "permanent";
			else
				Credentials.Remember = "no";
		}
	}
}
