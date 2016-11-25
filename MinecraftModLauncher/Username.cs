﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace MinecraftModLauncher
{
    public partial class Username : Form
    {
        public Username(string versionIn)
        {
            InitializeComponent();

            this.label1.Text = "Banshee " + versionIn;
        }

        //If the user is offline and unable to authenticate, they have the oppertunity to choose a username and play locally.
        //I never finished the authentication system for the mod server, so it didn't make a difference really.
        //But that wasn't an issue for such a small project.
        private void launchButton_Click(object sender, EventArgs e)
        {
            ProcessStartInfo launchInfo = new ProcessStartInfo();
            launchInfo.FileName = "cmd.exe";
            launchInfo.RedirectStandardInput = true;
            launchInfo.UseShellExecute = false;

            Process minecraftProcess = new Process();
            minecraftProcess.StartInfo = launchInfo;
            minecraftProcess.Start();

            minecraftProcess.StandardInput.WriteLine("cd \"" + Environment.CurrentDirectory + "\\Client\"");
            minecraftProcess.StandardInput.WriteLine("java -cp minecraft.jar;lwjgl.jar;lwjgl_util.jar -Djava.library.path=\"natives\" net.minecraft.client.Minecraft ");
            minecraftProcess.StandardInput.WriteLine("pause");

            Environment.Exit(0);
        }

        private void Username_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
