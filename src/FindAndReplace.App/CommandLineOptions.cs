﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandLine;
using CommandLine.Text;

namespace FindAndReplace.App
{
	public class CommandLineOptions : CommandLineOptionsBase
	{
		#region Standard Option Attribute

		[Option(null, "cl", HelpText = "Required to run on command line.")]
		public bool UseCommandLine = false; 

		[Option(null, "find", Required = true, HelpText = "Text to find.")]
		public string FindText = String.Empty;

		[Option(null, "replace", HelpText = "Replacement text.")]
		public string ReplaceText = String.Empty;

		[Option(null, "caseSensitive", HelpText = "Case Sensitive.")]
		public bool IsCaseSensitive = false;

		[Option(null, "dir", Required = true, HelpText = "Directory path.")]
		public string Dir = String.Empty;

		[Option(null, "fileMask", Required = true, HelpText = "File mask.")]
		public string FileMask = String.Empty;

		[Option(null, "includeSubDirectories", HelpText = "Include files in SubDirectories.")]
		public bool IncludeSubDirectories = false;


		#endregion

		#region Specialized Option Attribute

		[HelpOption(null, "help", HelpText = "Dispaly this help screen.")]
		public string GetUsage()
		{
			var help = new HelpText("Find And Replace");

			help.Copyright = new CopyrightInfo("Entech Solutions", 2011);
			this.HandleParsingErrorsInHelp(help);
			help.AddPreOptionsLine("Usage: \n\nfnr.exe --cl --find \"Text To Find\" --replace \"Text To Replace\"  --caseSensitive  --dir \"Directory Path\" --fileMask \"*.*\"  --includeSubDirectories");
			help.AddPreOptionsLine("\n");
			help.AddPreOptionsLine("Mask new line and quote characters using \\n and \\\".");


			help.AddOptions(this);

			return help;
		}

		private void HandleParsingErrorsInHelp(HelpText help)
		{
			string errors = help.RenderParsingErrorsText(this);
			if (!string.IsNullOrEmpty(errors))
			{
				help.AddPreOptionsLine(string.Concat(Environment.NewLine, "ERROR: ", errors, Environment.NewLine));
			}
		}

		#endregion
	}
}